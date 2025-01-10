using Dotnet.Modular.Core;
using Dotnet.Modular.Modules.Blazor.Layout.Core.Services;

namespace Dotnet.Modular.Modules.Blazor.Layout.Bootstrap.Services
{

    [Export(ExportType.Single, typeof(IDefaultLayoutComponentsProvider))]
    public class DefaultLayoutComponentsProvider : IDefaultLayoutComponentsProvider
    {
        public Type Sidebar => throw new NotImplementedException();

        public Type Header => throw new NotImplementedException();

        public Type Content => throw new NotImplementedException();
    }
}
