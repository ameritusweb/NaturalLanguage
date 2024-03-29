﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageProcess.Sentences
{
    public class SubjectVerbAdjectiveObjectAdverb : SentenceBase
    {
        public StoryWord Subject { get; set; }

        public StoryWord Verb { get; set; }

        public StoryWord Adjective { get; set; }

        public StoryWord Object { get; set; }

        public StoryWord Adverb { get; set; }
    }
}
