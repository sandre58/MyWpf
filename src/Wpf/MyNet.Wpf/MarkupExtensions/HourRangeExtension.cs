// -----------------------------------------------------------------------
// <copyright file="HourRangeExtension.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Linq;
using MyNet.Utilities;
using MyNet.Utilities.Helpers;

namespace MyNet.Wpf.MarkupExtensions;

public class HourRangeExtension : IntegerRangeExtension
{
    public HourRangeExtension()
    {
    }

    public override object? ProvideValue(IServiceProvider serviceProvider) => EnumerableHelper.Range(Start, End, Step).Select(x => x.Hours().TimeSpan);
}
