using Kehlet.Generators.LoadAdditionalFiles;

namespace Tests.Common;

[LoadAdditionalFiles(RegexFilter = @"\.cs$", MemberNameSuffix = "Source")]
public static partial class SR
{
    public static string GetClassWithAttribute(bool includeGeneratorTypes = false) =>
        $$"""
        using System;
        using Kehlet.Generators.LoadAdditionalFiles;

        namespace MyTestNamespace.SubNamespace
        {
            [LoadAdditionalFiles]
            public class MyTestClass;
        }

        {{(includeGeneratorTypes ? MarkerAttributeSource : "")}}
        """;

    public static string GetPartialClassWithAttribute(bool includeGeneratorTypes = false) =>
        $$"""
        using System;
        using Kehlet.Generators.LoadAdditionalFiles;

        namespace MyTestNamespace.SubNamespace
        {
            [LoadAdditionalFiles]
            public partial class MyTestClass;
        }

        {{(includeGeneratorTypes ? MarkerAttributeSource : "")}}
        """;
        
    
    public static readonly string PartialClassWithAttribute =
        $$"""
        using System;
        using Kehlet.Generators.LoadAdditionalFiles.StaticContent;

        namespace MyTestNamespace.SubNamespace
        {
            [LoadAdditionalFiles]
            public partial class MyTestClass;
        }

        {{MarkerAttributeSource}}
        """;
}
