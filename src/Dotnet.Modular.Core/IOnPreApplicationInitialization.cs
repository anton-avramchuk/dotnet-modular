using System.Threading.Tasks;

namespace Dotnet.Modular.Core
{
    public interface IOnPreApplicationInitialization
    {
        Task OnPreApplicationInitializationAsync(ApplicationInitializationContext context);

        void OnPreApplicationInitialization(ApplicationInitializationContext context);
    }

}
