using Crm.Core.Modularity;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dotnet.Modular.Core.Generators
{
    [Generator]
    public class BootstraperGenerator : IIncrementalGenerator
    {
        private static string BoostraperAttribiteName=typeof(BootstraperAttribute).FullName;

        private static string ModuleTypeName = typeof(IModule).FullName;


        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            // Фильтруем классы с атрибутом BootstrapperAttribute
            var classesWithAttribute = context.SyntaxProvider
                .CreateSyntaxProvider(
                    predicate: static (node, _) => IsClassWithAttribute(node),
                    transform: static (context, _) => GetClassSymbol(context))
                .Where(static symbol => symbol is not null)
                .Collect(); // Собираем все найденные символы

            // Обрабатываем найденные классы
            context.RegisterSourceOutput(classesWithAttribute, static (context, classSymbols) =>
            {
                if (classSymbols.IsDefaultOrEmpty)
                {
                    // Если классов нет, добавляем диагностическое сообщение
                    ReportError(context, "Не найден класс с атрибутом BootstrapperAttribute.");
                    return;
                }

                if (classSymbols.Length > 1)
                {
                    // Если классов больше одного, добавляем диагностическое сообщение
                    ReportError(context, "Найдено несколько классов с атрибутом BootstrapperAttribute. Ожидается ровно один.");
                    return;
                }

                // Генерируем код для единственного класса
                GenerateBootstrapCode(context, classSymbols[0]);
            });
        }

        private static bool IsClassWithAttribute(SyntaxNode node)
        {
            // Проверяем, что узел является определением класса
            return node is Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax classNode &&
                   classNode.AttributeLists.Count > 0;
        }

        private static INamedTypeSymbol? GetClassSymbol(GeneratorSyntaxContext context)
        {
            // Проверяем, что узел — это класс с атрибутами
            var classDeclaration = (Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax)context.Node;
            var semanticModel = context.SemanticModel;

            // Получаем символ класса
            var classSymbol = semanticModel.GetDeclaredSymbol(classDeclaration) as INamedTypeSymbol;
            if (classSymbol is null)
                return null;

            if (classSymbol.AllInterfaces.Any(i => i.ToDisplayString() == ModuleTypeName))
            {
                return classSymbol;
            }

            // Проверяем наличие атрибута BootstrapperAttribute
            foreach (var attribute in classSymbol.GetAttributes())
            {
                if (attribute.AttributeClass?.ToDisplayString() == BoostraperAttribiteName)
                {
                    return classSymbol;
                }
            }

            return null;
        }

        private static void GenerateBootstrapCode(SourceProductionContext context, INamedTypeSymbol classSymbol)
        {
            // Создаём код для файла InitApp.g.cs
            var code = $@"
                using System.Collections.Generic;
                using Microsoft.Extensions.DependencyInjection;

                namespace {classSymbol.ContainingNamespace}
                {{
                    public static class Bootstrap
                    {{
                        public static void Start(this IServiceCollection services)
                        {{
                            services.StartApplication<{classSymbol.ToDisplayString()}>();
                        }}
                    }}
                }}";

            // Добавляем сгенерированный код
            context.AddSource("Boostraper.g.cs", SourceText.From(code, Encoding.UTF8));
        }

        private static void ReportError(SourceProductionContext context, string message)
        {
            // Создаём диагностическое сообщение об ошибке
            var diagnostic = Diagnostic.Create(new DiagnosticDescriptor(
                id: "BOOTSTRAPGEN001",
                title: "Ошибка генерации Bootstrapper",
                messageFormat: message,
                category: "BootstrapperGenerator",
                DiagnosticSeverity.Error,
                isEnabledByDefault: true),
                Location.None);

            context.ReportDiagnostic(diagnostic);
        }
    }
}
