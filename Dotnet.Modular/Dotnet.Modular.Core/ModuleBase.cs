namespace Dotnet.Modular.Core
{
    public abstract class ModuleBase : IModule
    {
        public abstract string Name { get; }

        public void ConfigureServices(ServiceConfigurationContext context)
        {

        }
        public Task ConfigureServicesAsync(ServiceConfigurationContext context)
        {
            return Task.CompletedTask;
        }
    }
}
