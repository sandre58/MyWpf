// -----------------------------------------------------------------------
// <copyright file="NullableBinding.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using MyNet.Wpf.Converters;
using System.Windows.Data;

namespace MyNet.Wpf.MarkupExtensions;

public class NullableBinding : Binding
{
    public NullableBinding(string path)
        : base(path) => Converter = NullableConverter.Default;

    public NullableBinding() => Converter = NullableConverter.Default;
}
