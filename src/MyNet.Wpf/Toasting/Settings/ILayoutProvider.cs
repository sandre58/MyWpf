// -----------------------------------------------------------------------
// <copyright file="ILayoutProvider.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Windows;

namespace MyNet.Wpf.Toasting.Settings;

public interface ILayoutProvider : IDisposable
{
    bool TopMost { get; }

    double Width { get; }

    Window? ParentWindow { get; }

    Point GetPosition(double actualPopupWidth, double actualPopupHeight);

    double GetHeight();

    EjectDirection EjectDirection { get; }

    event EventHandler? UpdatePositionRequested;
    event EventHandler? UpdateEjectDirectionRequested;
    event EventHandler? UpdateHeightRequested;
}
