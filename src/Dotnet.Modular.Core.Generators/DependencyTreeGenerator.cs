using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;

namespace Dotnet.Modular.Core.Generators
{
    [Generator]
    public class DependencyTreeGenerator : IIncrementalGenerator
    {
        private readonly ILogger logger;

        public DependencyTreeGenerator(ILogger logger)
        {
            this.logger = logger;
        }

        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            
        }

        

    }



}
