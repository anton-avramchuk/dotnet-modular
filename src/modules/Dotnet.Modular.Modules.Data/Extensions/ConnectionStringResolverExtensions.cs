using Dotnet.Modular.Modules.Data.Abstractions;
using Dotnet.Modular.Modules.Data.Attributes;

namespace Dotnet.Modular.Modules.Data.Extensions;

public static class ConnectionStringResolverExtensions
{
    public static Task<string> ResolveAsync<T>(this IConnectionStringResolver resolver)
    {
        return resolver.ResolveAsync(typeof(T));
    }




    public static Task<string> ResolveAsync(this IConnectionStringResolver resolver, Type type)
    {
        return resolver.ResolveAsync(ConnectionStringNameAttribute.GetConnStringName(type));
    }
}
