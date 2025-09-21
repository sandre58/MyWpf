// -----------------------------------------------------------------------
// <copyright file="IndicatorVisualStateGroupNames.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MyNet.Wpf.Controls.VisualStates;

internal sealed class IndicatorVisualStateGroupNames
{
    private static IndicatorVisualStateGroupNames? _internalActiveStates;
    private static IndicatorVisualStateGroupNames? _sizeStates;

    public static IndicatorVisualStateGroupNames ActiveStates =>
_internalActiveStates ??= new IndicatorVisualStateGroupNames(nameof(ActiveStates));

    public static IndicatorVisualStateGroupNames SizeStates =>
_sizeStates ??= new IndicatorVisualStateGroupNames(nameof(SizeStates));

    private IndicatorVisualStateGroupNames(string name) => Name = name;

    public string Name { get; }
}
