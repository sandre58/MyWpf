// -----------------------------------------------------------------------
// <copyright file="ShortcutResourceExtension.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Windows.Data;
using System.Windows.Markup;
using MyNet.Humanizer;
using MyNet.Observable.Attributes;
using MyNet.Observable.Translatables;
using MyNet.Utilities;

namespace MyNet.Wpf.MarkupExtensions;

public class ShortcutResourceExtension : ResourceExtension
{
    public ShortcutResourceExtension()
    { }

    public ShortcutResourceExtension(string key)
        : base(key) { }

    public ShortcutResourceExtension(string key, string shortcutKey)
        : base(key) => ShortcutKey = shortcutKey;

    [ConstructorArgument("shortcutKey")]
    public string ShortcutKey { get; set; } = string.Empty;

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        var binding = new Binding(nameof(StringTranslatable.Value))
        {
            Source = new ShortcutStringTranslatable(Key, ShortcutKey, Casing)
        };

        return binding.ProvideValue(serviceProvider);
    }
}

internal class ShortcutStringTranslatable(string key, string shortcutKey, LetterCasing casing = LetterCasing.Normal) : StringTranslatable(key, casing)
{
    public string ShortcutKey { get; set; } = shortcutKey;

    [UpdateOnCultureChanged]
    public override string? Value => $"{base.Value} ({ShortcutKey.Translate()})";
}
