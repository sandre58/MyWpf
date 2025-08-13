// -----------------------------------------------------------------------
// <copyright file="InvalidEmailAddressException.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace MyNet.Utilities.Exceptions;

[Serializable]
public class InvalidEmailAddressException : TranslatableException
{
    public InvalidEmailAddressException() { }

    public InvalidEmailAddressException(string message, Exception innerException)
        : base(message, innerException) { }

    public InvalidEmailAddressException(string propertyName)
        : base("Field {0} must be a valid email address.", "FieldXMustBeValidEmailAddressError", propertyName) { }

    public InvalidEmailAddressException(string? message, Exception? innerException, string resourceKey, params object?[] stringFormatParameters)
        : base(message, innerException, resourceKey, stringFormatParameters)
    {
    }

    public InvalidEmailAddressException(Exception? innerException, string resourceKey, params object?[] stringFormatParameters)
        : base(innerException, resourceKey, stringFormatParameters)
    {
    }

    public InvalidEmailAddressException(string? message, string resourceKey, params object?[] stringFormatParameters)
        : base(message, resourceKey, stringFormatParameters)
    {
    }

    public InvalidEmailAddressException(string resourceKey, params object?[] stringFormatParameters)
        : base(resourceKey, stringFormatParameters)
    {
    }
}
