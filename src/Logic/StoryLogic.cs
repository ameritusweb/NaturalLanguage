namespace NaturalLanguageProcess.Logic
{
    public class StoryLogic
    {
        public List<RuleRelation> Assumptions { get; set; }

        public List<RuleRelationChain> Facts { get; set; }

        public Dictionary<RuleRelation, List<ILogicalRule>> Progression { get; set; }

        public Dictionary<RuleRelation, List<ILogicalRule>> TrueDiscovery { get; set; }

        public Dictionary<RuleRelation, List<ILogicalRule>> FalseDiscovery { get; set; }

        public List<RuleRelation> TemporaryConclusions { get; set; }

        public List<RuleRelation> Conclusions { get; set; }

        public StoryLogic()
        {
            Assumptions = new List<RuleRelation>();
            Facts = new List<RuleRelationChain>();
            Progression = new Dictionary<RuleRelation, List<ILogicalRule>>();
            TrueDiscovery = new Dictionary<RuleRelation, List<ILogicalRule>>();
            FalseDiscovery = new Dictionary<RuleRelation, List<ILogicalRule>>();
            TemporaryConclusions = new List<RuleRelation>();
            Conclusions = new List<RuleRelation>();
        }
    }
}
