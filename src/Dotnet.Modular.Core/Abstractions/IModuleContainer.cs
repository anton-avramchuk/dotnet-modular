using System.Collections.Generic;

namespace Dotnet.Modular.Core.Abstractions;

public interface IModuleContainer
{

    IReadOnlyList<IModuleDescriptor> Modules { get; }
}
