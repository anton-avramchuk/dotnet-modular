namespace Dotnet.Modular.Core
{
    public interface IPostConfigureServices
    {
        

        void PostConfigureServices(ServiceConfigurationContext context);
    }
}
