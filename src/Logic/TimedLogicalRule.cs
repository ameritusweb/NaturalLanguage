using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageProcess.Logic
{
    class TimedLogicalRule : ILogicalRule
    {
        public ILogicalRule Rule { get; set; }
        public bool IsImmediate { get; set; } // True for immediate, false for delayed

        public TimedLogicalRule(ILogicalRule rule, bool isImmediate)
        {
            Rule = rule;
            IsImmediate = isImmediate;
        }

        public bool Evaluate(StoryContext context)
        {
            // Immediate rules are always evaluated, delayed rules might depend on additional conditions
            return IsImmediate || CheckDelayedCondition(context);
        }

        public void Apply(StoryContext context)
        {
            if (Evaluate(context))
            {
                Rule.Apply(context);
                if (!IsImmediate)
                {
                    // Handle the delayed application, e.g., schedule for a later point in the story
                }
            }
        }

        private bool CheckDelayedCondition(StoryContext context)
        {
            // Implement logic to determine if the condition for a delayed rule is met
            return true;
        }
    }

}
