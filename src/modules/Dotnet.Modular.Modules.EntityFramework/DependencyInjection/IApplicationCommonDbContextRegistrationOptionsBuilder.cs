using Microsoft.Extensions.DependencyInjection;

namespace Dotnet.Modular.Modules.EntityFramework.DependencyInjection;

public interface IApplicationCommonDbContextRegistrationOptionsBuilder
{
    IServiceCollection Services { get; }
}