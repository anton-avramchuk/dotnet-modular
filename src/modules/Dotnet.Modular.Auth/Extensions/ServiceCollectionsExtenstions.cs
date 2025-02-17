using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet.Modular.Auth.Extensions
{
    public static class ServiceCollectionsExtenstions
    {
        public static IServiceCollection AddCookieAuth(this IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie();

            services.AddAuthorization();

            return services;
        }
    }
}
