namespace NaturalLanguageProcess.Logic
{
    class CombinedLogicalRule : ILogicalRule
    {
        private List<ILogicalRule> Rules;

        public CombinedLogicalRule()
        {
            Rules = new List<ILogicalRule>();
        }

        public CombinedLogicalRule(ILogicalRule consequent, ILogicalRule antecedent)
        {
            Rules = new List<ILogicalRule>();
            Rules.Add(consequent);
            Rules.Add(antecedent);
        }

        public void AddRule(ILogicalRule rule)
        {
            Rules.Add(rule);
        }

        public bool Evaluate(StoryContext context)
        {
            return Rules.All(rule => rule.Evaluate(context));
        }

        public void Apply(StoryContext context)
        {
            if (this.Evaluate(context))
            {
                foreach (var rule in Rules)
                {
                    rule.Apply(context);
                }
            }
        }
    }

}
