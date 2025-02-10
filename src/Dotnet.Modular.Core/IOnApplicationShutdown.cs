using System.Threading.Tasks;

namespace Dotnet.Modular.Core
{
    public interface IOnApplicationShutdown
    {
        Task OnApplicationShutdownAsync(ApplicationShutdownContext context);

        void OnApplicationShutdown(ApplicationShutdownContext context);
    }

}
