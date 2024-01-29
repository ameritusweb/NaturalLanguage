namespace NaturalLanguageProcess.Logic
{
    class NorCombinedLogicalRule : ILogicalRule
    {
        private List<ILogicalRule> Rules;

        public NorCombinedLogicalRule()
        {
            Rules = new List<ILogicalRule>();
        }

        public void AddRule(ILogicalRule rule)
        {
            Rules.Add(rule);
        }

        public bool Evaluate(StoryContext context)
        {
            return Rules.All(rule => !rule.Evaluate(context));
        }

        public void Apply(StoryContext context)
        {

        }
    }

}
