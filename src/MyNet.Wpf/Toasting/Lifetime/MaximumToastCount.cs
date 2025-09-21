// -----------------------------------------------------------------------
// <copyright file="MaximumToastCount.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MyNet.Wpf.Toasting.Lifetime;

public readonly struct MaximumToastCount
{
    public static MaximumToastCount UnlimitedToasts() => new(int.MaxValue);

    public static MaximumToastCount FromCount(int count) => new(count);

    internal int Count { get; }

    private MaximumToastCount(int count) => Count = count;
}
