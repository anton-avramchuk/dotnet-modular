using Dotnet.Modular.Core;
using Dotnet.Modular.Modules.Data;
using Dotnet.Modular.Modules.Domain;

namespace Dotnet.Modular.Modules.EntityFramework;

[DependsOn(typeof(DataModule),typeof(DomainModule))]
public partial class EntityFrameworkModule : ModuleBase
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        RegisterServices(context.Services);
    }
}
