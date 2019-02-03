using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace Analyzer1
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class Analyzer1Analyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "Analyzer";

        // You can change these strings in the Resources.resx file. If you do not want your analyzer to be localize-able, you can use regular strings for Title and MessageFormat.
        // See https://github.com/dotnet/roslyn/blob/master/docs/analyzers/Localizing%20Analyzers.md for more on localization
        private static readonly LocalizableString PublicTitle = new LocalizableResourceString(nameof(Resources.AnalyzerPublicClassTitle), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString PublicMessageFormat = new LocalizableResourceString(nameof(Resources.AnalyzerPublicClassMessageFormat), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString PublicDescription = new LocalizableResourceString(nameof(Resources.AnalyzerPublicClassDescription), Resources.ResourceManager, typeof(Resources));

        private static readonly LocalizableString AttributeTitle = new LocalizableResourceString(nameof(Resources.AnalyzerAttributeTitle), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString AttributeMessageFormat = new LocalizableResourceString(nameof(Resources.AnalyzerAttributeMessageFormat), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString AttributeDescription = new LocalizableResourceString(nameof(Resources.AnalyzerAttributeDescription), Resources.ResourceManager, typeof(Resources));

        private static readonly LocalizableString RequiredPropertiesTitle = new LocalizableResourceString(nameof(Resources.AnalyzerRequiredPropertiesTitle), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString RequiredPropertiesMessageFormat = new LocalizableResourceString(nameof(Resources.AnalyzerRequiredPropertiesMessageFormat), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString RequiredPropertiesDescription = new LocalizableResourceString(nameof(Resources.AnalyzerRequiredPropertiesDescription), Resources.ResourceManager, typeof(Resources));

        private static readonly LocalizableString PublicPropertiesTitle = new LocalizableResourceString(nameof(Resources.AnalyzerPublicPropertiesTitle), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString PublicPropertiesMessageFormat = new LocalizableResourceString(nameof(Resources.AnalyzerPublicPropertiesMessageFormat), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString PublicPropertiesDescription = new LocalizableResourceString(nameof(Resources.AnalyzerPublicPropertiesDescription), Resources.ResourceManager, typeof(Resources));

        private const string Category = "Custom_EntityClass";

        private static DiagnosticDescriptor PublicRule = new DiagnosticDescriptor(DiagnosticId, PublicTitle, PublicMessageFormat, Category, DiagnosticSeverity.Warning, isEnabledByDefault: true, description: PublicDescription);
        private static DiagnosticDescriptor AttributeRule = new DiagnosticDescriptor(DiagnosticId, AttributeTitle, AttributeMessageFormat, Category, DiagnosticSeverity.Warning, isEnabledByDefault: true, description: AttributeDescription);
        private static DiagnosticDescriptor RequiredPropertiesRule = new DiagnosticDescriptor(DiagnosticId, RequiredPropertiesTitle, RequiredPropertiesMessageFormat, Category, DiagnosticSeverity.Warning, isEnabledByDefault: true, description: RequiredPropertiesDescription);
        private static DiagnosticDescriptor PublicPropertiesRule = new DiagnosticDescriptor(DiagnosticId, PublicPropertiesTitle, PublicPropertiesMessageFormat, Category, DiagnosticSeverity.Warning, isEnabledByDefault: true, description: PublicPropertiesDescription);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get { return ImmutableArray.Create(PublicRule, AttributeRule, RequiredPropertiesRule, PublicPropertiesRule); } }

        public static List<string> RequiredProperties = new List<string> { "ID", "Name" };

        public override void Initialize(AnalysisContext context)
        {
            context.RegisterSyntaxNodeAction(AnalyzeSyntaxNode, SyntaxKind.ClassDeclaration);
        }

        private static void AnalyzeSyntaxNode(SyntaxNodeAnalysisContext context)
        {
            var classDeclaration = (ClassDeclarationSyntax)context.Node;

            var namespaceDeclaration = (NamespaceDeclarationSyntax)classDeclaration.Parent;

            if (namespaceDeclaration.Name.ToString().EndsWith(".Entities"))
            {
                if (!classDeclaration.Modifiers.Any(SyntaxKind.PublicKeyword))
                {
                    context.ReportDiagnostic(Diagnostic.Create(PublicRule, classDeclaration.GetLocation(), classDeclaration.Identifier.ValueText));
                }

                if (!classDeclaration.AttributeLists.SelectMany(x => x.Attributes).Any(x => x.Name.ToString().Equals("DataContract")))
                {
                    context.ReportDiagnostic(Diagnostic.Create(AttributeRule, classDeclaration.GetLocation(), classDeclaration.Identifier.ValueText));
                }

                foreach(var property in RequiredProperties)
                {
                    CheckRequiredProperties(context, classDeclaration, property);
                }
            }
        }

        public static void CheckRequiredProperties(SyntaxNodeAnalysisContext context, ClassDeclarationSyntax classDeclaration, string propertyName)
        {
            var property = classDeclaration.ChildNodes().Select(x => x as PropertyDeclarationSyntax).Where(x => x != null).FirstOrDefault(x => x.Identifier.ValueText.Equals(propertyName));

            if (property == null)
            {
                context.ReportDiagnostic(Diagnostic.Create(RequiredPropertiesRule, classDeclaration.GetLocation(), propertyName));
            }
            else if (!property.Modifiers.Any(SyntaxKind.PublicKeyword))
            {
                context.ReportDiagnostic(Diagnostic.Create(PublicPropertiesRule, property.GetLocation(), property.Identifier.ValueText));
            }
        }
    }
}
