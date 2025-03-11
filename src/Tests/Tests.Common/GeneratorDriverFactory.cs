using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Tests.Common;

public static class GeneratorDriverFactory
{
    public static CSharpGeneratorDriver WithNoFiles(IIncrementalGenerator generator) =>
        CSharpGeneratorDriver.Create(generator);

    public static CSharpGeneratorDriver WithOneFile(IIncrementalGenerator generator) =>
        (CSharpGeneratorDriver)CSharpGeneratorDriver.Create(generator)
                                                    .AddAdditionalTexts([TestAdditionalText.From("SomeDir\\MyFile.txt", "TODO: Conquer the world")]);
}
