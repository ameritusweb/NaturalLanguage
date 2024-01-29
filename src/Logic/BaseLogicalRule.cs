using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageProcess.Logic
{
    public class BaseLogicalRule : ILogicalRule
    {
        public StoryWord Noun1 { get; set; }
        public StoryWord Adjective1 { get; set; }
        public StoryWord Noun2 { get; set; }
        public StoryWord Adjective2 { get; set; }

        public BaseLogicalRule(StoryWord noun1, StoryWord adjective1, StoryWord noun2, StoryWord adjective2)
        {
            Noun1 = noun1;
            Adjective1 = adjective1;
            Noun2 = noun2;
            Adjective2 = adjective2;
        }

        public bool Evaluate(StoryContext context)
        {
            // Check if Noun1 is Adjective1 in the current context
            return true;
        }

        public void Apply(StoryContext context)
        {
            // Apply the implication, making Noun2 Adjective2
        }
    }
}
