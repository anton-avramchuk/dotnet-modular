using Dotnet.Modular.Modules.Navigation;

namespace Dotnet.Modular.Modules.Blazor.Layout.Services
{
    public interface IMenuItemTransformer
    {
        void Transform(IApplicationMenuItem menuItem);
    }
}
