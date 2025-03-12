using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Testing;
using SourceGeneratorNamespace.Analyzer;
using SourceGeneratorNamespace.Common;
using Tests.Common;
using Xunit;

namespace LoadAdditionalFiles.Analyzer.Tests;

using Verifier = CSharpAnalyzerVerifier<GeneratorAnalyzer, DefaultVerifier>;

public class GeneratorAnalyzerTests
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
