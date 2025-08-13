// -----------------------------------------------------------------------
// <copyright file="FutureDateException.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace MyNet.Utilities.Exceptions;

[Serializable]
public class FutureDateException : TranslatableException
{
    public FutureDateException() { }

    public FutureDateException(string message, Exception innerException)
        : base(message, innerException) { }

    public FutureDateException(string property)
        : base("The field {0} must be in past.", "FieldXMustBeInPastError", property) { }

    public FutureDateException(string? message, Exception? innerException, string resourceKey, params object?[] stringFormatParameters)
        : base(message, innerException, resourceKey, stringFormatParameters)
    {
    }

    public FutureDateException(Exception? innerException, string resourceKey, params object?[] stringFormatParameters)
        : base(innerException, resourceKey, stringFormatParameters)
    {
    }

    public FutureDateException(string? message, string resourceKey, params object?[] stringFormatParameters)
        : base(message, resourceKey, stringFormatParameters)
    {
    }

    public FutureDateException(string resourceKey, params object?[] stringFormatParameters)
        : base(resourceKey, stringFormatParameters)
    {
    }
}
