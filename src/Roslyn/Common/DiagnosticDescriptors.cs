using Microsoft.CodeAnalysis;

namespace SourceGeneratorNamespace.Common;

public static class DiagnosticDescriptors
{
    /// <summary>
    /// Target node must be partial. Change 'id' to a custom value. Prefer a prefix with 5 or more characters.
    /// </summary>
    public static readonly DiagnosticDescriptor MissingPartialKeyword =
        new(id: "X0001", Resources.X0001_Title, Resources.X0001_MessageFormat, "Usage", DiagnosticSeverity.Warning, true);
}
