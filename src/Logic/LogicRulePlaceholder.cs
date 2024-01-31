namespace NaturalLanguageProcess.Logic
{
    public class LogicRulePlaceholder : ILogicalRule
    {
        public Entity? Subject { get; set; }
        public LogicRuleType LogicRule { get; set; }

        public bool IsHypothetical { get; set; }

        public bool IsProvenTrue { get; set; }

        public bool IsProvenFalse { get; set; }

        public void Apply(StoryContext context)
        {
            throw new NotImplementedException();
        }

        public bool Evaluate(StoryContext context)
        {
            throw new NotImplementedException();
        }
    }
}
