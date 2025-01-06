namespace Dotnet.Modular.Core
{
    public interface IPreConfigureServices
    {
        

        void PreConfigureServices(ServiceConfigurationContext context);
    }
}
