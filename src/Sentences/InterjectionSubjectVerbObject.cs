using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageProcess.Sentences
{
    public class InterjectionSubjectVerbObject : SentenceBase
    {
        public StoryWord Interjection { get; set; }

        public StoryWord Subject { get; set; }

        public StoryWord Verb { get; set; }

        public StoryWord Object { get; set; }
    }
}
