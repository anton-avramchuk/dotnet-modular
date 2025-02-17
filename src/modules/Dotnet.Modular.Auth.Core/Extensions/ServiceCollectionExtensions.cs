using Microsoft.Extensions.DependencyInjection;

namespace Dotnet.Modular.Auth.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAuth(this IServiceCollection services)
        {
            return services
                //.AddAuthorization()
                ;
        }
    }
}
