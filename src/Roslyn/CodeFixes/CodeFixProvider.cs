using System.Collections.Immutable;
using System.Composition;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SourceGeneratorNamespace.Common;

namespace SourceGeneratorNamespace.CodeFixes;

using static DiagnosticDescriptors;

[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(CodeFixProvider)), Shared]
public sealed class CodeFixProvider : Microsoft.CodeAnalysis.CodeFixes.CodeFixProvider
{
    public override ImmutableArray<string> FixableDiagnosticIds { get; } = [MissingPartialKeyword.Id];

    public override FixAllProvider GetFixAllProvider() => WellKnownFixAllProviders.BatchFixer;

    public override async Task RegisterCodeFixesAsync(CodeFixContext context)
    {
        var diagnostic = context.Diagnostics.Single();
        var diagnosticSpan = diagnostic.Location.SourceSpan;

        var root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);

        var diagnosticNode = root?.FindNode(diagnosticSpan);
        if (diagnosticNode is not TypeDeclarationSyntax declaration)
        {
            return;
        }

        context.RegisterCodeFix(
            CodeAction.Create(
                title: MissingPartialKeyword.Title.ToString(),
                createChangedSolution: ct => AddPartialKeywordAsync(context.Document, declaration, ct),
                equivalenceKey: nameof(MissingPartialKeyword)
            ),
            diagnostic
        );
    }

    private static async Task<Solution> AddPartialKeywordAsync(
        Document document,
        TypeDeclarationSyntax typeDeclarationSyntax,
        CancellationToken cancellationToken)
    {
        var partial = SyntaxFactory.Token(SyntaxKind.PartialKeyword).WithTrailingTrivia(SyntaxFactory.Space);
        var modifiers = typeDeclarationSyntax.Modifiers.Add(partial);
        var fixedDeclaration = typeDeclarationSyntax.WithModifiers(modifiers);

        var root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
        if (root is null)
        {
            return document.Project.Solution;
        }

        var newRoot = root.ReplaceNode(typeDeclarationSyntax, fixedDeclaration);
        var newDoc = document.WithSyntaxRoot(newRoot);

        return newDoc.Project.Solution;
    }
}
