using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using SourceGeneratorNamespace.Common;

namespace SourceGeneratorNamespace.Generator;

using static StaticContent;

[Generator]
public partial class SourceGeneratorTypeName : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        context.RegisterPostInitializationOutput(ctx =>
            ctx.AddSource("Microsoft.CodeAnalysis.EmbeddedAttribute.g.cs", SourceText.From(EmbeddedAttributeSource, Encoding.UTF8))
        );

        var typeValues = context.GetTargetProvider(typeof(MarkerAttribute).FullName!, SyntaxTarget.Type, Parser.Parse).Choose();

        context.RegisterSourceOutput(typeValues, GenerateCode);
    }

    internal static void GenerateCode(SourceProductionContext context, StaticContentTypeData data)
    {
        var source = new Emitter(data).Visit(data.ModuleDescription).UnsafeValue.ToString();
        context.AddSourceUTF8(data.FileName, source);
    }
}
