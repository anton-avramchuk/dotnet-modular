using Dotnet.Modular.Core;
using Dotnet.Modular.Modules.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet.Modular.Modules.EntityFramework.MsSql;

[DependsOn(typeof(EntityFrameworkModule))]
public partial class EntityFrameworkMsSqlModule : ModuleBase
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddEntityFrameworkSqlServer();
        RegisterServices(context.Services);
    }
}
