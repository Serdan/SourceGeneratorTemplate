using System;

namespace Microsoft.CodeAnalysis
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    [Embedded]
    public class MarkerAttribute : Attribute;
}
