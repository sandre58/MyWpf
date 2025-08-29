// -----------------------------------------------------------------------
// <copyright file="BusyService.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Reactive.Concurrency;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using MyNet.Observable;
using MyNet.UI.Loading;
using MyNet.UI.Loading.Models;
using MyNet.Wpf.Controls;

namespace MyNet.Wpf.Busy;

public class BusyService : ObservableObject, IBusyService
{
    private int _busyNumber;
    private BusyControl? _busyView;
    private Grid? _container;
#if NET9_0_OR_GREATER
    private readonly System.Threading.Lock _syncObj = new();
#else
    private readonly object _syncObj = new();
#endif

    public BusyControl BusyView
    {
        get
        {
            if (_busyView == null)
            {
                _busyView = CreateBusyView();
                _busyView.BusyHidden += (sender, e) => _container?.Children.Remove(BusyView);
            }

            return _busyView;
        }
    }

    #region IBusyService

    /// <summary>
    /// Gets if busy.
    /// </summary>
    public virtual bool IsBusy { get; private set; }

    public TBusy? GetCurrent<TBusy>() where TBusy : class, IBusy => BusyView.Content as TBusy;

    /// <summary>
    /// Show busy control during action.
    /// </summary>
    /// <typeparam name="TBusy"></typeparam>
    /// <param name="action"></param>
    public async Task WaitAsync<TBusy>(Action<TBusy> action) where TBusy : class, IBusy, new()
        => await WaitAsync(new Func<TBusy, Task>(x => Task.Run(() => action.Invoke(x)))).ConfigureAwait(false);

    /// <summary>
    /// Show busy control during action.
    /// </summary>
    /// <typeparam name="TBusy"></typeparam>
    /// <param name="action"></param>
    public async Task WaitAsync<TBusy>(Func<TBusy, Task> action) where TBusy : class, IBusy, new()
    {
        var busy = Wait<TBusy>();

        try
        {
            await action(busy).ConfigureAwait(false);
            Resume();
        }
        catch (Exception)
        {
            Resume();
            throw;
        }
    }

    /// <summary>
    /// Show busy control.
    /// </summary>
    public TBusy Wait<TBusy>() where TBusy : class, IBusy, new()
    {
        var busy = CreateBusyViewModel<TBusy>();

        lock (_syncObj)
        {
            _busyNumber++;

            if (_busyNumber != 1)
            {
                UI.Threading.Scheduler.UiOrCurrent.Schedule(() => BusyView.Content = busy);
                return busy;
            }
        }

        UI.Threading.Scheduler.UiOrCurrent.Schedule(() =>
        {
            ShowBusy(busy);
            IsBusy = true;
            CommandManager.InvalidateRequerySuggested();
        });
        return busy;
    }

    /// <summary>
    /// Hide busy control.
    /// </summary>
    public void Resume()
    {
        lock (_syncObj)
        {
            if (_busyNumber == 0)
            {
                return;
            }

            _busyNumber--;

            if (_busyNumber != 0)
            {
                return;
            }
        }

        UI.Threading.Scheduler.UiOrCurrent.Schedule(() =>
        {
            HideBusy();
            IsBusy = false;
            CommandManager.InvalidateRequerySuggested();
        });
    }

    #endregion IBusyService

    /// <summary>
    /// Show busy.
    /// </summary>
    private void ShowBusy(IBusy busy)
    {
        if (_container != null && BusyView.Parent == null && !_container.Children.Contains(BusyView))
        {
            if (_container.ColumnDefinitions.Count > 0)
            {
                Grid.SetColumnSpan(BusyView, _container.ColumnDefinitions.Count);
            }

            if (_container.RowDefinitions.Count > 0)
            {
                Grid.SetRowSpan(BusyView, _container.RowDefinitions.Count);
            }

            _ = _container.Children.Add(BusyView);
            BusyView.Opacity = 0;
        }

        BusyView.Content = busy;
        BusyView.IsActive = true;
    }

    /// <summary>
    /// Hide busy control.
    /// </summary>
    private void HideBusy() => BusyView.IsActive = false;

    protected virtual BusyControl CreateBusyView() => new();

    protected virtual TBusy CreateBusyViewModel<TBusy>() where TBusy : class, IBusy, new() => Activator.CreateInstance<TBusy>();

    public void SetContainer(Grid container) => _container = container;
}
