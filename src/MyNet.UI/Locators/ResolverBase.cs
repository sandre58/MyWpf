// -----------------------------------------------------------------------
// <copyright file="ResolverBase.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using MyNet.Utilities.Helpers;

namespace MyNet.UI.Locators;

/// <summary>
/// Base class for all resolvers. Implements shared logic for type resolution using naming conventions and cache.
/// Optimized for single result per key and argument validation.
/// </summary>
public abstract class ResolverBase : IResolver
{
    // Optimized cache: single result per key
    private readonly Dictionary<string, string> _cache = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="ResolverBase"/> class.
    /// </summary>
    protected ResolverBase() => NamingConventions = [.. GetDefaultNamingConventionsInternal()];

    /// <summary>
    /// Gets the naming conventions to use to locate types.
    /// </summary>
    public IList<string> NamingConventions { get; }

    private IEnumerable<string> GetDefaultNamingConventionsInternal() => GetDefaultNamingConventions();

    /// <summary>
    /// Registers the specified type in the local cache. This cache will also be used by the <see cref="Resolve"/> method.
    /// </summary>
    /// <param name="valueToResolve">The value to resolve.</param>
    /// <param name="resolvedValue">The resolved value.</param>
    /// <exception cref="ArgumentException">The <paramref name="valueToResolve"/> or <paramref name="resolvedValue"/> is <c>null</c> or whitespace.</exception>
    protected void Register(string valueToResolve, string resolvedValue)
    {
        if (string.IsNullOrWhiteSpace(valueToResolve))
            throw new ArgumentException("Value to resolve cannot be null or whitespace.", nameof(valueToResolve));
        if (string.IsNullOrWhiteSpace(resolvedValue))
            throw new ArgumentException("Resolved value cannot be null or whitespace.", nameof(resolvedValue));
        AddItemToCache(valueToResolve, resolvedValue);
    }

    /// <summary>
    /// Resolves the specified values. Uses both <see cref="NamingConventions"/> and manually registered values.
    /// </summary>
    /// <param name="valueToResolve">The value to resolve.</param>
    /// <returns>A list with the resolved value (empty if not found).</returns>
    protected virtual IEnumerable<string> ResolveValues(string valueToResolve)
    {
        if (string.IsNullOrWhiteSpace(valueToResolve))
            throw new ArgumentException("Value to resolve cannot be null or whitespace.", nameof(valueToResolve));
        lock (_cache)
        {
            if (_cache.TryGetValue(valueToResolve, out var existingValue) && !string.IsNullOrEmpty(existingValue))
            {
                return [existingValue];
            }

            Type? resolvedType = null;
            var assembly = TypeHelper.GetAssemblyName(valueToResolve);
            var typeToResolveName = TypeHelper.GetTypeName(valueToResolve);

            foreach (var namingConvention in NamingConventions)
            {
                var resolvedTypeName = ResolveNamingConvention(assembly, typeToResolveName, namingConvention);
                resolvedType = TypeHelper.GetTypeFrom(resolvedTypeName);
                if (resolvedType is not null)
                {
                    break;
                }
            }

            var fullResolvedTypeName = (resolvedType?.AssemblyQualifiedName != null) ? TypeHelper.GetTypeNameWithAssembly(resolvedType.AssemblyQualifiedName) : null;

            if (string.IsNullOrEmpty(fullResolvedTypeName))
                return [];
            _cache[valueToResolve] = fullResolvedTypeName;
            return [fullResolvedTypeName];
        }
    }

    /// <summary>
    /// Resolves the specified value. Uses both <see cref="NamingConventions"/> and manually registered values.
    /// </summary>
    /// <param name="valueToResolve">The value to resolve.</param>
    /// <returns>The resolved value or <c>null</c> if not found.</returns>
    protected virtual string? Resolve(string valueToResolve)
    {
        var values = ResolveValues(valueToResolve);
        return values.LastOrDefault();
    }

    /// <summary>
    /// Gets the item from the cache.
    /// </summary>
    /// <param name="valueToResolve">The value to resolve.</param>
    /// <returns>The item or <c>null</c> if not found.</returns>
    protected string? GetItemFromCache(string valueToResolve)
    {
        if (string.IsNullOrWhiteSpace(valueToResolve))
            throw new ArgumentException("Value to resolve cannot be null or whitespace.", nameof(valueToResolve));
        lock (_cache)
        {
            return _cache.TryGetValue(valueToResolve, out var value) ? value : null;
        }
    }

    /// <summary>
    /// Adds the item to the cache.
    /// </summary>
    /// <param name="valueToResolve">The value to resolve.</param>
    /// <param name="resolvedValue">The resolved value.</param>
    protected void AddItemToCache(string valueToResolve, string resolvedValue)
    {
        lock (_cache)
        {
            _cache[valueToResolve] = resolvedValue;
        }
    }

    /// <summary>
    /// Clears the cache of the resolved naming conventions.
    /// </summary>
    public void ClearCache()
    {
        lock (_cache)
        {
            _cache.Clear();
        }
    }

    /// <summary>
    /// Resolves a single naming convention.
    /// </summary>
    /// <param name="assembly">The assembly name.</param>
    /// <param name="typeToResolveName">The full type name of the type to resolve.</param>
    /// <param name="namingConvention">The naming convention to use for resolving.</param>
    /// <returns>The resolved naming convention.</returns>
    protected abstract string ResolveNamingConvention(string assembly, string typeToResolveName, string namingConvention);

    /// <summary>
    /// Gets the default naming conventions.
    /// </summary>
    /// <returns>An enumerable of default naming conventions.</returns>
    protected abstract IEnumerable<string> GetDefaultNamingConventions();
}
