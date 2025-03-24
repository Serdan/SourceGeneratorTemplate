using Microsoft.CodeAnalysis;
using SourceGeneratorNamespace.Common;

namespace SourceGeneratorNamespace.Generator;

using static StaticContent;

[Generator]
public partial class SourceGeneratorTypeName : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        context.RegisterPostInitializationOutput(ctx =>
        {
            ctx.AddSource<EmbeddedAttribute>(EmbeddedAttributeSource);
            ctx.AddSource<MarkerAttribute>(MarkerAttributeSource);
        });

        var typeValues = context.CreateTargetProvider(MarkerAttributeName, SyntaxTarget.Type, Parser.Parse).Choose();

        context.RegisterSourceOutput(typeValues, GenerateCode);
    }

    internal static void GenerateCode(SourceProductionContext context, TargetTypeData data)
    {
        var emitter = new Emitter(data);
        emitter.Visit(data.ModuleDescription);
        context.AddSourceUTF8(data.FileName, emitter.ToString());
    }
}
