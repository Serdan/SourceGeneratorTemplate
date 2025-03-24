namespace SourceGeneratorNamespace.Generator;

internal static class MyEmitterExtensions
{
    public static IEmitter Comment(this IEmitter emitter, string content)
    {
        return emitter.Tabs().Append("// ").Line(content);
    }
}
