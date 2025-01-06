
namespace Dotnet.Modular.Core
{
    public interface IObjectAccessor<out T>
    {
        T? Value { get; }
    }
}
