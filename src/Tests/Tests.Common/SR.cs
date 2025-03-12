using Kehlet.Generators.LoadAdditionalFiles;
using Microsoft.CodeAnalysis;

namespace Tests.Common;

[LoadAdditionalFiles(RegexFilter = @"\.cs$", MemberNameSuffix = "Source", MemberKind = MemberKind.Property)]
public static partial class SR
{
    public static string GetClassWithAttribute(bool includeGeneratorTypes = false) =>
        $$"""
        using System;
        using {{typeof(MarkerAttribute).Namespace}};
        {{(includeGeneratorTypes ? MarkerAttributeSource : "")}}

        namespace MyTestNamespace.SubNamespace
        {
            [MarkerAttribute]
            public class MyTestClass;
        }
        """;

    public static string GetPartialClassWithAttribute(bool includeGeneratorTypes = false) =>
        $$"""
        using System;
        using {{typeof(MarkerAttribute).Namespace}};
        {{(includeGeneratorTypes ? MarkerAttributeSource : "")}}

        namespace MyTestNamespace.SubNamespace
        {
            [MarkerAttribute]
            public partial class MyTestClass;
        }
        """;
}
