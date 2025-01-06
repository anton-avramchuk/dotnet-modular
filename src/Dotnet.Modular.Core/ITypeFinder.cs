
using System.Collections.Generic;
using System;
using System.Threading;

namespace Dotnet.Modular.Core
{
    /// <summary>
    /// Used to get types in the application.
    /// It may not return all types, but those are related with modules.
    /// </summary>
    public interface ITypeFinder
    {
        IReadOnlyList<Type> Types { get; }
    }


    public class TypeFinder : ITypeFinder
    {
        private readonly IAssemblyFinder _assemblyFinder;

        private readonly Lazy<IReadOnlyList<Type>> _types;

        public TypeFinder(IAssemblyFinder assemblyFinder)
        {
            _assemblyFinder = assemblyFinder;

            _types = new Lazy<IReadOnlyList<Type>>(FindAll, LazyThreadSafetyMode.ExecutionAndPublication);
        }

        public IReadOnlyList<Type> Types => _types.Value;

        private IReadOnlyList<Type> FindAll()
        {
            var allTypes = new List<Type>();

            foreach (var assembly in _assemblyFinder.Assemblies)
            {
                try
                {
                    var typesInThisAssembly = AssemblyHelper.GetAllTypes(assembly);

                    if (!typesInThisAssembly.Any())
                    {
                        continue;
                    }

                    allTypes.AddRange(typesInThisAssembly.Where(type => type != null));
                }
                catch
                {
                    //TODO: Trigger a global event?
                }
            }

            return allTypes;
        }
    }

}
