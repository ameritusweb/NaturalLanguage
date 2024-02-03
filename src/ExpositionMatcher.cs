using System.Text.RegularExpressions;

namespace NaturalLanguageProcess
{
    public class ExpositionMatcher
    {
        private ExpositionCollection expositionCollection;

        public ExpositionMatcher(ExpositionCollection expositionCollection)
        {
            this.expositionCollection = expositionCollection;
        }

        public List<(SentencePurposeType, int, SentencePurposeType, int)> FindMatchingPairs()
        {
            var sceneWithPlaceholders = Scene.GenerateWithPlaceholders();
            var sceneProperties = typeof(Scene).GetProperties();
            Dictionary<string, string> scenePropertyNames = new Dictionary<string, string>();
            foreach (var sceneProperty in sceneProperties)
            {
                scenePropertyNames.Add((sceneProperty.GetValue(sceneWithPlaceholders) as StoryWord).WordText, sceneProperty.Name);
            }

            List<(SentencePurposeType, int, SentencePurposeType, int)> matchedPairs = new List<(SentencePurposeType, int, SentencePurposeType, int)>();
            HashSet<string> unmatched = new HashSet<string>();
            foreach (var pair in expositionCollection.PurposePairs)
            {
                if (expositionCollection.Expositions.ContainsKey(pair.Item1) && expositionCollection.Expositions.ContainsKey(pair.Item2))
                {
                    var firstList = expositionCollection.Expositions[pair.Item1];
                    var secondList = expositionCollection.Expositions[pair.Item2];

                    for (int i = 0; i < firstList.Count; i++)
                    {
                        var firstSentence = firstList[i].Invoke(sceneWithPlaceholders); // Simulating Scene parameter
                        var firstMatches = ExtractPlaceholders(firstSentence);

                        if (firstMatches.Any())
                        {
                            bool found = false;
                            for (int j = 0; j < secondList.Count; j++)
                            {
                                var secondSentence = secondList[j].Invoke(sceneWithPlaceholders); // Simulating Scene parameter
                                var secondMatches = ExtractPlaceholders(secondSentence);

                                if (firstMatches.Intersect(secondMatches).Any())
                                {
                                    matchedPairs.Add((pair.Item1, i, pair.Item2, j));
                                    found = true;
                                }
                            }

                            if (!found)
                            {
                                unmatched.Add(pair.Item2.ToString() + " " + string.Join(", ", firstMatches.Select(x => scenePropertyNames[x])));
                            }
                        }
                    }
                }
            }

            File.WriteAllLines("E:\\exposition\\unmatched.txt", unmatched.ToList().OrderBy(x => x));

            return matchedPairs;
        }

        private HashSet<string> ExtractPlaceholders(string sentence)
        {
            var matches = Regex.Matches(sentence, @"\$([S|C]\d+)\$");
            return new HashSet<string>(matches.Cast<Match>().Select(match => match.Value));
        }
    }
}
