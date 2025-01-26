using System.Threading.Tasks;

namespace Dotnet.Modular.Core.States
{
    public interface ISimpleStateChecker<TState>
    where TState : IHasSimpleStateCheckers<TState>
    {
        Task<bool> IsEnabledAsync(SimpleStateCheckerContext<TState> context);
    }
}
