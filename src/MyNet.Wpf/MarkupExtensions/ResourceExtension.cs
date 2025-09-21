// -----------------------------------------------------------------------
// <copyright file="ResourceExtension.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Windows.Data;
using System.Windows.Markup;
using MyNet.Humanizer;
using MyNet.Observable.Translatables;

namespace MyNet.Wpf.MarkupExtensions;

public class ResourceExtension : MarkupExtension
{
    static ResourceExtension() => ResourceLocator.Initialize();

    public ResourceExtension()
    { }

    public ResourceExtension(string key) => Key = key;

    public ResourceExtension(string key, string filename)
    {
        Key = key;
        Filename = filename;
    }

    [ConstructorArgument("key")]
    public string Key { get; set; } = string.Empty;

    [ConstructorArgument("filename")]
    public string? Filename { get; set; }

    public LetterCasing Casing { get; set; } = LetterCasing.Normal;

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        var binding = new Binding(nameof(StringTranslatable.Value))
        {
            Source = new StringTranslatable(Key, Casing, Filename)
        };

        return binding.ProvideValue(serviceProvider);
    }
}
