using Kehlet.Generators.LoadAdditionalFiles;

namespace SourceGeneratorNamespace.Common;

[LoadAdditionalFiles(RegexFilter = @"\.cs", MemberNameSuffix = "Source")]
public static partial class StaticContent;
