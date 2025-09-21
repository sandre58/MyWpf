// -----------------------------------------------------------------------
// <copyright file="IKeyboardEventHandler.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Windows.Input;

namespace MyNet.Wpf.Controls.Toasts.Events;

public interface IKeyboardEventHandler
{
    void Handle(KeyEventArgs eventArgs);
}
