// -----------------------------------------------------------------------
// <copyright file="TextContextMenuExtension.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using MyNet.Wpf.Controls;
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Markup;

namespace MyNet.Wpf.MarkupExtensions;

[EditorBrowsable(EditorBrowsableState.Never)]
[MarkupExtensionReturnType(typeof(ContextMenu))]
public class TextContextMenuExtension : MarkupExtension
{
    public override object? ProvideValue(IServiceProvider serviceProvider) => DefaultContextMenu.Value;

    private static readonly ThreadLocal<TextContextMenu> DefaultContextMenu = new(() => new TextContextMenu());
}
