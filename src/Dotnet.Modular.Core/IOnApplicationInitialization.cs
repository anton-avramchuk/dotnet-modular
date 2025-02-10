using System.Threading.Tasks;

namespace Dotnet.Modular.Core
{
    public interface IOnApplicationInitialization
    {
        Task OnApplicationInitializationAsync(ApplicationInitializationContext context);

        void OnApplicationInitialization(ApplicationInitializationContext context);
    }

}
