// -----------------------------------------------------------------------
// <copyright file="AllowedSourcesInputEventHandler.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace MyNet.Wpf.Controls.Toasts.Events;

public class AllowedSourcesInputEventHandler(IEnumerable<Type> allowedSources) : IKeyboardEventHandler
{
    private readonly IEnumerable<Type> _allowedSources = allowedSources;

    public void Handle(KeyEventArgs eventArgs)
    {
        var source = eventArgs.Source.GetType();
        var originalSource = eventArgs.Source.GetType();

        var doNotBlock = _allowedSources.Any(x => x == source || x == originalSource);

        eventArgs.Handled = !doNotBlock;
    }
}
