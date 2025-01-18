using Dotnet.Modular.Modules.Blazor.Layout.Core.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet.Modular.Modules.Blazor.Layout.Core.Components
{
    public partial class DefaultLayout : LayoutComponentBase
    {
        [Inject]
        private IDefaultLayoutComponentsProvider ComponentProvider { get; set; }
    }
}
