// -----------------------------------------------------------------------
// <copyright file="EnumConverter.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using MyNet.Humanizer;

namespace MyNet.CsvHelper.Extensions.Converters;

public class EnumConverter<T> : DefaultTypeConverter
    where T : struct, Enum
{
    public override object ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData) => text?.DehumanizeTo<T>()!;

    public override string ConvertToString(object? value, IWriterRow row, MemberMapData memberMapData) => value is Enum e ? e.Humanize() ?? string.Empty : string.Empty;
}
