﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageProcess.Logic
{
    public interface ILogicalRule
    {
        bool Evaluate(StoryContext context);
        void Apply(StoryContext context);
    }
}
