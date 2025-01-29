using Dotnet.Modular.Core;
using Dotnet.Modular.Modules.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet.Modular.Modules.EntityFramework.MsSql;

[DependsOn(typeof(EntityFrameworkModule),typeof(DataModule))]
public partial class EntityFrameworkMsSqlModule : ModuleBase
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddEntityFrameworkSqlServer();
        RegisterServices(context.Services);
    }
}
