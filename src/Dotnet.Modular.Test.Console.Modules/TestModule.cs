using Crm.Core.Modularity;
using Dotnet.Modular.Core;

namespace Dotnet.Modular.Test.Console.Modules
{
    [DependsOn(typeof(TestModule2), typeof(TestModule3))]
    public class TestModule : IModule
    {
        public string Name => nameof(TestModule);

        public void ConfigureServices(ServiceConfigurationContext context)
        {
            throw new NotImplementedException();
        }
    }


    public class TestModule2 : ModuleBase
    {
        public override string Name => "TestModule2";
    }

    [DependsOn(typeof(TestModule4))]
    public class TestModule3 : ModuleBase
    {
        public override string Name => "TestModule3";
    }
    [DependsOn(typeof(TestModule3))]
    public class TestModule4 : ModuleBase
    {
        public override string Name => "TestModule4";
    }
}
