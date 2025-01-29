using Dotnet.Modular.Core;
using Dotnet.Modular.Modules.Data;

namespace Dotnet.Modular.Modules.Domain;

[DependsOn(typeof(DataModule))]
public partial class DomainModule : ModuleBase
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        RegisterServices(context.Services);
    }
}
