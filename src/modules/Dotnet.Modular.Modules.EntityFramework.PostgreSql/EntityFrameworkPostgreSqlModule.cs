using Dotnet.Modular.Core;
using Dotnet.Modular.Modules.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet.Modular.Modules.EntityFramework.PostgreSql;

[DependsOn(typeof(EntityFrameworkModule),typeof(DataModule))]
public partial class EntityFrameworkPostgreSqlModule : ModuleBase
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddEntityFrameworkNpgsql();
        RegisterServices(context.Services);
    }
}
