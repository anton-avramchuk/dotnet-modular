using Microsoft.Extensions.DependencyInjection;
using System;

namespace Dotnet.Modular.Core.Abstractions;

public interface IModuleLoader
{

    IModuleDescriptor[] LoadModules(
        IServiceCollection services,
        Type startupModuleType
    );
}
