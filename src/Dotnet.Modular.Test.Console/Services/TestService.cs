using Dotnet.Modular.Core;
using Dotnet.Modular.Test.Console.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet.Modular.Test.Console.Services
{
    [Export(ExportType.Single,typeof(ITestInterface),typeof(ITestInterface2))]
    public class TestService : ITestInterface, ITestInterface2
    {
    }
}
