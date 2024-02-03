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

        public static Character GenerateWithPlaceholders()
        {
            Character character = new Character();
            var properties = character.GetType().GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                properties[i].SetValue(character, new StoryWord { WordText = $"$C{i}$" });
            }
            return character;
        }
    }
}
