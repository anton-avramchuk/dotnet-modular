using System;
using System.Threading.Tasks;

namespace Dotnet.Modular.Core;

public interface ICrmApplicationWithExternalServiceProvider : ICrmApplication
{
    /// <summary>
    /// Sets the service provider, but not initializes the modules.
    /// </summary>
    void SetServiceProvider(IServiceProvider serviceProvider);

    /// <summary>
    /// Sets the service provider and initializes all the modules.
    /// If <see cref="SetServiceProvider"/> was called before, the same
    /// <see cref="serviceProvider"/> instance should be passed to this method.
    /// </summary>
    Task InitializeAsync(IServiceProvider serviceProvider);

    /// <summary>
    /// Sets the service provider and initializes all the modules.
    /// If <see cref="SetServiceProvider"/> was called before, the same
    /// <see cref="serviceProvider"/> instance should be passed to this method.
    /// </summary>
    void Initialize(IServiceProvider serviceProvider);
}
