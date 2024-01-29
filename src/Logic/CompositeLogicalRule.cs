using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageProcess.Logic
{
    class CompositeLogicalRule : ILogicalRule
    {
        private List<ILogicalRule> Rules;

        public CompositeLogicalRule()
        {
            Rules = new List<ILogicalRule>();
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
            foreach (var rule in Rules)
            {
                rule.Apply(context);
            }
        }
    }

}
