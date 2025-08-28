// -----------------------------------------------------------------------
// <copyright file="WebApiException.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace MyNet.Http;

public class WebApiException : Exception
{
    public object? Exception { get; }

    public WebApiException()
    {
    }

    public WebApiException(object? exception)
        : base(exception?.ToString()) => Exception = exception;

    protected WebApiException(string message)
        : base(message) { }

    protected WebApiException(string message, Exception? exception)
        : base(message, exception) { }
}
