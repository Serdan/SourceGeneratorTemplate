using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using SourceGeneratorNamespace.Common;

namespace SourceGeneratorNamespace.Analyzer;

using static Microsoft.CodeAnalysis.CSharp.SyntaxKind;
using static DiagnosticDescriptors;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class LoadAdditionalFilesAnalyzer : DiagnosticAnalyzer
{
    private const string AttributeName = "Kehlet.Generators.LoadAdditionalFiles.LoadAdditionalFilesAttribute";

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
            ClassDeclaration,
            StructDeclaration,
            InterfaceDeclaration,
            RecordDeclaration,
            RecordStructDeclaration
        );
    }

    private static void FindStaticContentContainer(SyntaxNodeAnalysisContext context)
    {
        var typeDeclarationNode = (TypeDeclarationSyntax)context.Node;

        var attributes = typeDeclarationNode.GetAttributesWithName(context.SemanticModel, AttributeName);
        if (attributes.IsEmpty)
        {
            return;
        }

        FindMissingPartial(context, typeDeclarationNode);
    }

    private static void FindMissingPartial(SyntaxNodeAnalysisContext context, TypeDeclarationSyntax typeDeclarationNode)
    {
        var hasPartial = typeDeclarationNode.Modifiers.Any(PartialKeyword);
        if (hasPartial)
        {
            return;
        }

        var diagnostic = Diagnostic.Create(MissingPartialKeyword, typeDeclarationNode.Identifier.GetLocation());

        context.ReportDiagnostic(diagnostic);
    }
}
