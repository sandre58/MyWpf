// -----------------------------------------------------------------------
// <copyright file="BlockAllKeyInputEventHandler.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Windows.Input;

namespace MyNet.Wpf.Controls.Toasts.Events;

public class BlockAllKeyInputEventHandler : IKeyboardEventHandler
{
    public void Handle(KeyEventArgs eventArgs) => eventArgs.Handled = true;
}
