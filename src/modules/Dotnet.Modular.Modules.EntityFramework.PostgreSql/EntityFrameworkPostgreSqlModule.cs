using Dotnet.Modular.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet.Modular.Modules.EntityFramework.PostgreSql;

[DependsOn(typeof(EntityFrameworkModule))]
public partial class EntityFrameworkPostgreSqlModule : ModuleBase
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddEntityFrameworkNpgsql();
        RegisterServices(context.Services);
    }
}
