namespace Dotnet.Modular.Core
{
    public interface IModule
    {
        string Name { get; }

        Task ConfigureServicesAsync(ServiceConfigurationContext context);

        void ConfigureServices(ServiceConfigurationContext context);
    }
}
