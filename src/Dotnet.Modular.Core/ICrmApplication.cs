using Dotnet.Modular.Core.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Dotnet.Modular.Core;

public interface ICrmApplication :
    IModuleContainer,
    IApplicationInfoAccessor,
    IDisposable
{
    /// <summary>
    /// Type of the startup (entrance) module of the application.
    /// </summary>
    Type StartupModuleType { get; }

    /// <summary>
    /// List of all service registrations.
    /// Can not add new services to this collection after application initialize.
    /// </summary>
    IServiceCollection Services { get; }

    /// <summary>
    /// Reference to the root service provider used by the application.
    /// This can not be used before initializing  the application.
    /// </summary>
    IServiceProvider ServiceProvider { get; }

    void Shutdown();
}