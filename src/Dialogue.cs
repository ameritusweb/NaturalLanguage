namespace NaturalLanguageProcess
{
    public class Dialogue
    {
        private StoryGenerator storyGenerator;

        public SentencePurposeType BeginPurpose { get; set; }

        public Dialogue(StoryGenerator storyGenerator)
        {
            this.storyGenerator = storyGenerator;
        }

        public Scene PopulateScene()
        {
            Scene scene = new Scene();
            scene.AControversialDecisionMade = storyGenerator.GenerateControversialDecision();
            return scene;
        }
    }
}
