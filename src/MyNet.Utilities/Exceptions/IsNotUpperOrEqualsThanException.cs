// -----------------------------------------------------------------------
// <copyright file="IsNotUpperOrEqualsThanException.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MyNet.Utilities.Exceptions;

public class IsNotUpperOrEqualsThanException : TranslatableException
{
    public IsNotUpperOrEqualsThanException() { }

    public IsNotUpperOrEqualsThanException(string message, System.Exception innerException)
        : base(message, innerException) { }

    public IsNotUpperOrEqualsThanException(string message)
        : base(message) { }

    public IsNotUpperOrEqualsThanException(string property, object? target)
        : base($"the value of '{property}' must be upper than {target}.", "FieldXMustBeUpperOrEqualsThanYError", property, target) { }

    public IsNotUpperOrEqualsThanException(string? message, System.Exception? innerException, string resourceKey, params object?[] stringFormatParameters)
        : base(message, innerException, resourceKey, stringFormatParameters)
    {
    }

    public IsNotUpperOrEqualsThanException(System.Exception? innerException, string resourceKey, params object?[] stringFormatParameters)
        : base(innerException, resourceKey, stringFormatParameters)
    {
    }

    public IsNotUpperOrEqualsThanException(string? message, string resourceKey, params object?[] stringFormatParameters)
        : base(message, resourceKey, stringFormatParameters)
    {
    }

    public IsNotUpperOrEqualsThanException(string resourceKey, params object?[] stringFormatParameters)
        : base(resourceKey, stringFormatParameters)
    {
    }
}
