// -----------------------------------------------------------------------
// <copyright file="TypedEventHandler.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Windows;

namespace MyNet.Wpf.Controls;

/// <summary>
/// Represents a method that handles general events.
/// </summary>
/// <typeparam name="TSender"></typeparam>
/// <typeparam name="TArgs"></typeparam>
/// <param name="sender"></param>
/// <param name="args"></param>
public delegate void TypedEventHandler<in TSender, in TArgs>(TSender sender, TArgs args)
where TSender : DependencyObject
where TArgs : RoutedEventArgs;
