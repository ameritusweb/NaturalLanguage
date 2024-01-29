namespace NaturalLanguageProcess.Logic
{
    public class NounPairRelationshipRule : ILogicalRule
    {
        public StoryWord Subject { get; set; }
        public NounRelationshipType Relationship { get; set; }
        public StoryWord Object { get; set; }

        public NounPairRelationshipRule(StoryWord subject, NounRelationshipType relationship, StoryWord @object)
        {
            Subject = subject;
            Relationship = relationship;
            Object = @object;
        }

        public bool Evaluate(StoryContext context)
        {
            return context.HasNounPairRelationshipOccurred(Subject, Relationship, Object);
        }

        public void Apply(StoryContext context)
        {
            context.RecordNounPairRelationship(Subject, Relationship, Object);
        }
    }
}
