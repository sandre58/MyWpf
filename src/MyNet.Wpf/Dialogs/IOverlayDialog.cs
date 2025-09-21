// -----------------------------------------------------------------------
// <copyright file="IOverlayDialog.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Windows;

namespace MyNet.Wpf.Dialogs;

public interface IOverlayDialog
{
    bool CloseOnClickAway { get; }

    bool FocusOnShow { get; }

    VerticalAlignment VerticalAlignment { get; }

    HorizontalAlignment HorizontalAlignment { get; }

    double MaxHeight { get; set; }

    double MinHeight { get; set; }

    double MinWidth { get; set; }

    double MaxWidth { get; set; }
}
