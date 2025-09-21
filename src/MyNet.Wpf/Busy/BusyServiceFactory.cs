﻿// -----------------------------------------------------------------------
// <copyright file="BusyServiceFactory.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using MyNet.UI.Loading;

namespace MyNet.Wpf.Busy;

public class BusyServiceFactory : IBusyServiceFactory
{
    public IBusyService Create() => new BusyService();
}
