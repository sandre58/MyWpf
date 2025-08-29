// -----------------------------------------------------------------------
// <copyright file="DateTimeExtension.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Windows;
using System.Windows.Data;
using MyNet.Wpf.Converters;

namespace MyNet.Wpf.MarkupExtensions;

public class DateTimeExtension : AbstractGlobalizationExtension
{
    public DateTimeExtension()
        : base(true, true) { }

    public DateTimeExtension(string path)
        : this() => Path = new PropertyPath(path);

    public DateTimeConversion Conversion { get; set; } = DateTimeConversion.None;

    protected override IValueConverter CreateConverter() => new DateTimeConverter(Conversion);
}
