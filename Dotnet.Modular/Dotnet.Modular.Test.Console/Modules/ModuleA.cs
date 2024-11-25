using Crm.Core.Modularity;
using Dotnet.Modular.Core;

namespace Dotnet.Modular.Test.Console.Modules
{
    [DependsOn(typeof(ModuleB), typeof(ModuleC))]
    public class ModuleA : ModuleBase
    {
        public override string Name => nameof(ModuleA);
    }
    [DependsOn(typeof(ModuleC), typeof(TestModule))]
    public class ModuleB : ModuleBase
    {
        public override string Name => nameof(ModuleB);
    }

    public class ModuleC : ModuleBase
    {
        public ModuleC(string test)
        {
            Test = test;
        }
        public override string Name => nameof(ModuleC);

        public string Test { get; }
    }


    [DependsOn(typeof(ModuleA), typeof(ModuleC))]
    [Bootstraper]
    public class BootstraperModule : ModuleBase
    {
        public override string Name => nameof(BootstraperModule);
    }
}
