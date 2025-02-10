using System.Threading.Tasks;

namespace Dotnet.Modular.Core
{
    public interface IOnPostApplicationInitialization
    {
        Task OnPostApplicationInitializationAsync(ApplicationInitializationContext context);

        void OnPostApplicationInitialization(ApplicationInitializationContext context);
    }

}
