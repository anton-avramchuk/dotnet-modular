namespace Dotnet.Modular.Core
{
    public abstract class ModuleBase : IModule
    {
        public abstract string Name { get; }

        public virtual void ConfigureServices(ServiceConfigurationContext context)
        {

        }
    }
}
