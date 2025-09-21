// -----------------------------------------------------------------------
// <copyright file="ColorPalettes.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Media;

namespace MyNet.Wpf.Media;

public static class ColorPalettes
{
    public static Color[] StandardColorsPalette { get; } =
        [
            Colors.Transparent,
            Colors.White,
            Colors.LightGray,
            Colors.Gray,
            Colors.Black,
            Colors.DarkRed,
            Colors.Red,
            Colors.Orange,
            Colors.Brown,
            Colors.Yellow,
            Colors.LimeGreen,
            Colors.Green,
            Colors.DarkTurquoise,
            Colors.Aqua,
            Colors.Navy,
            Colors.Blue,
            Colors.Indigo,
            Colors.Purple,
            Colors.Fuchsia
        ];

    public static ObservableCollection<Color> AvailableColorsPalette { get; } = new ObservableCollection<Color>(
        typeof(Colors)
            .GetProperties()
            .Where(x => x.PropertyType == typeof(Color))
            .Select(x => (Color)(x.GetValue(null) ?? default(Color)))
            .OrderBy(c => new HSVColor(c).Hue)
            .ThenBy(c => new HSVColor(c).Saturation)
            .ThenByDescending(c => new HSVColor(c).Value));
}
