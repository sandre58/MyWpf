// -----------------------------------------------------------------------
// <copyright file="PositionExtensions.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Windows;

namespace MyNet.Wpf.Toasting.Settings;

public static class PositionExtensions
{
    public static Point GetActualPosition(this UIElement element)
    {
        var pt = element.PointToScreen(new Point(0, 0));
        var source = PresentationSource.FromVisual(element);
        return source!.CompositionTarget!.TransformFromDevice.Transform(pt);
    }
}
