using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageProcess.Sentences
{
    public class SubjectVerbAdverbial : SentenceBase
    {
        public StoryWord Subject { get; set; }

        public StoryWord Verb { get; set; }

        public StoryWord Adverbial { get; set; }
    }
}
