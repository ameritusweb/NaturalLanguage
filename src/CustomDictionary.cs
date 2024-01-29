using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageProcess
{
    public class CustomDictionary
    {
        public Dictionary<string, Word> Words { get; set; } = new Dictionary<string, Word>();
        public Dictionary<PartOfSpeech, List<Word>> WordsByPartOfSpeech { get; set; } = new Dictionary<PartOfSpeech, List<Word>>();
        
        private Dictionary<PartOfSpeech, List<List<Word>>> Groups { get; set; } = new Dictionary<PartOfSpeech, List<List<Word>>>();
        private Dictionary<AdverbialAdjectiveType, List<Word>> AdverbialAdjectives { get; set; } = new Dictionary<AdverbialAdjectiveType, List<Word>>();
        private Dictionary<StoryThemeType, List<Word>> StoryThemes { get; set; } = new Dictionary<StoryThemeType, List<Word>>();
        private Dictionary<SentimentType, List<Word>> Sentiments { get; set; } = new Dictionary<SentimentType, List<Word>>();
        private Dictionary<VividVisualImageryType, List<Word>> Visuals { get; set; } = new Dictionary<VividVisualImageryType, List<Word>>();
        private Dictionary<VividAuditoryImageryType, List<Word>> Auditories { get; set; } = new Dictionary<VividAuditoryImageryType, List<Word>>();
        private Dictionary<VividEmotionalEvocationType, List<Word>> Emotionals { get; set; } = new Dictionary<VividEmotionalEvocationType, List<Word>>();
        private Dictionary<(VividVisualImageryType, VividEmotionalEvocationType, VividAuditoryImageryType), Word> NounCombinations = new Dictionary<(VividVisualImageryType, VividEmotionalEvocationType, VividAuditoryImageryType), Word>();
        private Dictionary<(VividVisualImageryType, VividEmotionalEvocationType, VividAuditoryImageryType), Word> VerbCombinations = new Dictionary<(VividVisualImageryType, VividEmotionalEvocationType, VividAuditoryImageryType), Word>();
        private Dictionary<(VividVisualImageryType, VividEmotionalEvocationType, VividAuditoryImageryType), Word> AdjectiveCombinations = new Dictionary<(VividVisualImageryType, VividEmotionalEvocationType, VividAuditoryImageryType), Word>();
        private Dictionary<string, StoryWord> StoryWords { get; set; } = new Dictionary<string, StoryWord>();
        
        public void CreateGroups()
        {
            int nounCount = 0;
            foreach (var pair in WordsByPartOfSpeech)
            {
                Groups.Add(pair.Key, new List<List<Word>>());
                List<string> wordsUsed = new List<string>();
                var pos = pair.Key;
                var list = pair.Value;
                List<string> ww = new List<string>();
                foreach (var item in list)
                {
                    var synonyms = item.Synonyms.Select(x => x.Text).ToList();
                    List<string> ll = synonyms.Append(item.Text).ToList();
                    List<string> exclude = new List<string>();
                    foreach (var www in ll)
                    {
                        if (wordsUsed.Contains(www))
                        {
                            exclude.Add(www);
                            continue;
                        }
                        wordsUsed.Add(www);
                    }
                    List<string> res = ll.Except(exclude).ToList();
                    ww.AddRange(res);
                    if (ww.Count > 4)
                    {
                        foreach (var www in ww)
                        {
                            StoryWord storyWord = new StoryWord(Words[www], Guid.NewGuid());
                            if (pos == PartOfSpeech.Noun)
                            {
                                ClassifyNoun(storyWord, nounCount);
                                nounCount++;
                            }
                            StoryWords.Add(www, storyWord);
                        }
                        Groups[pair.Key].Add(ww.Select(x => Words[x]).ToList());
                        ww.Clear();
                    }
                }
            }

            Dictionary<PartOfSpeech, int> countMap = new Dictionary<PartOfSpeech, int>();
            countMap.Add(PartOfSpeech.Noun, 0);
            countMap.Add(PartOfSpeech.Verb, 0);
            countMap.Add(PartOfSpeech.Adjective, 0);

            // adverbial adjectives
            var group = Groups[PartOfSpeech.Adjective];
            int i = 0;
            foreach (var adverbial in Enum.GetValues(typeof(AdverbialAdjectiveType)).Cast<AdverbialAdjectiveType>())
            {
                foreach (var www in group[i])
                {
                    StoryWord storyWord = StoryWords[www.Text];
                    storyWord.AdverbialAdjective = adverbial;
                }
                AdverbialAdjectives.Add(adverbial, group[i]);
                i++;
            }
            countMap[PartOfSpeech.Adjective] += i;

            // story themes
            foreach (var groupPair in Groups)
            {
                var pos = groupPair.Key;
                if (pos == PartOfSpeech.Noun || pos == PartOfSpeech.Verb)
                {
                    var list = groupPair.Value;
                    int ii = countMap[pos];
                    foreach (var storyTheme in Enum.GetValues(typeof(StoryThemeType)).Cast<StoryThemeType>())
                    {
                        if (StoryThemes.ContainsKey(storyTheme))
                        {
                            StoryThemes[storyTheme].AddRange(list[ii]);
                        }
                        else
                        {
                            StoryThemes.Add(storyTheme, list[ii]);
                        }
                        foreach (var www in list[ii])
                        {
                            StoryWord storyWord = StoryWords[www.Text];
                            storyWord.StoryTheme = storyTheme;
                        }
                        ii++;
                    }
                    countMap[pos] = ii;
                }
            }

            // sentiments
            foreach (var groupPair in Groups)
            {
                var pos = groupPair.Key;
                if (pos == PartOfSpeech.Noun || pos == PartOfSpeech.Verb)
                {
                    var list = groupPair.Value;
                    int ii = countMap[pos];
                    foreach (var sentiment in Enum.GetValues(typeof(SentimentType)).Cast<SentimentType>())
                    {
                        if (Sentiments.ContainsKey(sentiment))
                        {
                            Sentiments[sentiment].AddRange(list[ii]);
                        }
                        else
                        {
                            Sentiments.Add(sentiment, list[ii]);
                        }
                        foreach (var www in list[ii])
                        {
                            StoryWord storyWord = StoryWords[www.Text];
                            storyWord.Sentiment = sentiment;
                        }
                        ii++;
                    }
                    countMap[pos] = ii;
                }
            }

            // visuals
            foreach (var groupPair in Groups)
            {
                var pos = groupPair.Key;
                if (pos == PartOfSpeech.Noun || pos == PartOfSpeech.Verb || pos == PartOfSpeech.Adjective)
                {
                    var list = groupPair.Value;
                    int ii = countMap[pos];
                    foreach (var visual in Enum.GetValues(typeof(VividVisualImageryType)).Cast<VividVisualImageryType>())
                    {
                        if (Visuals.ContainsKey(visual))
                        {
                            Visuals[visual].AddRange(list[ii]);
                        }
                        else
                        {
                            Visuals.Add(visual, list[ii]);
                        }
                        foreach (var www in list[ii])
                        {
                            StoryWord storyWord = StoryWords[www.Text];
                            storyWord.VividVisualImagery = visual;
                        }
                        ii++;
                    }
                    countMap[pos] = ii;
                }
            }

            // auditories
            foreach (var groupPair in Groups)
            {
                var pos = groupPair.Key;
                if (pos == PartOfSpeech.Noun || pos == PartOfSpeech.Verb || pos == PartOfSpeech.Adjective)
                {
                    var list = groupPair.Value;
                    int ii = countMap[pos];
                    foreach (var auditory in Enum.GetValues(typeof(VividAuditoryImageryType)).Cast<VividAuditoryImageryType>())
                    {
                        if (Auditories.ContainsKey(auditory))
                        {
                            Auditories[auditory].AddRange(list[ii]);
                        }
                        else
                        {
                            Auditories.Add(auditory, list[ii]);
                        }
                        foreach (var www in list[ii])
                        {
                            StoryWord storyWord = StoryWords[www.Text];
                            storyWord.VividAuditoryImagery = auditory;
                        }
                        ii++;
                    }
                    countMap[pos] = ii;
                }
            }

            // emotionals
            foreach (var groupPair in Groups)
            {
                var pos = groupPair.Key;
                if (pos == PartOfSpeech.Noun || pos == PartOfSpeech.Verb || pos == PartOfSpeech.Adjective)
                {
                    var list = groupPair.Value;
                    int ii = countMap[pos];
                    foreach (var emotional in Enum.GetValues(typeof(VividEmotionalEvocationType)).Cast<VividEmotionalEvocationType>())
                    {
                        if (Emotionals.ContainsKey(emotional))
                        {
                            Emotionals[emotional].AddRange(list[ii]);
                        }
                        else
                        {
                            Emotionals.Add(emotional, list[ii]);
                        }
                        foreach (var www in list[ii])
                        {
                            StoryWord storyWord = StoryWords[www.Text];
                            storyWord.VividEmotionalEvocation = emotional;
                        }
                        ii++;
                    }
                    countMap[pos] = ii;
                }
            }

            BuildCombinations(PartOfSpeech.Noun, countMap, NounCombinations);
            BuildCombinations(PartOfSpeech.Verb, countMap, VerbCombinations);
            BuildCombinations(PartOfSpeech.Adjective, countMap, AdjectiveCombinations);

            var storyWordsList = StoryWords.Values.ToList();
            using (StreamWriter file = File.CreateText(@"E:\alphabet\storywords.json"))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                JsonSerializer serializer = new JsonSerializer();
                // Customize the serializer if needed (e.g., settings)
                serializer.Serialize(writer, storyWordsList);
            }
        }

        public void ClassifyNoun(StoryWord storyWord, int nounCount)
        {
            int personCount = Enum.GetValues(typeof(PersonType)).Cast<PersonType>().Count();
            int placeCount = Enum.GetValues(typeof(PlaceType)).Cast<PlaceType>().Count();
            int ideaCount = Enum.GetValues(typeof(IdeaType)).Cast<IdeaType>().Count();
            int thingCount = personCount + placeCount + ideaCount;
            int nounIndex = nounCount % (thingCount + personCount + placeCount + ideaCount);
            if (nounIndex < thingCount)
            {
                storyWord.Noun = NounType.Thing;
            }
            else if (nounIndex < thingCount + personCount)
            {
                storyWord.Noun = NounType.Person;
                storyWord.Person = (PersonType)(nounIndex % (personCount - thingCount));
            }
            else if (nounIndex < thingCount + personCount + placeCount)
            {
                storyWord.Noun = NounType.Place;
                storyWord.Place = (PlaceType)(nounIndex % (placeCount - (personCount + thingCount)));
            } else
            {
                storyWord.Noun = NounType.Idea;
                storyWord.Idea = (IdeaType)(nounIndex % (ideaCount - (personCount + placeCount + thingCount)));
            }
        }

        public void BuildCombinations(PartOfSpeech pos, Dictionary<PartOfSpeech, int> countMap, Dictionary<(VividVisualImageryType, VividEmotionalEvocationType, VividAuditoryImageryType), Word> combinations)
        {
            // combinations
            var groupN = Groups[pos];
            int visualCount = 0;
            int emotionalCount = 0;
            int auditoryCount = 0;
            var visualValues = Enum.GetValues(typeof(VividVisualImageryType)).Cast<VividVisualImageryType>().ToList();
            var emotionalValues = Enum.GetValues(typeof(VividEmotionalEvocationType)).Cast<VividEmotionalEvocationType>().ToList();
            var auditoryValues = Enum.GetValues(typeof(VividAuditoryImageryType)).Cast<VividAuditoryImageryType>().ToList();
            bool stop = false;
            foreach (var list in groupN.Skip(countMap[pos]))
            {
                foreach (var inner in list)
                {
                    while (true)
                    {
                        if ((visualCount > 0 && emotionalCount > 0) || (visualCount > 0 && auditoryCount > 0) || (emotionalCount > 0 && auditoryCount > 0))
                        {
                            if (!(visualCount > 0 && emotionalCount > 0 && auditoryCount > 0))
                            {
                                combinations.Add((visualValues[visualCount], emotionalValues[emotionalCount], auditoryValues[auditoryCount]), inner);

                                var storyWord = StoryWords[inner.Text];
                                storyWord.VividVisualImagery = visualValues[visualCount];
                                storyWord.VividEmotionalEvocation = emotionalValues[emotionalCount];
                                storyWord.VividAuditoryImagery = auditoryValues[auditoryCount];

                                if (auditoryCount == auditoryValues.Count - 1)
                                {
                                    auditoryCount = 0;
                                    if (emotionalCount == emotionalValues.Count - 1)
                                    {
                                        emotionalCount = 0;
                                        if (visualCount == visualValues.Count - 1)
                                        {
                                            visualCount = 0;
                                            stop = true;
                                            break;
                                        }
                                        else
                                        {
                                            visualCount++;
                                        }
                                    }
                                    else
                                    {
                                        emotionalCount++;
                                    }
                                }
                                else
                                {
                                    auditoryCount++;
                                }

                                break;
                            }
                        }
                        if (auditoryCount == auditoryValues.Count - 1)
                        {
                            auditoryCount = 0;
                            if (emotionalCount == emotionalValues.Count - 1)
                            {
                                emotionalCount = 0;
                                if (visualCount == visualValues.Count - 1)
                                {
                                    visualCount = 0;
                                    stop = true;
                                    break;
                                }
                                else
                                {
                                    visualCount++;
                                }
                            }
                            else
                            {
                                emotionalCount++;
                            }
                        }
                        else
                        {
                            auditoryCount++;
                        }
                    }
                    if (stop)
                    {
                        break;
                    }
                }
                if (stop)
                {
                    break;
                }
            }
        }

        public void Deserialize(List<SerializableWord> words)
        {
            var wordsMap = Word.DeserializePartial(words);
            foreach (var serializableWord in words)
            {
                var word = Word.Deserialize(serializableWord, wordsMap);
                Words.Add(word.Text, word);
                if (!WordsByPartOfSpeech.ContainsKey(word.PartOfSpeech))
                {
                    WordsByPartOfSpeech.Add(word.PartOfSpeech, new List<Word>());
                }
                WordsByPartOfSpeech[word.PartOfSpeech].Add(word);
            }
        }
    }
}
