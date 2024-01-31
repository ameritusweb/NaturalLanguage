namespace NaturalLanguageProcess.Logic
{
    public class RuleRelationChain
    {
        private List<ILogicalRule> rules;

        public IReadOnlyList<ILogicalRule> Rules => rules;

        public RuleRelationChain()
        {
            rules = new List<ILogicalRule>();
        }

        public void AddRule(ILogicalRule rule)
        {
            rules.Add(rule);
        }
    }
}
