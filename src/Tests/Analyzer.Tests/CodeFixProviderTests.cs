using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Testing;
using SourceGeneratorNamespace.Analyzer;
using SourceGeneratorNamespace.CodeFixes;
using SourceGeneratorNamespace.Common;
using Tests.Common;
using Xunit;

namespace Analyzer.Tests;

using Verifier = CSharpCodeFixVerifier<GeneratorAnalyzer, CodeFixProvider, DefaultVerifier>;

public class CodeFixProviderTests
{
    [Fact]
    public async Task FixMissingPartialKeywordDiagnostic()
    {
        var original = SR.GetClassWithAttribute(true);
        var fixedSource = SR.GetPartialClassWithAttribute(true);

        var expected = Verifier.Diagnostic(DiagnosticDescriptors.MissingPartialKeyword)
                               .WithSpan(19, 18, 19, 29);

        await Verifier.VerifyCodeFixAsync(original, expected, fixedSource);
    }
}
