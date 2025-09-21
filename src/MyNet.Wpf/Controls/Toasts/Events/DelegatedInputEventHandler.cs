// -----------------------------------------------------------------------
// <copyright file="DelegatedInputEventHandler.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Windows.Input;

namespace MyNet.Wpf.Controls.Toasts.Events;

public class DelegatedInputEventHandler(Action<KeyEventArgs> action) : IKeyboardEventHandler
{
    private readonly Action<KeyEventArgs> _action = action;

    public void Handle(KeyEventArgs eventArgs) => _action(eventArgs);
}
