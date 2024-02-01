using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageProcess.Sentences
{
    public class SubjectVerbConjunctionSubjectVerb : SentenceBase
    {
        public StoryWord Subject { get; set; }

        public StoryWord Verb { get; set; }

        public StoryWord Conjunction { get; set; }

        public StoryWord Subject2 { get; set; }

        public StoryWord Verb2 { get; set; }
    }
}
