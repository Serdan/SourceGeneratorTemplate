namespace SourceGeneratorNamespace.Generator;

internal static class MyEmitterExtensions
{
    public static IEmitter StringLiteral(this IEmitter emitter, string quotes, string content)
    {
        return emitter.WithIndent(0, out var indent)
                      .Line(quotes)
                      .Line(content)
                      .Line($"{quotes};")
                      .WithIndent(indent);
    }

    public static IEmitter Comment(this IEmitter emitter, string content)
    {
        return emitter.Tabs().Append("// ").Line(content);
    }
}
