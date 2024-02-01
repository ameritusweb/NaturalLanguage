using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageProcess.Sentences
{
    public class InterjectionAdjectiveAdjectiveAdjectiveObject : SentenceBase
    {
        public StoryWord Interjection { get; set; }

        public StoryWord Adjective1 { get; set; }

        public StoryWord Adjective2 { get; set; }

        public StoryWord Adjective3 { get; set; }

        public StoryWord Object { get; set; }
    }
}
