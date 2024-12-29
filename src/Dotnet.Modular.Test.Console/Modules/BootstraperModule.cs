using Crm.Core.Modularity;
using Dotnet.Modular.Core;

namespace Dotnet.Modular.Test.Console.Modules
{


    [Bootstraper]
    [DependsOn(typeof(TestModule))]
    public partial class BootstraperModule : ModuleBase
    {
        public override string Name => nameof(BootstraperModule);

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            RegisterServices(context.Services);
        }
    }

}
