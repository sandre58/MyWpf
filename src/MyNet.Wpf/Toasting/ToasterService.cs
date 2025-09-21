﻿// -----------------------------------------------------------------------
// <copyright file="ToasterService.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Windows;
using MyNet.UI.Notifications;
using MyNet.UI.Toasting;
using MyNet.UI.Toasting.Settings;
using MyNet.Wpf.Controls;
using MyNet.Wpf.Toasting.Lifetime;
using MyNet.Wpf.Toasting.Lifetime.Clear;
using MyNet.Wpf.Toasting.Settings;
using MyNet.Utilities;
using System.Collections.Generic;

namespace MyNet.Wpf.Toasting;

public class ToasterService : IToasterService, IDisposable
{
    private readonly ToastsWindow _window;
    private readonly ILayoutProvider _layoutProvider;
    private readonly IToastLifetimeSupervisor _lifetimeSupervisor;
    private readonly CompositeDisposable _cleanup = [];

    public event EventHandler<ToastEventArgs>? ToastShown;
    public event EventHandler<ToastEventArgs>? ToastClosed;
    public event EventHandler<ToastEventArgs>? ToastClicked;

    public ToasterService()
        : this(ToasterSettings.Default) { }

    public ToasterService(ToasterSettings settings)
    : this(new TimeAndCountBasedLifetimeSupervisor(settings.Duration, MaximumToastCount.FromCount(settings.MaxItems), () => Application.Current.Dispatcher),
            new WindowLayoutProvider(() => Application.Current.MainWindow, (Corner)settings.Position, settings.OffsetX, settings.OffsetY, settings.Width))
    { }

    public ToasterService(IToastLifetimeSupervisor supervisor, ILayoutProvider provider)
    {
        _layoutProvider = provider;
        _lifetimeSupervisor = supervisor;
        _window = new ToastsWindow { Topmost = _layoutProvider.TopMost, Width = _layoutProvider.Width };

        _cleanup.AddRange([

            System.Reactive.Linq.Observable.FromEventPattern<ShowToastEventArgs>(x => _lifetimeSupervisor.ShowToastRequested += x, x => _lifetimeSupervisor.ShowToastRequested -= x)
                      .ObserveOn(Schedulers.WpfScheduler.Current)
                      .Subscribe(x => ShowToast(x.EventArgs.Toast)),

            System.Reactive.Linq.Observable.FromEventPattern<CloseToastEventArgs>(x => _lifetimeSupervisor.CloseToastRequested += x, x => _lifetimeSupervisor.CloseToastRequested -= x)
                      .ObserveOn(Schedulers.WpfScheduler.Current)
                      .Subscribe(x => CloseToast(x.EventArgs.Toast)),

            System.Reactive.Linq.Observable.FromEventPattern(x => _layoutProvider.UpdatePositionRequested += x, x => _layoutProvider.UpdatePositionRequested -= x)
                      .ObserveOn(Schedulers.WpfScheduler.Current)
                      .Subscribe(_ => UpdateWindowPosition()),

            System.Reactive.Linq.Observable.FromEventPattern(x => _layoutProvider.UpdateEjectDirectionRequested += x, x => _layoutProvider.UpdateEjectDirectionRequested -= x)
                      .ObserveOn(Schedulers.WpfScheduler.Current)
                      .Subscribe(_ => UpdateEjectDirection()),

            System.Reactive.Linq.Observable.FromEventPattern(x => _layoutProvider.UpdateHeightRequested += x, x => _layoutProvider.UpdateHeightRequested -= x)
                      .ObserveOn(Schedulers.WpfScheduler.Current)
                      .Subscribe(_ => UpdateHeight())
        ]);
    }

    protected virtual Toast CreateToast(INotification notification, ToastSettings settings, Action<INotification>? onClick = null, Action? onClose = null) => new(notification, settings, x =>
    {
        onClick?.Invoke(x);
        ToastClicked?.Invoke(this, new ToastEventArgs(x));
    }, onClose);

    #region IToasterService

    /// <summary>
    /// Displays a modal dialog of a type that is determined by the dialog type locator.
    /// </summary>
    public void Show(INotification notification, ToastSettings settings, bool isUnique = false, Action<INotification>? onClick = null, Action? onClose = null)
    {
        if (isUnique)
            Hide(notification);

        _lifetimeSupervisor.PushToast(CreateToast(notification, settings, onClick, onClose));
    }

    /// <summary>
    /// Hide all messages.
    /// </summary>
    public void Clear() => ClearMessages(new ClearAll());

    /// <summary>
    /// Hide a message if is displayed.
    /// </summary>
    /// <param name="notification"></param>
    public void Hide(INotification notification) => ClearMessages(new ClearByNotification(notification));

    private void ClearMessages(IClearStrategy clearStrategy) => Schedulers.WpfScheduler.Current.Schedule(() => _lifetimeSupervisor.ClearMessages(clearStrategy));

    #endregion

    #region ToastsWindow

    private void UpdateWindowPosition()
    {
        if (!_window.IsLoaded) return;
        var position = _layoutProvider.GetPosition(_window.Width, _window.Height);

        _window.Left = position.X;
        _window.Top = position.Y;
    }

    private void UpdateEjectDirection()
    {
        if (!_window.IsLoaded) return;
        _window.EjectDirection = _layoutProvider.EjectDirection;
    }

    private void UpdateHeight()
    {
        if (!_window.IsLoaded) return;
        var height = _layoutProvider.GetHeight();
        _window.MinHeight = height;
        _window.Height = height;
    }

    #endregion

    #region Display Notification

    private void ShowToast(Toast toast)
    {
        if (!_window.IsLoaded)
        {
            _window.Owner = _layoutProvider.ParentWindow;
            _window.Show();

            UpdateHeight();
        }

        _window.AddToast(toast);

        UpdateEjectDirection();
        UpdateWindowPosition();

        ToastShown?.Invoke(this, new ToastEventArgs(toast.Notification));
    }

    private void CloseToast(Toast toast)
    {
        _window.RemoveToast(toast);
        ToastClosed?.Invoke(this, new ToastEventArgs(toast.Notification));
    }

    #endregion

    #region IDisposable

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {

            _cleanup.Dispose();
            _lifetimeSupervisor.Dispose();
            _layoutProvider.Dispose();

            _window.Close();
        }
    }

    public IEnumerable<INotification> GetActiveToasts() => throw new NotImplementedException();

    #endregion IDisposable
}
