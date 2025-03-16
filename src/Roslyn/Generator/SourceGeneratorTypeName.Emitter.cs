namespace SourceGeneratorNamespace.Generator;

public partial class SourceGeneratorTypeName
{
    internal class Emitter(TargetTypeData typeData) : SyntaxDescriptionEmitter
    {
        public override Option<IEmitter> VisitNamedTypeBody(NamedTypeDescription description)
        {
            if (description.IsTargetNode is false)
            {
                return Emitter.Some();
            }

            Emitter.Comment(typeData.SomeData);

            return Emitter.Some();
        }
    }
}
