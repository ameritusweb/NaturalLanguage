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
            // Assumptions
            // Opinion: A caused B
            // Fact: If E then G, if G then H, if H then A
            // Narrative Progression: Figure out H, then G, then E
            // Discovery: Figure out E is not true
            // Temporary Conclusion: A did not cause B
            // Fact: If Not J And Not K, then G
            // Narrative Progression: Figure out J, then K
            // Discovery: J is false
            // Discovery: K is false
            // Conclusion: A did cause B
            // Narrative Progression: Arrest A

            /*
                Initial Assumptions and Opinions
                Opinion: Engineer Z caused the blackout during the grand gala, exploiting the event for personal gain.
                Assumption: Z had access and technical know-how to sabotage the ship’s power grid.
                First Set of Logical Deductions
                Fact 1: If X then Y, if Y then W, if W then Z suggests a sequence where system malfunctions lead directly back to Engineer Z.
                Narrative Progression: Investigate W, then Y, then X.
                First Discovery and Temporary Conclusion
                Discovery 1: X (critical system update) was actually successful, casting doubt on the initial sequence.
                Temporary Conclusion: Z did not cause the blackout, leading to a reevaluation of motives and opportunities.
                Introduction of New Evidence
                Fact 2: If Not A And Not B, then Y offers an alternate explanation for the power failure.
                Narrative Progression: Explore A (external sabotage), then B (natural cosmic phenomena).
                Further Discoveries
                Discovery 2: A is false; no evidence of external sabotage.
                Discovery 3: B is true; a rare cosmic storm disrupted the ship's power.
                Secondary Assumptions and Opinions
                Opinion: Guest M, with a grudge against Z, spread rumors blaming Z.
                Assumption: M manipulated the ship’s social network to discredit Z.
                Second Set of Logical Deductions
                Fact 3: If C then D, if D then M, if M then not Z introduces a new sequence implicating Guest M in a smear campaign.
                Narrative Progression: Validate C (rumor origin), follow to D (digital footprint), then confirm M.
                Second Discovery and Refined Conclusion
                Discovery 4: C is true, leading to D and confirming M’s actions.
                Refined Conclusion: M’s manipulation revealed, suggesting Z was unjustly accused.
                Final Layer of Investigation
                Fact 4: If E then F, if F then G, if G then resolve the mystery points towards the real cause of the blackout.
                Narrative Progression: Investigate E (ship’s AI logs), proving F (AI’s autonomous protective action during the storm), and establishing G (AI saved the ship from greater damage).
                Ultimate Discoveries and Conclusion
                Discovery 5: E is substantiated, leading to F and confirming G.
                Ultimate Conclusion: The AI's actions, though causing a temporary blackout, prevented a catastrophic failure during the cosmic storm.
                Narrative Conclusion
                Action: With the truth unveiled, the AI is hailed as a protector, and measures are taken to improve ship safety and storm prediction technologies.
                Resolution: Z is exonerated, and M faces consequences for the unfounded accusations, restoring Z's reputation.
             */
        }
    }
}
