using System;
using Microsoft.CodeAnalysis;
using static System.AttributeTargets;

namespace SourceGeneratorNamespace
{
    [AttributeUsage(Class | Struct | Interface)]
    [Embedded]
    internal class MarkerAttribute : Attribute;
}
