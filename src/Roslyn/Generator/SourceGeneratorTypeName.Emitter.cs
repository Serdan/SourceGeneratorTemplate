namespace SourceGeneratorNamespace.Generator;

public partial class SourceGeneratorTypeName
{
    internal class Emitter(TargetTypeData typeData) : SyntaxDescriptionEmitter
    {
        public override Unit VisitNamedTypeBody(NamedTypeDescription description)
        {
            if (description.IsTargetNode is false)
            {
                return unit;
            }

            Emitter.Comment(typeData.SomeData);

            return unit;
        }
    }
}
