// -----------------------------------------------------------------------
// <copyright file="ExtendedObservableCollection.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using DynamicData;
using DynamicData.Binding;
using MyNet.Utilities.Collections;

namespace MyNet.Observable.Collections;

public class ExtendedObservableCollection<T> : OptimizedObservableCollection<T>, IObservableCollection<T>, IExtendedList<T>
{
    public ExtendedObservableCollection() { }

    public ExtendedObservableCollection(IList<T> list)
        : base(list) { }

    public ExtendedObservableCollection(IEnumerable<T> collection)
        : base(collection) { }
}
