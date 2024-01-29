using NaturalLanguageProcess.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageProcess
{
    public class StoryGenerator
    {

        private StoryContext storyContext;

        public StoryGenerator()
        {
            this.storyContext = new StoryContext();
        }

        public void Generate()
        {
            Entity protagonist = new Entity();
            protagonist.Role = CharacterType.Protagonist;
            protagonist.Skill = TitleType.Husband;
            protagonist.Mood = MoodType.Happy;
            this.storyContext.AddEntity(protagonist);

            Entity antagonist = new Entity();
            antagonist.Role = CharacterType.Antagonist;
            antagonist.Skill = TitleType.Veterinarian;
            antagonist.Mood = MoodType.Sad;
            this.storyContext.AddEntity(antagonist);
        }
    }
}
