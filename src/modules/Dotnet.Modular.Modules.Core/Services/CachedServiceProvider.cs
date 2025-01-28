using Dotnet.Modular.Core;
using Dotnet.Modular.Core.Abstractions.DependencyInjection;

namespace Dotnet.Modular.Modules.Core.Services
{
    [Export(ExportType.Scope, typeof(ICachedServiceProvider))]
    public class CachedServiceProvider :
    CachedServiceProviderBase,
    ICachedServiceProvider
    {
        public CachedServiceProvider(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }
    }
}
