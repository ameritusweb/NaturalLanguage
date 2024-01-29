namespace NaturalLanguageProcess
{
    public class StoryWord
    {
        public string WordText { get; set; }

        public PartOfSpeech PartOfSpeech { get; set; }

        public Guid GroupId { get; set; }

        public Guid SpecificId { get; set; }

        public NounType Noun { get; set; }

        public PersonType Person { get; set; }

        public PlaceType Place { get; set; }

        public IdeaType Idea { get; set; }

        public AdverbialAdjectiveType AdverbialAdjective { get; set; }

        public TenseType Tense { get; set; }
        
        public StoryThemeType StoryTheme { get; set; }

        public SentimentType Sentiment { get; set; }

        public VividVisualImageryType VividVisualImagery { get; set; }

        public VividEmotionalEvocationType VividEmotionalEvocation { get; set; }

        public VividAuditoryImageryType VividAuditoryImagery { get; set; }

        public StoryWord(Word word, Guid groupId)
        {
            this.WordText = word.Text;
            this.PartOfSpeech = word.PartOfSpeech;
            this.GroupId = groupId;
            this.SpecificId = Guid.NewGuid();
        }
    }
}
