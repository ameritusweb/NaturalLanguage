namespace NaturalLanguageProcess.Logic
{
    public class ActionRule : ILogicalRule
    {
        public StoryWord Subject { get; set; }
        public StoryWord Verb { get; set; }
        public StoryWord Object { get; set; }

        public ActionRule(StoryWord subject, StoryWord verb, StoryWord @object)
        {
            Subject = subject;
            Verb = verb;
            Object = @object;
        }

        public bool Evaluate(StoryContext context)
        {
            return context.HasActionOccurred(Subject, Verb);
        }

        public void Apply(StoryContext context)
        {
            context.RecordAction(Subject, Verb);
        }
    }

}
