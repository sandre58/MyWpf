// -----------------------------------------------------------------------
// <copyright file="TimeExtension.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Windows.Data;
using MyNet.Wpf.Converters;

namespace MyNet.Wpf.MarkupExtensions;

public class TimeExtension : DateTimeExtension
{
    public TimeExtension()
        : base() { }

    public TimeExtension(string path)
        : base(path) { }

    protected override IValueConverter CreateConverter() => new TimeConverter(Conversion);
}
