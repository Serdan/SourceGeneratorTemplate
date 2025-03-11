using Microsoft.CodeAnalysis;

namespace SourceGeneratorNamespace.Common;

public static class DiagnosticDescriptors
{
    public static readonly DiagnosticDescriptor MissingPartialKeyword =
        new("X0001", Resources.X0001_Title, Resources.X0001_MessageFormat, "Usage", DiagnosticSeverity.Warning, true);
}
