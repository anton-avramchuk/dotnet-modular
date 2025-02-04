using System;

namespace Dotnet.Modular.Core;

public interface IDependedTypesProvider
{
    Type[] GetDependedTypes();
}
