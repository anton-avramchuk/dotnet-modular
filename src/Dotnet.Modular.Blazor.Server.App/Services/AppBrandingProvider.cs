using Dotnet.Modular.Core;
using Dotnet.Modular.Modules.UI.Services.Abstractions;

namespace Dotnet.Modular.Blazor.Server.App.Services
{
    [Export(ExportType.Single,typeof(IBrandingProvider))]
    public class AppBrandingProvider : IBrandingProvider
    {
        public string AppName => "Test App";
    }
}
