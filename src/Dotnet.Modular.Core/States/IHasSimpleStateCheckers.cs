using System.Collections.Generic;

namespace Dotnet.Modular.Core.States
{
    public interface IHasSimpleStateCheckers<TState>
    where TState : IHasSimpleStateCheckers<TState>
    {
        List<ISimpleStateChecker<TState>> StateCheckers { get; }
    }
}
