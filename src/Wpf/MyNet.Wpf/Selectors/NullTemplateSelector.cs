// -----------------------------------------------------------------------
// <copyright file="NullTemplateSelector.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;

namespace MyNet.Wpf.Selectors;

public class NullTemplateSelector : DataTemplateSelector
{
    public override DataTemplate? SelectTemplate(object item, DependencyObject container)
        => item is null
            ? NullTemplate
            : base.SelectTemplate(item, container);

    public DataTemplate? NullTemplate { get; set; }
}
