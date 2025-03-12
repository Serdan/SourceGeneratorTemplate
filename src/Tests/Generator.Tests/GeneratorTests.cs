using Microsoft.CodeAnalysis;
using SourceGeneratorNamespace.Generator;
using Tests.Common;

namespace Generator.Tests;

public class GeneratorTests
{
    [Fact]
    public Task VerifyVerify() => VerifyChecks.Run();

    [Fact]
    public Task GenerateEmptyPartialClass()
    {
        var generator = new SourceGeneratorTypeName();
        var comp = CompilationFactory.PartialClassWithAttribute();
        var driver = GeneratorDriverFactory.Default(generator).RunGeneratorsAndUpdateCompilation(comp, out var resultComp, out _);

        var result = driver.GetRunResult().Results.Single();
        Assert.Empty(resultComp.GetDiagnostics().Where(x => x.Severity is not (DiagnosticSeverity.Info or DiagnosticSeverity.Hidden)));
        Assert.Equal(3, result.GeneratedSources.Length);
        return Verify(result.GeneratedSources.Last().SourceText.ToString());
    }
}
