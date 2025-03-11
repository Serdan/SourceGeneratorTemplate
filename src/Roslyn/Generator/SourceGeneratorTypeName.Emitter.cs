namespace SourceGeneratorNamespace.Generator;

public partial class SourceGeneratorTypeName
{
    internal class Emitter(StaticContentTypeData typeData) : SyntaxDescriptionEmitter
    {
        public override Option<IEmitter> VisitNamedTypeBody(NamedTypeDescription description)
        {
            if (description.Identifier != typeData.TargetIdentifier)
            {
                return Emitter.Some();
            }

            return Emitter.Some();
        }
    }
}
