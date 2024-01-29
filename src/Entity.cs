using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageProcess
{
    public class Entity
    {
        public CharacterType Role { get; set; }
        
        public TitleType Skill { get; set; }

        public MoodType Mood { get; set; }
    }
}
