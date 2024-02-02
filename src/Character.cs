using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageProcess
{
    public class Character
    {
        public StoryWord MentalState { get; set; }

        public StoryWord Skill { get; set; }

        public StoryWord Role { get; set; }

        public string Name { get; set; }
    }
}
