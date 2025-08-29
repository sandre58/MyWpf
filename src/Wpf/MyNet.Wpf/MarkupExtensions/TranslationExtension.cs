// -----------------------------------------------------------------------
// <copyright file="TranslationExtension.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Windows.Data;
using MyNet.Wpf.Converters;
using MyNet.Humanizer;
using System.Windows;

namespace MyNet.Wpf.MarkupExtensions;

public class TranslationExtension : AbstractGlobalizationExtension
{
    public TranslationExtension()
        : base(true, false) { }

    public TranslationExtension(string path)
        : this() => Path = new PropertyPath(path);

    protected override Binding CreateBinding() => new();

    public string? Format { get => Binding.ConverterParameter?.ToString(); set => Binding.ConverterParameter = value; }

    public bool Pluralize { get; set; }

    public bool Abbreviate { get; set; }

    public LetterCasing Casing { get; set; } = LetterCasing.Normal;

    protected override IValueConverter CreateConverter() => new StringConverter(Casing, Pluralize, Abbreviate);
}
