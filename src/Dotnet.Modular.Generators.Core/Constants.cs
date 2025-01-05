using Crm.Core.Modularity;
using Dotnet.Modular.Core;

namespace Dotnet.Modular.Generators.Core
{
    public static class Constants
    {
        public static string BoostraperAttribiteName = typeof(BootstraperAttribute).FullName;

        public static string ModuleTypeName = typeof(IModule).FullName;

        public static string ExportAttributeName=typeof(ExportAttribute).FullName;


        public static string DependsOnAttributeName = typeof(DependsOnAttribute).FullName;
    }
}
