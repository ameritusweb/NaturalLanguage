namespace NaturalLanguageProcess.Logic
{
    public class RuleRelation
    {
        public ILogicalRule Antecedent { get; set; }
        public ILogicalRule Consequent { get; set; }

        public RuleRelation(ILogicalRule antecedent, ILogicalRule consequent)
        {
            Antecedent = antecedent;
            Consequent = consequent;
        }
    }
}
