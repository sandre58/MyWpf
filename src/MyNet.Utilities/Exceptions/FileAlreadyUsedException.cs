// -----------------------------------------------------------------------
// <copyright file="FileAlreadyUsedException.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace MyNet.Utilities.Exceptions;

[Serializable]
public class FileAlreadyUsedException : TranslatableException
{
    public FileAlreadyUsedException() { }

    public FileAlreadyUsedException(string message, Exception innerException)
        : base(message, innerException) { }

    public FileAlreadyUsedException(string filename)
        : base("File {0} is used by another process", "FileXAlreadyUsedError", filename) { }

    public FileAlreadyUsedException(string? message, Exception? innerException, string resourceKey, params object?[] stringFormatParameters)
        : base(message, innerException, resourceKey, stringFormatParameters)
    {
    }

    public FileAlreadyUsedException(Exception? innerException, string resourceKey, params object?[] stringFormatParameters)
        : base(innerException, resourceKey, stringFormatParameters)
    {
    }

    public FileAlreadyUsedException(string? message, string resourceKey, params object?[] stringFormatParameters)
        : base(message, resourceKey, stringFormatParameters)
    {
    }

    public FileAlreadyUsedException(string resourceKey, params object?[] stringFormatParameters)
        : base(resourceKey, stringFormatParameters)
    {
    }
}
