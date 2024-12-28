using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using System;
using System.Linq;

namespace Dotnet.Modular.Core.Generators
{
    public abstract class BaseIncrementalGenerator : IIncrementalGenerator
    {

        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            var isEnabled = context.AnalyzerConfigOptionsProvider
                .Select((options, _) => IsGeneratorEnabled(options));

            context.RegisterSourceOutput(isEnabled, (ctx, enabled) =>
            {
                if (!enabled)
                {
                    return;
                }

                Execute(ctx, context);
            });
        }

        protected abstract void Execute(SourceProductionContext context, IncrementalGeneratorInitializationContext initContext);

        private bool IsGeneratorEnabled(AnalyzerConfigOptionsProvider optionsProvider)
        {
            var options = optionsProvider.GlobalOptions;

            if (options.TryGetValue("build_property.EnabledGenerators", out var enabledGeneratorsRaw))
            {
                if (string.IsNullOrEmpty(enabledGeneratorsRaw))
                    return true;
                var generators = enabledGeneratorsRaw.ToLowerInvariant().Split(';');
                return generators.Contains(Name);
            }

            // Если свойства нет, генератор включен по умолчанию
            return true;
        }

        public virtual string Name => GetType().Name.ToLowerInvariant();
    }



}
