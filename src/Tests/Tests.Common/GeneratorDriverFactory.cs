using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Tests.Common;

public static class GeneratorDriverFactory
{
    public static CSharpGeneratorDriver Default(IIncrementalGenerator generator) =>
        CSharpGeneratorDriver.Create(generator);
}
