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

        public Dictionary<(SentencePurposeType, int), List<(SentencePurposeType, int)>> FindMatchingPairs()
        {
            Dictionary<(SentencePurposeType, int), List<(SentencePurposeType, int)>> matchingPairs = new Dictionary<(SentencePurposeType, int), List<(SentencePurposeType, int)>>();
            var sceneWithPlaceholders = Scene.GenerateWithPlaceholders();
            var sceneProperties = typeof(Scene).GetProperties();
            Dictionary<string, string> scenePropertyNames = new Dictionary<string, string>();
            foreach (var sceneProperty in sceneProperties)
            {
                if (sceneProperty.PropertyType != typeof(StoryWord))
                {
                    continue;
                }
                scenePropertyNames.Add((sceneProperty.GetValue(sceneWithPlaceholders) as StoryWord).WordText, sceneProperty.Name);
            }
            List<string> sentencePairs = new List<string>();

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
                                    sentencePairs.Add($"{ReplacePlaceholders(sceneWithPlaceholders, firstSentence)} || {ReplacePlaceholders(sceneWithPlaceholders, secondSentence)}");
                                    matchedPairs.Add((pair.Item1, i, pair.Item2, j));
                                    if (matchingPairs.ContainsKey((pair.Item1, i)))
                                    {
                                        matchingPairs[(pair.Item1, i)].Add((pair.Item2, j));
                                    }
                                    else
                                    {
                                        matchingPairs.Add((pair.Item1, i), new List<(SentencePurposeType, int)> { (pair.Item2, j) });
                                    }
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
            // File.WriteAllLines("E:\\exposition\\pairs.txt", sentencePairs);

            return matchingPairs;
        }

        private string ReplacePlaceholders(Scene scene, string sentence)
        {
            var map = scene.Placeholders;
            var matches = Regex.Matches(sentence, @"\$([S|C]\d+)\$");
            foreach (Match match in matches)
            {
                var placeholder = match.Value;
                var propertyName = map[placeholder];
                sentence = sentence.Replace(placeholder, $"'{propertyName}'");
            }
            return sentence;
        }

        private HashSet<string> ExtractPlaceholders(string sentence)
        {
            var matches = Regex.Matches(sentence, @"\$([S|C]\d+)\$");
            return new HashSet<string>(matches.Cast<Match>().Select(match => match.Value));
        }
    }
}
