using System;

namespace Dotnet.Modular.Core.Abstractions;

public interface IDependedTypesProvider
{

    Type[] GetDependedTypes();
}
