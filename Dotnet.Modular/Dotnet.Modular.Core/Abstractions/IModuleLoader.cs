using Microsoft.Extensions.DependencyInjection;
using System;

namespace Dotnet.Modular.Core.Abstractions;

public interface IModuleLoader
{

    ICrmModuleDescriptor[] LoadModules(
        IServiceCollection services,
        Type startupModuleType
    );
}
