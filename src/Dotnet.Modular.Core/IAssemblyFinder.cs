﻿
using Dotnet.Modular.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace Dotnet.Modular.Core
{
    /// <summary>
    /// Used to get assemblies in the application.
    /// It may not return all assemblies, but those are related with modules.
    /// </summary>
    public interface IAssemblyFinder
    {
        IReadOnlyList<Assembly> Assemblies { get; }
    }

    public class AssemblyFinder : IAssemblyFinder
    {
        private readonly IModuleContainer _moduleContainer;

        private readonly Lazy<IReadOnlyList<Assembly>> _assemblies;

        public AssemblyFinder(IModuleContainer moduleContainer)
        {
            _moduleContainer = moduleContainer;

            _assemblies = new Lazy<IReadOnlyList<Assembly>>(FindAll, LazyThreadSafetyMode.ExecutionAndPublication);
        }

        public IReadOnlyList<Assembly> Assemblies => _assemblies.Value;

        public IReadOnlyList<Assembly> FindAll()
        {
            var assemblies = new List<Assembly>();

            foreach (var module in _moduleContainer.Modules)
            {
                assemblies.AddRange(module.AllAssemblies);
            }

            return assemblies.Distinct().ToList();
        }
    }


}
