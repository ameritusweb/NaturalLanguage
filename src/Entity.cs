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

        public VillainType Villain { get; set; }

        public List<(PossessionType, CardinalityType)> Possessions { get; set; }

        public List<LocationType> Locations { get; set; }

        public List<(Entity, CharacterRelationshipType)> Relationships { get; set; }

        public Entity()
        {
            Possessions = new List<(PossessionType, CardinalityType)>();
            Locations = new List<LocationType>();
            Relationships = new List<(Entity, CharacterRelationshipType)>();
        }
    }
}
