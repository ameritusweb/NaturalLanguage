namespace NaturalLanguageProcess
{
    public class ExpositionGenerator
    {
        private ExpositionCollection expositionCollection;

        public ExpositionGenerator()
        {
            expositionCollection = new ExpositionCollection();
        }

        public List<string> GenerateSentencePairs(Scene scene, Character character)
        {
            var sentencePairs = new List<string>();
            var sentencePurposes = Enum.GetValues(typeof(SentencePurposeType)).Cast<SentencePurposeType>().ToList();

            // Create a dictionary to hold unified sentences for each purpose
            var unifiedSentencesByPurpose = new Dictionary<SentencePurposeType, List<string>>();

            // Populate the unified sentences dictionary
            foreach (var sentencePurpose in sentencePurposes)
            {
                var unifiedSentences = new List<string>();

                // Add sentences from expositions
                if (expositionCollection.Expositions.TryGetValue(sentencePurpose, out var sceneSentences))
                {
                    unifiedSentences.AddRange(sceneSentences.Select(sentence => sentence(scene)));
                }

                // Add sentences from characterExpositions
                if (expositionCollection.CharacterExpositions.TryGetValue(sentencePurpose, out var characterSentences))
                {
                    unifiedSentences.AddRange(characterSentences.Select(sentence => sentence(scene, character)));
                }

                unifiedSentencesByPurpose[sentencePurpose] = unifiedSentences;
            }

            // Generate pairs across different purpose types
            for (int i = 0; i < sentencePurposes.Count; i++)
            {
                for (int j = 0; j < sentencePurposes.Count; j++)
                {
                    if (i != j) // Ensure we're pairing sentences from different purpose types
                    {
                        var firstPurpose = sentencePurposes[i];
                        var secondPurpose = sentencePurposes[j];

                        int k = 0;
                        foreach (var firstSentence in unifiedSentencesByPurpose[firstPurpose])
                        {
                            int l = 0;
                            foreach (var secondSentence in unifiedSentencesByPurpose[secondPurpose])
                            {
                                var pair = $"{firstSentence.Replace(",", "")} {secondSentence.Replace(",", "")}, {firstPurpose}, {k}, {secondPurpose}, {l}";
                                sentencePairs.Add(pair);
                                l++;
                            }
                            k++;
                        }
                    }
                }
            }

            File.WriteAllLines("E:\\exposition\\sentencePairs.csv", sentencePairs);

            return sentencePairs;
        }
    }
}
