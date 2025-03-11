using System.Text;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Tests.Common;

public class TestAdditionalText(string path, string? text) : AdditionalText
{
    private readonly SourceText? sourceText = text is null ? null : SourceText.From(text, Encoding.UTF8);

    public override SourceText? GetText(CancellationToken cancellationToken = default) => sourceText;

    public override string Path { get; } = path;

    public static TestAdditionalText From(string path, string text) => new(path, text);
    public static TestAdditionalText MissingFile(string path) => new(path, null);
}
