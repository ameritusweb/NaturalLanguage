namespace NaturalLanguageProcess.Logic
{
    public class CharacteristicRule : ILogicalRule
    {
        public StoryWord Noun1 { get; set; }
        public StoryWord Adjective1 { get; set; }
        public StoryWord Noun2 { get; set; }
        public StoryWord Adjective2 { get; set; }

        public CharacteristicRule(StoryWord noun1, StoryWord adjective1, StoryWord noun2, StoryWord adjective2)
        {
            Noun1 = noun1;
            Adjective1 = adjective1;
            Noun2 = noun2;
            Adjective2 = adjective2;
        }

        public bool Evaluate(StoryContext context)
        {
            return context.HasCharacteristicOccurred(Noun1, Adjective1);
        }

        public void Apply(StoryContext context)
        {
            context.RecordCharacteristic(Noun2, Adjective2);
        }

    }
}
