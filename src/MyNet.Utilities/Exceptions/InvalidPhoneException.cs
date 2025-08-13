// -----------------------------------------------------------------------
// <copyright file="InvalidPhoneException.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace MyNet.Utilities.Exceptions;

[Serializable]
public class InvalidPhoneException : TranslatableException
{
    public InvalidPhoneException() { }

    public InvalidPhoneException(string message, Exception innerException)
        : base(message, innerException) { }

    public InvalidPhoneException(string propertyName)
        : base("Field {0} must be a valid phone number.", "FieldXMustBeValidPhoneNumberError", propertyName) { }

    public InvalidPhoneException(string? message, Exception? innerException, string resourceKey, params object?[] stringFormatParameters)
        : base(message, innerException, resourceKey, stringFormatParameters)
    {
    }

    public InvalidPhoneException(Exception? innerException, string resourceKey, params object?[] stringFormatParameters)
        : base(innerException, resourceKey, stringFormatParameters)
    {
    }

    public InvalidPhoneException(string? message, string resourceKey, params object?[] stringFormatParameters)
        : base(message, resourceKey, stringFormatParameters)
    {
    }

    public InvalidPhoneException(string resourceKey, params object?[] stringFormatParameters)
        : base(resourceKey, stringFormatParameters)
    {
    }
}
