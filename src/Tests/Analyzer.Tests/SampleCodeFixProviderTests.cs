using SourceGeneratorNamespace.Common;
using Tests.Common;
using Xunit;
using Verifier = Microsoft.CodeAnalysis.CSharp.Testing.CSharpCodeFixVerifier<
    SourceGeneratorNamespace.Analyzer.LoadAdditionalFilesAnalyzer,
    SourceGeneratorNamespace.CodeFixes.SampleCodeFixProvider,
    Microsoft.CodeAnalysis.Testing.DefaultVerifier
>;

namespace LoadAdditionalFiles.Analyzer.Tests;

public class SampleCodeFixProviderTests
{
    [Fact]
    public async Task FixMissingPartialKeywordDiagnostic()
    {
        var original = SR.GetClassWithAttribute(true);
        var fixedSource = SR.GetPartialClassWithAttribute(true);

        var expected = Verifier.Diagnostic(DiagnosticDescriptors.MissingPartialKeyword)
                               .WithSpan(7, 18, 7, 29);

        await Verifier.VerifyCodeFixAsync(original, expected, fixedSource);
    }
}
