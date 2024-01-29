namespace NaturalLanguageProcess.Logic
{
    class OrCombinedLogicalRule : ILogicalRule
    {
        private List<ILogicalRule> Rules;

        public OrCombinedLogicalRule()
        {
            Rules = new List<ILogicalRule>();
        }

        public void AddRule(ILogicalRule rule)
        {
            Rules.Add(rule);
        }

        public bool Evaluate(StoryContext context)
        {
            return Rules.Any(rule => rule.Evaluate(context));
        }

        public void Apply(StoryContext context)
        {
            foreach (var rule in Rules)
            {
                if (rule.Evaluate(context))
                {
                    rule.Apply(context);
                }
            }
        }
    }

}
