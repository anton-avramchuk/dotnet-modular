using System;

namespace Dotnet.Modular.Core.Abstractions;

public interface IModuleDescriptor
{
    /// <summary>
    /// Type of the module class.
    /// </summary>
    Type Type { get; }

    
    /// <summary>
    /// The instance of the module class (singleton).
    /// </summary>
    IModule Instance { get; }

}
