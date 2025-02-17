using Dotnet.Modular.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet.Modular.Modules.EntityFramework.Sqlite;

[DependsOn(typeof(EntityFrameworkModule))]
public partial class EntityFrameworkSqliteModule : ModuleBase
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        //Configure<AbpEfCoreGlobalFilterOptions>(options =>
        //{
        //    options.UseDbFunction = true;
        //});

        context.Services.AddEntityFrameworkSqlite();
        RegisterServices(context.Services);

    }
}
