namespace NaturalLanguageProcess.Logic
{
    class ExclusiveOrCombinedLogicalRule : ILogicalRule
    {
        private List<ILogicalRule> Rules;

        public ExclusiveOrCombinedLogicalRule()
        {
            Rules = new List<ILogicalRule>();
        }

        public void AddRule(ILogicalRule rule)
        {
            Rules.Add(rule);
        }

        public bool Evaluate(StoryContext context)
        {
            return Rules.Count(rule => rule.Evaluate(context)) == 1;
        }

        public void Apply(StoryContext context)
        {
            if (this.Evaluate(context))
            {
                foreach (var rule in Rules)
                {
                    if (rule.Evaluate(context))
                    {
                        rule.Apply(context);
                        break;
                    }
                }
            }
        }
    }

}
