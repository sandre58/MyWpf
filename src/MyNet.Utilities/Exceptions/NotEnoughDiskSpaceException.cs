// -----------------------------------------------------------------------
// <copyright file="NotEnoughDiskSpaceException.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace MyNet.Utilities.Exceptions;

[Serializable]
public class NotEnoughDiskSpaceException : TranslatableException
{
    public NotEnoughDiskSpaceException()
        : base("Not enough disk space.", "NotEnoughSpaceDisk") { }

    public NotEnoughDiskSpaceException(string message)
        : base(message) { }

    public NotEnoughDiskSpaceException(string message, Exception innerException)
        : base(message, innerException) { }

    public NotEnoughDiskSpaceException(string? message, Exception? innerException, string resourceKey, params object?[] stringFormatParameters)
        : base(message, innerException, resourceKey, stringFormatParameters)
    {
    }

    public NotEnoughDiskSpaceException(Exception? innerException, string resourceKey, params object?[] stringFormatParameters)
        : base(innerException, resourceKey, stringFormatParameters)
    {
    }

    public NotEnoughDiskSpaceException(string? message, string resourceKey, params object?[] stringFormatParameters)
        : base(message, resourceKey, stringFormatParameters)
    {
    }

    public NotEnoughDiskSpaceException(string resourceKey, params object?[] stringFormatParameters)
        : base(resourceKey, stringFormatParameters)
    {
    }
}
