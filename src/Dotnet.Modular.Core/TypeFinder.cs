
using System.Collections.Generic;
using System;
using System.Threading;

namespace Dotnet.Modular.Core
{
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
            throw new NotImplementedException();

            //var allTypes = new List<Type>();

            //foreach (var assembly in _assemblyFinder.Assemblies)
            //{
            //    try
            //    {
            //        var typesInThisAssembly = AssemblyHelper.GetAllTypes(assembly);

            //        if (!typesInThisAssembly.Any())
            //        {
            //            continue;
            //        }

            //        allTypes.AddRange(typesInThisAssembly.Where(type => type != null));
            //    }
            //    catch
            //    {
            //        //TODO: Trigger a global event?
            //    }
            //}

            //return allTypes;
        }
    }

}
