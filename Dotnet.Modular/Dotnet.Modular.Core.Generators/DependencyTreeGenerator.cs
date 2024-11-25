using Crm.Core.Modularity;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Dotnet.Modular.Core.Generators
{
    [Generator]
    public class DependencyTreeGenerator : IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            // 1. Извлекаем синтаксические узлы классов
            var classDeclarations = context.SyntaxProvider
                .CreateSyntaxProvider(
                    predicate: (node, _) => node is ClassDeclarationSyntax,
                    transform: (ctx, _) => ctx.Node as ClassDeclarationSyntax)
                .Where(classDecl => classDecl != null);

            // 2. Получаем информацию о типах с семантической моделью
            var moduleSymbols = classDeclarations
                .Select((classDecl, _) => classDecl)
                .Combine(context.CompilationProvider)
                .Select((tuple, ct) =>
                {
                    var (classDecl, compilation) = tuple;
                    var semanticModel = compilation.GetSemanticModel(classDecl.SyntaxTree);
                    var namedType = semanticModel.GetDeclaredSymbol(classDecl, ct) as INamedTypeSymbol;
                    return namedType;
                })
                .Where(symbol => symbol != null);

            var moduleData = moduleSymbols
            .Select((symbol, _) => AnalyzeModule(symbol!))
            .Where(static data => data != null);

            // 4. Генерируем код
            context.RegisterSourceOutput(moduleData.Collect(), GenerateCode);

        }

        private void GenerateCode(SourceProductionContext context, ImmutableArray<ModuleData> array)
        {
            
        }

        private static string DependsOnAttributeFullName = typeof(DependsOnAttribute).FullName;

        private static string BootstrapperAttributeFullName = typeof(BootstraperAttribute).FullName;


        private static string ModuleFullName = typeof(IModule).FullName;



        private static ModuleData? AnalyzeModule(INamedTypeSymbol symbol)
        {
            // Проверяем атрибуты и зависимости
            var dependsOnAttribute = symbol.GetAttributes()
                .FirstOrDefault(attr => attr.AttributeClass?.ToDisplayString() == DependsOnAttributeFullName);

            var bootstrapperAttribute = symbol.GetAttributes()
                .FirstOrDefault(attr => attr.AttributeClass?.ToDisplayString() == BootstrapperAttributeFullName);

            var dependencies = dependsOnAttribute?.ConstructorArguments
                .SelectMany(arg => arg.Values)
                .Select(value => value.Value as INamedTypeSymbol)
                .Where(dep => dep != null)
                .ToList();

            if (bootstrapperAttribute != null)
            {
                return new ModuleData(symbol, dependencies ?? new List<INamedTypeSymbol>(), IsBootstrapper: true);
            }
            else if (symbol.AllInterfaces.Any(i => i.ToDisplayString() == ModuleFullName))
            {
                return new ModuleData(symbol, dependencies ?? new List<INamedTypeSymbol>(), IsBootstrapper: false);
            }

            return null;
        }


        private record ModuleData(INamedTypeSymbol Module, List<INamedTypeSymbol> Dependencies, bool IsBootstrapper);
    }

}
