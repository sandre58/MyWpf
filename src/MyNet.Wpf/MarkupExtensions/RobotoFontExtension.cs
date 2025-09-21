// -----------------------------------------------------------------------
// <copyright file="RobotoFontExtension.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Windows.Markup;
using System.Windows.Media;
using MyNet.Wpf.Helpers;

namespace MyNet.Wpf.MarkupExtensions;

[MarkupExtensionReturnType(typeof(FontFamily))]
public class RobotoFontExtension : MarkupExtension
{
    private static readonly Lazy<FontFamily> Roboto = new(() => WpfHelper.GetResource<FontFamily>("MyNet.Font.Family.Roboto") ?? new FontFamily());

    public override object ProvideValue(IServiceProvider serviceProvider) => Roboto.Value;
}
