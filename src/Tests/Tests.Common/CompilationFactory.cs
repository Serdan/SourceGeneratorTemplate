using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Tests.Common;

public static class CompilationFactory
{
    public static Compilation PartialClassWithAttribute(bool includeGeneratorTypes = false) =>
        CSharpCompilation.Create(
            "Test",
            [CSharpSyntaxTree.ParseText(SR.GetPartialClassWithAttribute(includeGeneratorTypes))],
            [MetadataReference.CreateFromFile(typeof(Object).Assembly.Location)],
            new(outputKind: OutputKind.DynamicallyLinkedLibrary)
        );
}
