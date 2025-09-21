// -----------------------------------------------------------------------
// <copyright file="EnumerationSourceExtension.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Markup;
using MyNet.Observable.Translatables;
using MyNet.Utilities;

namespace MyNet.Wpf.MarkupExtensions;

public class EnumerationSourceExtension : MarkupExtension
{
    private Type? _enumType;

    private IEnumerable<object>? _enumsToExclude;

    public Type? EnumType
    {
        get => _enumType;

        set
        {
            if (value == null || _enumType == value)
            {
                return;
            }

            _enumType = value;
        }
    }

    public object? EnumsToExclude
    {
        get => _enumsToExclude;

        set
        {
            if (Equals(_enumsToExclude, value) || value == null)
            {
                return;
            }

            var list = value is IEnumerable<object> enumerable ? enumerable : [value];
            var invalidEnumType = list.Select(v => Nullable.GetUnderlyingType(v.GetType()) ?? v.GetType()).FirstOrDefault(e => e != EnumType);
            if (invalidEnumType != null)
            {
                throw new ArgumentException("Wrong type : {0}".InvariantFormatWith(invalidEnumType.Name));
            }

            _enumsToExclude = list;
        }
    }

    public bool OrderByDisplay { get; set; }

    public bool AddNullValue { get; set; }

    public EnumerationSourceExtension()
    {
    }

    public EnumerationSourceExtension(Type enumType) => EnumType = enumType ?? throw new ArgumentNullException(nameof(enumType));

    public EnumerationSourceExtension(Type enumType, object enumsToExclude)
        : this(enumType) => EnumsToExclude = enumsToExclude is Array enumsAsArray ? enumsAsArray.Cast<object>() : [enumsToExclude];

    public override object? ProvideValue(IServiceProvider serviceProvider)
    {
        if (EnumType != null)
        {
            var enumValues = EnumClass.GetAll(EnumType).Cast<IEnumeration>().Where(x => _enumsToExclude == null || !_enumsToExclude.Contains(x)).Select(x => new EnumClassTranslatable(x));

            if (OrderByDisplay)
                enumValues = enumValues.OrderBy(x => x.Display);

            var values = enumValues.ToList();

            if (AddNullValue)
                values.Insert(0, null!);

            return values;
        }

        return null;
    }
}
