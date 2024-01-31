namespace NaturalLanguageProcess.Logic
{
    /// <summary>
    /// The story logic
    /// Follows a structure like this:
    /// Opinion: A caused B
    /// Fact: If E then G, if G then H, if H then A
    /// Narrative Progression: Figure out H, then G, then E
    /// Discovery: Figure out E is not true
    /// Temporary Conclusion: A did not cause B
    /// Fact: If Not J And Not K, then G
    /// Narrative Progression: Figure out J, then K
    /// Discovery: J is false
    /// Discovery: K is false
    /// Conclusion: A did cause B
    /// Narrative Progression: Arrest A
    /// </summary>
    public class StoryLogic
    {
        private Random random;

        public List<ILogicalRule> InitialActions { get; set; }

        public Dictionary<Entity, List<RuleRelation>> Assumptions { get; set; }

        public List<RuleRelationChain> Facts { get; set; }

        public Dictionary<ILogicalRule, List<ILogicalRule>> Progression { get; set; }

        public Dictionary<ILogicalRule, List<ILogicalRule>> TrueDiscovery { get; set; }

        public Dictionary<ILogicalRule, List<ILogicalRule>> FalseDiscovery { get; set; }

        public Dictionary<ILogicalRule, List<ILogicalRule>> IfTrueProgressions { get; set; }

        public Dictionary<ILogicalRule, List<ILogicalRule>> IfFalseProgressions { get; set; }

        public List<RuleRelation> TemporaryConclusions { get; set; }

        public List<RuleRelation> Conclusions { get; set; }

        public void GenerateInitialActions(List<Entity> entities)
        {
            foreach (var entity in entities)
            {
                int actionCount = this.random.Next(1, 2);
                for (int i = 0; i < actionCount; ++i)
                {
                    this.InitialActions.Add(new LogicRulePlaceholder() { Subject = entity, LogicRule = LogicRuleType.ActionRule, IsHypothetical = false });
                }
            }
        }

        public void GenerateAssumptions(List<Entity> entities)
        {
            foreach (var initialAction in InitialActions)
            {
                foreach (var entity in entities)
                {
                    Assumptions.Add(entity, new List<RuleRelation>());
                    int assumptionCount = this.random.Next(1, 2);
                    for (int i = 0; i < assumptionCount; ++i)
                    {
                        RuleRelation ruleRelation = new RuleRelation()
                        {
                            Antecedent = new LogicRulePlaceholder() { LogicRule = LogicRuleType.EmotionalStateTransitionRule, IsHypothetical = true },
                            Consequent = initialAction
                        };
                        Assumptions[entity].Add(ruleRelation);
                    }
                }
            }
        }

        public void GenerateFacts(List<Entity> entities)
        {
            foreach (var entity in entities)
            {
                var assumptions = Assumptions[entity];
                foreach (var assumption in assumptions)
                {
                    var first = assumption.Antecedent;
                    RuleRelationChain chain = new RuleRelationChain();
                    int randomCount = this.random.Next(5, 7);
                    ILogicalRule antecedent = new LogicRulePlaceholder() { LogicRule = LogicRuleType.ActionRule, IsHypothetical = true };
                    for (int i = 0; i < randomCount; ++i)
                    {
                        RuleRelation ruleRelation = new RuleRelation()
                        {
                            Antecedent = antecedent,
                            Consequent = new LogicRulePlaceholder() { LogicRule = LogicRuleType.ActionRule, IsHypothetical = true }
                        };
                        chain.AddRule(ruleRelation);
                        antecedent = ruleRelation.Consequent;
                    }
                    RuleRelation final = new RuleRelation()
                    {
                        Antecedent = antecedent,
                        Consequent = first
                    };
                    chain.AddRule(final);
                    Facts.Add(chain);
                }
            }
        }

        public void GenerateNarrativeProgression()
        {
            foreach (var fact in Facts)
            {
                foreach (var rule in fact.Rules)
                {
                    var antecedent = rule.Antecedent;
                    int randomCount = this.random.Next(3, 4);
                    for (int i = 0; i < randomCount; ++i)
                    {
                        var rulePlaceholder = new LogicRulePlaceholder() { LogicRule = LogicRuleType.ActionRule, IsHypothetical = false };
                        if (Progression.ContainsKey(antecedent))
                        {
                            Progression[antecedent].Add(rulePlaceholder);
                        }
                        else
                        {
                            Progression[antecedent] = new List<ILogicalRule>() { rulePlaceholder };
                        }
                    }
                }
            }
        }

        public void GenerateHypotheticalDiscovery()
        {
            foreach (var progression in Progression.Keys.OfType<LogicRulePlaceholder>())
            {
                var isTrue = random.NextDouble() > 0.5d;
                if (isTrue)
                {
                    progression.IsProvenTrue = true;
                    var randomCount = this.random.Next(3, 4);
                    List<ILogicalRule> rules = new List<ILogicalRule>();
                    for (int i = 0; i < randomCount; ++i)
                    {
                        rules.Add(new LogicRulePlaceholder() { LogicRule = LogicRuleType.ActionRule, IsHypothetical = false });
                    }
                    TrueDiscovery.Add(progression, rules);
                }
                else
                {
                    progression.IsProvenFalse = true;
                    var randomCount = this.random.Next(3, 4);
                    List<ILogicalRule> rules = new List<ILogicalRule>();
                    for (int i = 0; i < randomCount; ++i)
                    {
                        rules.Add(new LogicRulePlaceholder() { LogicRule = LogicRuleType.ActionRule, IsHypothetical = false });
                    }
                    FalseDiscovery.Add(progression, rules);
                }
            }
        }

        public void GenerateHypotheticalProgressions()
        {
            foreach (var td in TrueDiscovery.Keys.OfType<LogicRulePlaceholder>())
            {
                var randomCount = this.random.Next(3, 4);
                List<ILogicalRule> rules = new List<ILogicalRule>();
                for (int i = 0; i < randomCount; ++i)
                {
                    rules.Add(new LogicRulePlaceholder() { LogicRule = LogicRuleType.ActionRule, IsHypothetical = false });
                }
                IfTrueProgressions.Add(td, rules);
            }

            foreach (var fd in FalseDiscovery.Keys.OfType<LogicRulePlaceholder>())
            {
                var randomCount = this.random.Next(3, 4);
                List<ILogicalRule> rules = new List<ILogicalRule>();
                for (int i = 0; i < randomCount; ++i)
                {
                    rules.Add(new LogicRulePlaceholder() { LogicRule = LogicRuleType.ActionRule, IsHypothetical = false });
                }
                IfFalseProgressions.Add(fd, rules);
            }
        }

        public void GenerateTemporaryConclusions()
        {

        }

        public void GenerateNewAssumptionsFactsDiscoveryAndProgressions()
        {

        }

        public void GenerateConclusions()
        {

        }

        public StoryLogic()
        {
            this.random = new Random();
            Assumptions = new Dictionary<Entity, List<RuleRelation>>();
            Facts = new List<RuleRelationChain>();
            Progression = new Dictionary<ILogicalRule, List<ILogicalRule>>();
            TrueDiscovery = new Dictionary<ILogicalRule, List<ILogicalRule>>();
            FalseDiscovery = new Dictionary<ILogicalRule, List<ILogicalRule>>();
            IfTrueProgressions = new Dictionary<ILogicalRule, List<ILogicalRule>>();
            IfFalseProgressions = new Dictionary<ILogicalRule, List<ILogicalRule>>();
            TemporaryConclusions = new List<RuleRelation>();
            Conclusions = new List<RuleRelation>();
        }
    }
}
