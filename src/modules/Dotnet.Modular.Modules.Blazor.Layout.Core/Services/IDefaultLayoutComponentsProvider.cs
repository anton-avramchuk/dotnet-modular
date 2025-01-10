namespace Dotnet.Modular.Modules.Blazor.Layout.Core.Services
{
    public interface IDefaultLayoutComponentsProvider
    {
        Type Sidebar { get; }

        Type Header{ get; }

        Type Content { get; }
    }
}
