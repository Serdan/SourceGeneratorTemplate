using System;

namespace Microsoft.CodeAnalysis
{
    /// <summary>
    /// Hides internal types even with InternalsVisibleTo.
    /// IncrementalGeneratorPostInitializationContext.AddEmbeddedAttributeDefinition() will be available from Roslyn 4.14
    /// This file should be removed at that time. 
    /// </summary>
    internal sealed class EmbeddedAttribute : Attribute;
}
