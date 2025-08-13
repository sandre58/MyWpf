// -----------------------------------------------------------------------
// <copyright file="NullOrEmptyException.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MyNet.Utilities.Exceptions;

public class NullOrEmptyException : TranslatableException
{
    public NullOrEmptyException() { }

    public NullOrEmptyException(string message, System.Exception innerException)
        : base(message, innerException) { }

    public NullOrEmptyException(string property)
        : base("Field {0} is required.", "FieldXIsRequiredError", property) { }

    public NullOrEmptyException(string? message, System.Exception? innerException, string resourceKey, params object?[] stringFormatParameters)
        : base(message, innerException, resourceKey, stringFormatParameters)
    {
    }

    public NullOrEmptyException(System.Exception? innerException, string resourceKey, params object?[] stringFormatParameters)
        : base(innerException, resourceKey, stringFormatParameters)
    {
    }

    public NullOrEmptyException(string? message, string resourceKey, params object?[] stringFormatParameters)
        : base(message, resourceKey, stringFormatParameters)
    {
    }

    public NullOrEmptyException(string resourceKey, params object?[] stringFormatParameters)
        : base(resourceKey, stringFormatParameters)
    {
    }
}
