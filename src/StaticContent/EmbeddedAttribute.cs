using System;

namespace Microsoft.CodeAnalysis
{
    /// <summary>
    /// Hides internal types even with InternalsVisibleTo.
    /// <para/>
    /// IncrementalGeneratorPostInitializationContext.AddEmbeddedAttributeDefinition() will be available from Roslyn 4.14
    /// </summary>
    internal sealed class EmbeddedAttribute : Attribute;
}
