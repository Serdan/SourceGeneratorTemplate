using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Jobs;
using Microsoft.CodeAnalysis;
using SourceGeneratorNamespace.Generator;
using Tests.Common;

namespace Benchmarks;

[SimpleJob(RunStrategy.Throughput, RuntimeMoniker.Net90)]
[MemoryDiagnoser]
[HtmlExporter]
public class GeneratorBenchmarks
{
    private Compilation simpleComp = null!;
    private GeneratorDriver driver = null!;
    
    [GlobalSetup]
    public void Setup()
    {
        var generator  = new SourceGeneratorTypeName();
        
        simpleComp = CompilationFactory.PartialClassWithAttribute();
        driver = GeneratorDriverFactory.Default(generator);
    }

    [Benchmark]
    public GeneratorDriver Generator()
    {
        return driver.RunGenerators(simpleComp);
    }
}
