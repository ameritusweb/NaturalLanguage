namespace NaturalLanguageProcess.Logic
{
    public class RuleRelationChain
    {
        private List<RuleRelation> rules;

        public IReadOnlyList<RuleRelation> Rules => rules;

        public RuleRelationChain()
        {
            rules = new List<RuleRelation>();
        }

        public void AddRule(RuleRelation rule)
        {
            rules.Add(rule);
        }
    }
}
