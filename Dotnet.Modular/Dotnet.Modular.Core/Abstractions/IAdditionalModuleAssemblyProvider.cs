using System.Reflection;

namespace Dotnet.Modular.Core.Abstractions;

public interface IAdditionalModuleAssemblyProvider
{
    Assembly[] GetAssemblies();
}