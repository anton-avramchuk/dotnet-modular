using Dotnet.Modular.Core;

namespace Dotnet.Modular.Test.Console.Modules
{
    public class TestModule : IModule
    {
        public string Name => nameof(TestModule);

        public void ConfigureServices(ServiceConfigurationContext context)
        {
            throw new NotImplementedException();
        }

        public Task ConfigureServicesAsync(ServiceConfigurationContext context)
        {
            throw new NotImplementedException();
        }
    }
}
