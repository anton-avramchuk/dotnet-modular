﻿using Dotnet.Modular.Core.Extensions.Collections;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Dotnet.Modular.Core
{
    public class ServiceConfigurationContext
    {
        public IServiceCollection Services { get; }

        public IDictionary<string, object?> Items { get; }

        /// <summary>
        /// Gets/sets arbitrary named objects those can be stored during
        /// the service registration phase and shared between modules.
        ///
        /// This is a shortcut usage of the <see cref="Items"/> dictionary.
        /// Returns null if given key is not found in the <see cref="Items"/> dictionary.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object? this[string key]
        {
            get => Items.GetOrDefault(key);
            set => Items[key] = value;
        }

        public ServiceConfigurationContext(IServiceCollection services)
        {
            Services = services;
            Items = new Dictionary<string, object?>();
        }
    }
}
