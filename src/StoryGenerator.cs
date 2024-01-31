using NaturalLanguageProcess.Logic;
using Newtonsoft.Json;

namespace NaturalLanguageProcess
{
    public class StoryGenerator
    {

        private StoryContext storyContext;
        private Dictionary<string, Word> wordMap;
        private Dictionary<string, StoryWord> storyWordMap;
        private Random random;

        public StoryGenerator()
        {
            this.storyContext = new StoryContext();
            this.wordMap = new Dictionary<string, Word>();
            this.storyWordMap = new Dictionary<string, StoryWord>();
            this.random = new Random(Guid.NewGuid().GetHashCode());
            var text = File.ReadAllText("E:\\alphabet\\wordsphere.json");
            var words = JsonConvert.DeserializeObject<List<SerializableWord>>(text, new ListStringToSerializableWordConverter());
            var wordsMap = Word.DeserializePartial(words);
            foreach (var serializableWord in words)
            {
                var word = Word.Deserialize(serializableWord, wordsMap);
                wordMap.Add(word.Text, word);
            }
            var story = File.ReadAllText("E:\\alphabet\\storywords.json");
            var storyList = JsonConvert.DeserializeObject<List<StoryWord>>(story);
            foreach (var storyWord in storyList)
            {
                storyWordMap.Add(storyWord.WordText, storyWord);
            }
        }

        public StoryWord StoryWordSearch(PartOfSpeech? partOfSpeech, StoryThemeType? theme, SentimentType? sentiment, VividVisualImageryType? visual, VividEmotionalEvocationType? emotional, VividAuditoryImageryType? auditory)
        {
            var storyWords = this.storyWordMap.Values.ToList();
            var storyWordList = storyWords.Where(x => x.PartOfSpeech == partOfSpeech.GetValueOrDefault() 
            && x.StoryTheme == theme.GetValueOrDefault() 
            && x.Sentiment == sentiment.GetValueOrDefault() 
            && x.VividVisualImagery == visual.GetValueOrDefault() 
            && x.VividEmotionalEvocation == emotional.GetValueOrDefault() 
            && x.VividAuditoryImagery == auditory.GetValueOrDefault()).ToList();
            var storyWord = storyWordList[this.random.Next(storyWordList.Count)];
            return storyWord;
        }

        public List<StoryWord> FindSynonyms(StoryWord storyWord)
        {
            var word = wordMap[storyWord.WordText];
            var synonyms = word.Synonyms;
            var storyWords = this.storyWordMap.Values.ToList();
            var storyWordSynonyms = synonyms.Select(x => storyWords.Where(y => y.WordText == x.Text).FirstOrDefault()).ToList();
            return storyWordSynonyms;
        }

        public List<StoryWord> FindAntonyms(StoryWord storyWord)
        {
            var word = wordMap[storyWord.WordText];
            var antonyms = word.Antonyms;
            var storyWords = this.storyWordMap.Values.ToList();
            var storyWordAntonyms = antonyms.Select(x => storyWords.Where(y => y.WordText == x.Text).FirstOrDefault()).ToList();
            return storyWordAntonyms;
        }

        public void Generate()
        {
            Entity protagonist = new Entity();
            protagonist.Role = CharacterType.Protagonist;
            protagonist.Skill = TitleType.Husband;
            protagonist.Mood = MoodType.Happy;
            protagonist.Possessions.Add((PossessionType.Sword, CardinalityType.Singular));
            protagonist.Locations.Add(LocationType.Forest);
            this.storyContext.AddEntity(protagonist);

            Entity supportingCharacter = new Entity();
            supportingCharacter.Role = CharacterType.SupportingCharacter;
            supportingCharacter.Skill = TitleType.Wife;
            supportingCharacter.Mood = MoodType.Happy;
            supportingCharacter.Possessions.Add((PossessionType.Bow, CardinalityType.Singular));
            supportingCharacter.Locations.Add(LocationType.Forest);
            this.storyContext.AddEntity(supportingCharacter);

            Entity antagonist = new Entity();
            antagonist.Role = CharacterType.Antagonist;
            antagonist.Villain = VillainType.Giant;
            antagonist.Mood = MoodType.Sad;
            antagonist.Possessions.Add((PossessionType.BattleAx, CardinalityType.Limited));
            antagonist.Locations.Add(LocationType.Dungeon);
            this.storyContext.AddEntity(antagonist);

            protagonist.Relationships.Add((supportingCharacter, CharacterRelationshipType.Spouse));
            supportingCharacter.Relationships.Add((protagonist, CharacterRelationshipType.Spouse));
            antagonist.Relationships.Add((protagonist, CharacterRelationshipType.Enemy));

            // TODO: Work on conflicts and root causes and resolutions
        }
    }
}
