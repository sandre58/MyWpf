// -----------------------------------------------------------------------
// <copyright file="NotNullableBinding.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using MyNet.Wpf.Converters;
using System.Windows.Data;

namespace MyNet.Wpf.MarkupExtensions;

public class NotNullableBinding : Binding
{
    public NotNullableBinding(string path)
        : base(path) => Converter = NotNullableConverter.Default;

    public NotNullableBinding() => Converter = NotNullableConverter.Default;
}
