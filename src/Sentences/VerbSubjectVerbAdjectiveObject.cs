using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageProcess.Sentences
{
    public class VerbSubjectVerbAdjectiveObject
    {
        public StoryWord Verb { get; set; }

        public StoryWord Subject { get; set; }

        public StoryWord Verb2 { get; set; }

        public StoryWord Adjective { get; set; }

        public StoryWord Object { get; set; }
    }
}
