namespace NaturalLanguageProcess.Logic
{
    public class StoryContext
    {
        public Dictionary<StoryWord, List<StoryWord>> NounAdjectives { get; set; }
        public Dictionary<StoryWord, List<StoryWord>> CompletedActions { get; set; }
        public Dictionary<StoryWord, List<(StoryWord, StoryWord)>> ObjectRelatedActions { get; set; }
        public Dictionary<StoryWord, List<(NounRelationshipType, StoryWord)>> NounPairRelationships { get; set; }
        public List<RuleRelation> RuleRelations { get; set; }
        public List<ILogicalRule> Rules { get; set; }

        public StoryContext()
        {
            NounAdjectives = new Dictionary<StoryWord, List<StoryWord>>();
            CompletedActions = new Dictionary<StoryWord, List<StoryWord>>();
            ObjectRelatedActions = new Dictionary<StoryWord, List<(StoryWord, StoryWord)>>();
            RuleRelations = new List<RuleRelation>();
            Rules = new List<ILogicalRule>();
        }

        public void AddRule(ILogicalRule rule)
        {
            if (!Rules.Contains(rule))
            {
                Rules.Add(rule);
            }
        }

        public void AddRuleRelation(ILogicalRule antecedent, ILogicalRule consequent)
        {
            var relation = new RuleRelation(antecedent, consequent);
            if (!RuleRelations.Contains(relation))
            {
                RuleRelations.Add(relation);
            }
        }

        public void GenerateChainedRules()
        {
            var newRules = new List<ILogicalRule>();
            foreach (var relation1 in RuleRelations)
            {
                foreach (var relation2 in RuleRelations)
                {
                    if (relation1.Consequent == relation2.Antecedent)
                    {
                        // Create a new rule that combines the logic of relation1 and relation2
                        var combinedRule = new CombinedLogicalRule(relation1.Antecedent, relation2.Consequent);
                        newRules.Add(combinedRule);
                    }
                }
            }

            foreach (var newRule in newRules)
            {
                AddRule(newRule);
            }
        }


        public void RecordAction(StoryWord noun, StoryWord verb)
        {
            if (!CompletedActions.ContainsKey(noun))
            {
                CompletedActions[noun] = new List<StoryWord>();
            }
            if (!CompletedActions[noun].Contains(verb))
            {
                CompletedActions[noun].Add(verb);
            }
        }

        public void RecordObjectRelatedAction(StoryWord noun, StoryWord verb, StoryWord @object)
        {
            if (!ObjectRelatedActions.ContainsKey(noun))
            {
                ObjectRelatedActions[noun] = new List<(StoryWord, StoryWord)>();
            }
            if (!ObjectRelatedActions[noun].Contains((verb, @object)))
            {
                ObjectRelatedActions[noun].Add((verb, @object));
            }
        }

        public void RecordCharacteristic(StoryWord noun, StoryWord adjective)
        {
            if (!NounAdjectives.ContainsKey(noun))
            {
                NounAdjectives[noun] = new List<StoryWord>();
            }
            if (!NounAdjectives[noun].Contains(adjective))
            {
                NounAdjectives[noun].Add(adjective);
            }
        }

        public void RecordNounPairRelationship(StoryWord noun, NounRelationshipType relationship, StoryWord @object)
        {
            if (!NounPairRelationships.ContainsKey(noun))
            {
                NounPairRelationships[noun] = new List<(NounRelationshipType, StoryWord)>();
            }
            if (!NounPairRelationships[noun].Contains((relationship, @object)))
            {
                NounPairRelationships[noun].Add((relationship, @object));
            }
        }

        public bool HasNounPairRelationshipOccurred(StoryWord noun, NounRelationshipType relationship, StoryWord @object)
        {
            return NounPairRelationships.TryGetValue(noun, out var relationships) && relationships.Contains((relationship, @object));
        }

        public bool HasActionOccurred(StoryWord noun, StoryWord verb)
        {
            return CompletedActions.TryGetValue(noun, out var verbs) && verbs.Contains(verb);
        }

        public bool HasObjectRelatedActionOccurred(StoryWord noun, StoryWord verb, StoryWord @object)
        {
            return ObjectRelatedActions.TryGetValue(noun, out var actions) && actions.Contains((verb, @object));
        }

        public bool HasCharacteristicOccurred(StoryWord noun, StoryWord adjective)
        {
            return NounAdjectives.TryGetValue(noun, out var adjectives) && adjectives.Contains(adjective);
        }
    }
}
