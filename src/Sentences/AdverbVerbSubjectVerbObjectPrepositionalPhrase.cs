using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageProcess.Sentences
{
    public class AdverbVerbSubjectVerbObjectPrepositionalPhrase : SentenceBase
    {
        public StoryWord Adverb { get; set; }

        public StoryWord Verb { get; set; }

        public StoryWord Subject { get; set; }

        public StoryWord Verb2 { get; set; }

        public StoryWord Object { get; set; }

        public StoryWord Preposition { get; set; }

        public StoryWord PrepositionalObject { get; set; }
    }
}
