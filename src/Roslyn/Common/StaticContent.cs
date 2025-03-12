using Kehlet.Generators.LoadAdditionalFiles;

namespace SourceGeneratorNamespace.Common;

[LoadAdditionalFiles(RegexFilter = @"\.cs", MemberNameSuffix = "Source")]
public static partial class StaticContent
{
    public static string MarkerAttributeName => typeof(MarkerAttribute).FullName!;

    public static string MarkerAttributeNamespace => typeof(MarkerAttribute).Namespace!;
}
