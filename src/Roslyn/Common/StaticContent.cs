using Kehlet.Generators.LoadAdditionalFiles;
using Microsoft.CodeAnalysis;

namespace SourceGeneratorNamespace.Common;

[LoadAdditionalFiles(RegexFilter = @"\.cs", MemberNameSuffix = "Source")]
public static partial class StaticContent
{
    public static string MarkerAttributeName => typeof(MarkerAttribute).FullName!;
}
