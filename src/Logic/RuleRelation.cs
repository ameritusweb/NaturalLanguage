namespace NaturalLanguageProcess.Logic
{
    public class RuleRelation : IRuleRelation
    {
        public ILogicalRule Antecedent { get; set; }
        public ILogicalRule Consequent { get; set; }

        public RuleRelation()
        {

        }

        public RuleRelation(ILogicalRule antecedent, ILogicalRule consequent)
        {
            Antecedent = antecedent;
            Consequent = consequent;
        }
    }
}
