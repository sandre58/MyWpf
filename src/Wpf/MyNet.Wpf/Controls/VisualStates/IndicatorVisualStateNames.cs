// -----------------------------------------------------------------------
// <copyright file="IndicatorVisualStateNames.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MyNet.Wpf.Controls.VisualStates;

internal sealed class IndicatorVisualStateNames
{
    private static IndicatorVisualStateNames? _activeState;
    private static IndicatorVisualStateNames? _inactiveState;

    public static IndicatorVisualStateNames ActiveState =>
_activeState ??= new IndicatorVisualStateNames("Active");

    public static IndicatorVisualStateNames InactiveState =>
_inactiveState ??= new IndicatorVisualStateNames("Inactive");

    private IndicatorVisualStateNames(string name) => Name = name;

    public string Name { get; }
}
