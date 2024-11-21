using Crm.Core.Modularity;
using Dotnet.Modular.Core;

namespace Dotnet.Modular.Test.Console.Modules
{
    [DependsOn(typeof(ModuleB), typeof(ModuleC))]
    public class ModuleA : ModuleBase
    {
        public override string Name => nameof(ModuleA);
    }
    [DependsOn(typeof(ModuleC))]
    public class ModuleB : ModuleBase
    {
        public override string Name => nameof(ModuleB);
    }

    public class ModuleC : ModuleBase
    {
        public override string Name => nameof(ModuleC);
    }


    [DependsOn(typeof(ModuleA), typeof(ModuleC))]
    [Bootstraper]
    public class BootstraperModule : ModuleBase
    {
        public override string Name => nameof(BootstraperModule);
    }
}
