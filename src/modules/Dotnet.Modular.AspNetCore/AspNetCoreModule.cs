using Dotnet.Modular.Core;
using Dotnet.Modular.Core.Extensions.DependencyInjection;

namespace Dotnet.Modular.AspNetCore;

public partial class AspNetCoreModule : ModuleBase
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        RegisterServices(context.Services);
        context.Services.AddHttpContextAccessor();
        context.Services.AddObjectAccessor<IApplicationBuilder>();
        context.Services.AddObjectAccessor<IEndpointRouteBuilder>();
    }
}
