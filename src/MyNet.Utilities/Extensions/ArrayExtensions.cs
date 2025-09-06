// -----------------------------------------------------------------------
// <copyright file="ArrayExtensions.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace MyNet.Utilities;
#pragma warning restore IDE0130 // Namespace does not match folder structure

/// <summary>
/// Provides extension methods for multidimensional arrays.
/// </summary>
public static class ArrayExtensions
{
    /// <summary>
    /// Iterates over every element of the array invoking the provided action with the array and the current position indices.
    /// </summary>
    /// <param name="array">The array to iterate.</param>
    /// <param name="action">An action invoked for each element; receives the array and the index positions.</param>
    public static void ForEach(this Array array, Action<Array, int[]> action)
    {
        if (array.LongLength == 0)
            return;

        var walker = new ArrayTraverse(array);
        do
            action(array, walker.Position);
        while (walker.Step());
    }

    /// <summary>
    /// Helper that walks through positions of a multidimensional array.
    /// </summary>
    internal sealed class ArrayTraverse
    {
        private readonly int[] _maxLengths;

        public ArrayTraverse(Array array)
        {
            _maxLengths = new int[array.Rank];
            for (var i = 0; i < array.Rank; ++i)
                _maxLengths[i] = array.GetLength(i) - 1;

            Position = new int[array.Rank];
        }

        /// <summary>
        /// Gets the current position indices of the walker.
        /// </summary>
        public int[] Position { get; }

        /// <summary>
        /// Advances the walker to the next position.
        /// </summary>
        /// <returns><c>true</c> if advanced; otherwise <c>false</c> when end reached.</returns>
        public bool Step()
        {
            for (var i = 0; i < Position.Length; ++i)
            {
                if (Position[i] >= _maxLengths[i]) continue;

                Position[i]++;
                for (var j = 0; j < i; j++)
                    Position[j] = 0;

                return true;
            }

            return false;
        }
    }
}
