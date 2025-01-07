using System;
using System.Collections.Generic;
using System.Reflection;

namespace Dotnet.Modular.Core.Abstractions;

public interface ICrmModuleDescriptor
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
