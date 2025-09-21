// -----------------------------------------------------------------------
// <copyright file="AbstractMultiGlobalizationExtension.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Windows.Data;

namespace MyNet.Wpf.MarkupExtensions;

public abstract class AbstractMultiGlobalizationExtension : GlobalizationExtensionBase<MultiBinding>
{
    protected AbstractMultiGlobalizationExtension(bool updateOnCultureChanged, bool updateOnTimeZoneChanged)
        : base(updateOnCultureChanged, updateOnTimeZoneChanged) { }

    protected override MultiBinding CreateBinding() => new();

    public object? ConverterParameter { get => Binding.ConverterParameter; set => Binding.ConverterParameter = value; }

    protected abstract IMultiValueConverter CreateConverter();

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        Binding.Converter = CreateConverter();

        return base.ProvideValue(serviceProvider);
    }
}
