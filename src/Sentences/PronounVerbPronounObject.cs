using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageProcess.Sentences
{
    public class PronounVerbPronounObject : SentenceBase
    {
        public StoryWord Pronoun { get; set; }

        public StoryWord Verb { get; set; }

        public StoryWord Pronoun2 { get; set; }

        public StoryWord Object { get; set; }

    }
}
