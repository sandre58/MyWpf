// -----------------------------------------------------------------------
// <copyright file="MultiComboBoxItem.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;

namespace MyNet.Wpf.Controls;

[Localizability(LocalizationCategory.ComboBox)]
public class MultiComboBoxItem : ListBoxItem
{
    static MultiComboBoxItem() => DefaultStyleKeyProperty.OverrideMetadata(typeof(MultiComboBoxItem), new FrameworkPropertyMetadata(typeof(MultiComboBoxItem)));
}
