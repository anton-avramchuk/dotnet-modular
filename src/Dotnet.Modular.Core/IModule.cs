
namespace Dotnet.Modular.Core
{
    public interface IModule
    {
        string Name { get; }

        void ConfigureServices(ServiceConfigurationContext context);
    }
}
