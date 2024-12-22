using System.Collections.Generic;

namespace Dotnet.Modular.Core.Abstractions;

public interface IModuleContainer
{

    IReadOnlyList<ICrmModuleDescriptor> Modules { get; }
}
