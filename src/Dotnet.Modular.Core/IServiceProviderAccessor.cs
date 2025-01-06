using System;

namespace Dotnet.Modular.Core;

public interface IServiceProviderAccessor
{
    IServiceProvider ServiceProvider { get; }
}

