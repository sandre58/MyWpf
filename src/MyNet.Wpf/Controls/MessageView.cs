﻿// -----------------------------------------------------------------------
// <copyright file="MessageView.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Windows;
using System.Windows.Input;
using MyNet.UI.Dialogs.MessageBox;
using MessageBoxResult = MyNet.UI.Dialogs.MessageBox.MessageBoxResult;

namespace MyNet.Wpf.Controls;

public class MessageView : ContentDialog
{
    public static readonly RoutedCommand YesCommand = new();
    public static readonly RoutedCommand NoCommand = new();
    public static readonly RoutedCommand CancelCommand = new();
    public static readonly RoutedCommand OkCommand = new();

    static MessageView() => DefaultStyleKeyProperty.OverrideMetadata(typeof(MessageView), new FrameworkPropertyMetadata(typeof(MessageView)));

    public MessageView(IMessageBox messageBox)
    {
        DataContext = messageBox;
        Content = messageBox;
        Header = messageBox.Title;
        Buttons = messageBox.Buttons;
        DefaultResult = messageBox.DefaultResult;

        CommandBindings.Add(new CommandBinding(YesCommand, (sender, e) => OnClose(MessageBoxResult.Yes)));
        CommandBindings.Add(new CommandBinding(NoCommand, (sender, e) => OnClose(MessageBoxResult.No)));
        CommandBindings.Add(new CommandBinding(CancelCommand, (sender, e) => OnClose(MessageBoxResult.Cancel)));
        CommandBindings.Add(new CommandBinding(OkCommand, (sender, e) => OnClose(MessageBoxResult.Ok)));
    }

    #region Button

    /// <summary>
    ///     Identifies the <see cref="Buttons" /> property.
    /// </summary>
    public static readonly DependencyProperty ButtonsProperty = DependencyProperty.Register(nameof(Buttons),
        typeof(MessageBoxResultOption), typeof(MessageView),
        new PropertyMetadata(MessageBoxResultOption.Ok));

    /// <summary>
    ///     Identifies the <see cref="Buttons" /> property.
    /// </summary>
    public MessageBoxResultOption Buttons
    {
        get => (MessageBoxResultOption)GetValue(ButtonsProperty);
        set => SetValue(ButtonsProperty, value);
    }

    #endregion Button

    #region DefaultResult

    /// <summary>
    ///     Identifies the <see cref="DefaultResult" /> property.
    /// </summary>
    public static readonly DependencyProperty DefaultResultProperty = DependencyProperty.Register(nameof(DefaultResult),
        typeof(MessageBoxResult), typeof(MessageView),
        new PropertyMetadata(MessageBoxResult.None));

    /// <summary>
    ///     Identifies the <see cref="DefaultResult" /> property.
    /// </summary>
    public MessageBoxResult DefaultResult
    {
        get => (MessageBoxResult)GetValue(DefaultResultProperty);
        set => SetValue(DefaultResultProperty, value);
    }

    public MessageBoxResult MessageBoxResult { get; private set; }

    #endregion DefaultResult

    #region Methods

    private void OnClose(MessageBoxResult result)
    {
        MessageBoxResult = result;
        DialogResult = result is MessageBoxResult.Ok or MessageBoxResult.Yes;

        Close();
    }

    #endregion Methods
}
