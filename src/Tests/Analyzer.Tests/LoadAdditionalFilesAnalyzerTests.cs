using SourceGeneratorNamespace.Common;
using Tests.Common;
using Xunit;
using Verifier = Microsoft.CodeAnalysis.CSharp.Testing.CSharpAnalyzerVerifier<
    SourceGeneratorNamespace.Analyzer.LoadAdditionalFilesAnalyzer,
    Microsoft.CodeAnalysis.Testing.DefaultVerifier
>;

namespace LoadAdditionalFiles.Analyzer.Tests;

public class LoadAdditionalFilesAnalyzerTests
{
    [Fact]
    public async Task MissingPartialKeywordDiagnostic()
    {
        var text = SR.GetClassWithAttribute(true);

        var expected = Verifier.Diagnostic(DiagnosticDescriptors.MissingPartialKeyword)
                               .WithSpan(7, 18, 7, 29);

        await Verifier.VerifyAnalyzerAsync(text, expected);
    }
}
