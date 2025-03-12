using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using SourceGeneratorNamespace.Common;

namespace SourceGeneratorNamespace.Analyzer;

using SK = SyntaxKind;
using static DiagnosticDescriptors;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class GeneratorAnalyzer : DiagnosticAnalyzer
{
    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } =
    [
        MissingPartialKeyword
    ];

    public override void Initialize(AnalysisContext context)
    {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();
        context.RegisterSyntaxNodeAction(
            FindStaticContentContainer,
            SK.ClassDeclaration,
            SK.StructDeclaration,
            SK.InterfaceDeclaration,
            SK.RecordDeclaration,
            SK.RecordStructDeclaration
        );
    }

    private static void FindStaticContentContainer(SyntaxNodeAnalysisContext context)
    {
        var typeDeclarationNode = (TypeDeclarationSyntax)context.Node;

        var attributes = typeDeclarationNode.GetAttributesWithName(context.SemanticModel, StaticContent.MarkerAttributeName);
        if (attributes.IsEmpty)
        {
            return;
        }

        FindMissingPartial(context, typeDeclarationNode);
    }

    private static void FindMissingPartial(SyntaxNodeAnalysisContext context, TypeDeclarationSyntax typeDeclarationNode)
    {
        var hasPartial = typeDeclarationNode.Modifiers.Any(SK.PartialKeyword);
        if (hasPartial)
        {
            return;
        }

        var diagnostic = Diagnostic.Create(MissingPartialKeyword, typeDeclarationNode.Identifier.GetLocation());

        context.ReportDiagnostic(diagnostic);
    }
}
