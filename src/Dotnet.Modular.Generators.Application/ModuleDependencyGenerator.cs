using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dotnet.Modular.Generators.Application
{
    [Generator]
    public class ModuleDependencyGenerator : IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            var modulesWithDependencies = context.SyntaxProvider
                .CreateSyntaxProvider(
                    predicate: static (node, _) => IsClassDeclaration(node),
                    transform: static (context, _) => GetModuleWithDependencies(context))
                .Where(static module => module is not null)
                .Collect();
        }

        private static bool IsClassDeclaration(SyntaxNode node)
        {
            return node is Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax;
        }

        private static (INamedTypeSymbol module, List<string> dependencies)? GetModuleWithDependencies(GeneratorSyntaxContext context)
        {
            var classDeclaration = (Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax)context.Node;
            var semanticModel = context.SemanticModel;

            var classSymbol = semanticModel.GetDeclaredSymbol(classDeclaration) as INamedTypeSymbol;
            if (classSymbol is null || !classSymbol.AllInterfaces.Any(i => i.Name == "IModule"))
                return null;

            var dependOnAttributes = classSymbol.GetAttributes()
                .Where(attr => attr.AttributeClass?.Name == "DependOnAttribute")
                .ToList();

            var dependencies = dependOnAttributes
                .SelectMany(attr => attr.ConstructorArguments[0].Values)
                .Select(arg => arg.Value?.ToString() ?? string.Empty)
                .ToList();

            return (classSymbol, dependencies);
        }

    }
}
