// -----------------------------------------------------------------------
// <copyright file="HttpException.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace MyNet.Http;

public class HttpException : Exception
{
    public HttpException() { }

    public HttpException(string message)
        : base(message) { }

    public HttpException(string message, Exception? exception)
        : base(message, exception) { }
}
