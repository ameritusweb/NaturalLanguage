using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageProcess.Sentences
{
    public class PronounConjunctionSubjectVerbAdjective : SentenceBase
    {
        public StoryWord Pronoun { get; set; }

        public StoryWord Conjunction { get; set; }

        public StoryWord Subject { get; set; }

        public StoryWord Verb { get; set; }

        public StoryWord Adjective { get; set; }
    }
}
