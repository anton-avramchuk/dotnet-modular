using System;
using System.Collections.Generic;
using System.Linq;

namespace Dotnet.Modular.Core
{
    public class ModuleInitializer
    {
        private static readonly List<Type> modules = new List<Type>();
        public static void AddModule<TModule>() where TModule : IModule
        {
            modules.Add(typeof(TModule));
        }

        internal static IEnumerable<Type> Modules => modules.AsEnumerable();
    }
}
