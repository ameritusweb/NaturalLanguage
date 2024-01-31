using NaturalLanguageProcess.Logic;
using Newtonsoft.Json;

namespace NaturalLanguageProcess
{
    public class StoryGenerator
    {

        private StoryContext storyContext;
        private Dictionary<string, Word> wordMap;
        private Dictionary<string, StoryWord> storyWordMap;

        public StoryGenerator()
        {
            this.storyContext = new StoryContext();
            this.wordMap = new Dictionary<string, Word>();
            this.storyWordMap = new Dictionary<string, StoryWord>();
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
            var storyWord = storyWords.Where(x => x.PartOfSpeech == partOfSpeech.GetValueOrDefault() 
            && x.StoryTheme == theme.GetValueOrDefault() 
            && x.Sentiment == sentiment.GetValueOrDefault() 
            && x.VividVisualImagery == visual.GetValueOrDefault() 
            && x.VividEmotionalEvocation == emotional.GetValueOrDefault() 
            && x.VividAuditoryImagery == auditory.GetValueOrDefault()).FirstOrDefault();
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
            this.storyContext.AddEntity(protagonist);

            Entity antagonist = new Entity();
            antagonist.Role = CharacterType.Antagonist;
            antagonist.Villain = VillainType.Giant;
            antagonist.Mood = MoodType.Sad;
            this.storyContext.AddEntity(antagonist);
        }
    }
}
