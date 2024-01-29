using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace NaturalLanguageProcess
{
    public class ProcessDictionary
    {

        public static void GetPercentages()
        {
            var list = File.ReadAllText("E:\\alphabet\\scrabble.json", Encoding.UTF8);
            var words = JsonConvert.DeserializeObject<List<string>>(list);
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            string vowels = "aeiouy";
            string consonants = "bcdfghjklmnpqrstvwxz";
            string vowelsWithoutY = "aeiou";
            string consonantsWithY = "bcdfghjklmnpqrstvwxyz";
            List<string> cpairs = new List<string>();
            List<string> vpairs = new List<string>();
            List<string> newwords = new List<string>();
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            int max = 0;
            foreach (var word in words)
            {
                // convert hello to cvccv
                string pattern = string.Empty;
                int x = 0;
                int vCount = 0;
                int cCount = 0;
                foreach (var letter in word)
                {
                    if (vowels.Contains(letter) && !(letter == 'y' && x == 0))
                    {
                        if (vCount == 1)
                        {
                            vpairs.Add(word.Substring(x - 1, 2));
                        }
                        pattern += "v";
                        vCount++;
                        cCount = 0;
                    }
                    else
                    {
                        if (cCount == 1)
                        {
                            cpairs.Add(word.Substring(x - 1, 2));
                        }
                        pattern += "c";
                        cCount++;
                        vCount = 0;
                    }
                    x++;
                }
                if (!pattern.Contains("ccc") && !pattern.StartsWith("cc") && !pattern.Contains("vvv"))
                {
                    if (dictionary.ContainsKey(pattern))
                    {
                        dictionary[pattern]++;
                        if (dictionary[pattern] > max)
                        {
                            max = dictionary[pattern];
                        }
                    }
                    else
                    {
                        dictionary.Add(pattern, 1);
                    }
                }
            }

            Dictionary<string, double> percents = new Dictionary<string, double>();
            foreach (var item in dictionary)
            {
                
                var val = item.Value;
                for (int j = 0; j < val; ++j)
                {
                    string word = string.Empty;
                    int i = 0;
                    string lastC = "";
                    string lastV = "";
                    bool foundPair = false;
                    foreach (var letter in item.Key)
                    {
                        if (foundPair)
                        {
                            foundPair = false;
                            i++;
                            continue;   
                        }
                        if (letter == 'c' && item.Key.Length > (i + 1) && item.Key[i + 1] == 'c')
                        {
                            var randCC = rand.Next(0, cpairs.Count);
                            word += cpairs[randCC];
                            foundPair = true;
                        }
                        else if (letter == 'v' && item.Key.Length > (i + 1) && item.Key[i + 1] == 'v')
                        {
                            var randVV = rand.Next(0, vpairs.Count);
                            word += vpairs[randVV];
                            foundPair = true;
                        }
                        else if (letter == 'c')
                        {
                            if (i == 0)
                            {
                                var l = consonantsWithY.Replace(lastC == string.Empty ? "_" : lastC, "");
                                var randC = rand.Next(0, l.Length);
                                word += l[randC];
                            }
                            else
                            {
                                var l = consonants.Replace(lastC == string.Empty ? "_" : lastC, "");
                                var randC = rand.Next(0, l.Length);
                                word += l[randC];
                            }
                            lastC = word.Substring(word.Length - 1);
                            lastV = "";
                        } else if (letter == 'v')
                        {
                            if (i == 0)
                            {
                                var l = vowelsWithoutY.Replace(lastV == string.Empty ? "_" : lastV, "");
                                var randV = rand.Next(0, l.Length);
                                word += l[randV];
                            } else
                            {
                                var l = vowels.Replace(lastV == string.Empty ? "_" : lastV, "");
                                var randV = rand.Next(0, l.Length);
                                word += l[randV];
                            }
                            lastV = word.Substring(word.Length - 1);
                            lastC = "";
                        }
                        i++;
                    }
                    newwords.Add(word);
                }
                
                percents.Add(item.Key, (((double)item.Value / (double)max) * 100));
            }
            var ordered = percents.OrderByDescending(x => x.Value);
            var neewordsJson = JsonConvert.SerializeObject(newwords, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("E:\\alphabet\\newwords.json", neewordsJson);
        }

        public static void ConvertTextToJson(string inputFilePath, string outputFilePath)
        {
            var dictionary = new Dictionary<string, List<string>>();
            bool isKeyLine = true;
            string currentKey = string.Empty;
            HashSet<string> unique = new HashSet<string>();
            Dictionary<string, double> partsOfSpeech = new Dictionary<string, double>();
            partsOfSpeech.Add("noun", 0);
            partsOfSpeech.Add("verb", 0);
            partsOfSpeech.Add("adjective", 0);
            partsOfSpeech.Add("adverb", 0);
            partsOfSpeech.Add("preposition", 0);
            partsOfSpeech.Add("pronoun", 0);
            partsOfSpeech.Add("conjunction", 0);
            partsOfSpeech.Add("interjection", 0);

            using (var reader = new StreamReader(inputFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // Check if the line is a key line (uppercase word)
                    if (isKeyLine && !string.IsNullOrWhiteSpace(line) && Regex.IsMatch(line, "^[A-Z ]+$") && line.Trim() == line.Trim().ToUpper())
                    {
                        currentKey = line.Trim().ToLower();
                        isKeyLine = false; // The next line will be definitions and syllables
                    }
                    else
                    {
                        // Extract syllables from the line
                        if (!isKeyLine && !string.IsNullOrWhiteSpace(line))
                        {
                            int commaIndex = line.IndexOf(',');
                            if (commaIndex > -1)
                            {
                                var originalLine = line;
                                line = line.Substring(0, commaIndex);
                                // Assuming the syllables are separated by '*' or spaces and followed by a comma
                                var syllablesParts = line.Split(new[] { '*', '`', '"' }, StringSplitOptions.RemoveEmptyEntries);

                                List<string> syllables = new List<string>();
                                syllables.Add(line);
                                if (originalLine.Contains(", a."))
                                {
                                    syllables.Add("adjective");
                                    partsOfSpeech["adjective"]++;
                                }
                                else if (originalLine.Contains(", v."))
                                {
                                    syllables.Add("verb");
                                    partsOfSpeech["verb"]++;
                                }
                                else if (originalLine.Contains(", n.") || originalLine.Contains(", n,") || originalLine.Contains(") n.") || originalLine.Contains(", n;"))
                                {
                                    syllables.Add("noun");
                                    partsOfSpeech["noun"]++;
                                }
                                else if (originalLine.Contains(", adv."))
                                {
                                    syllables.Add("adverb");
                                    partsOfSpeech["adverb"]++;
                                }
                                else if (originalLine.Contains(", prep."))
                                {
                                    syllables.Add("preposition");
                                    partsOfSpeech["preposition"]++;
                                }
                                else if (originalLine.Contains(", p. p."))
                                {
                                    syllables.Add("past participle");
                                }
                                else if (originalLine.Contains(", pret."))
                                {
                                    syllables.Add("preterite");
                                }
                                else if (originalLine.Contains(", imp."))
                                {
                                    syllables.Add("imperfect");
                                }
                                else if (originalLine.Contains(", p. a."))
                                {
                                    syllables.Add("participle adjective");
                                }
                                else if (originalLine.Contains(", interj."))
                                {
                                    syllables.Add("interjection");
                                    partsOfSpeech["interjection"]++;
                                }
                                else if (originalLine.Contains(", conj."))
                                {
                                    syllables.Add("conjunction");
                                    partsOfSpeech["conjunction"]++;
                                }
                                else if (originalLine.Contains(", a ") || originalLine.EndsWith(", a", StringComparison.Ordinal))
                                {
                                    syllables.Add("adjective");
                                    partsOfSpeech["adjective"]++;
                                }
                                else if (originalLine.Contains(", pron."))
                                {
                                    syllables.Add("pronoun");
                                    partsOfSpeech["pronoun"]++;
                                }
                                else
                                {

                                }

                                if (syllables.Count == 2)
                                {
                                    if (!syllablesParts.Any(x => x.Contains("(") || x.Contains("[") || x.Trim().Contains(" ")))
                                    {
                                        foreach (var part in syllablesParts)
                                        {
                                            unique.Add(part);
                                        }

                                        syllables.AddRange(syllablesParts);


                                        if (!line.Substring(0, commaIndex).Contains(" "))
                                        {
                                            if (!dictionary.ContainsKey(currentKey))
                                            {
                                                dictionary.Add(currentKey, syllables);
                                            }
                                        }
                                        else if (!dictionary.ContainsKey(currentKey))
                                        {
                                            dictionary.Add(currentKey, new List<string>());
                                        }
                                    }
                                }
                            }
                            isKeyLine = true;
                        }
                        else
                        {
                            // An empty line indicates the end of the current entry and the start of a new key line
                            isKeyLine = true;
                        }
                    }
                }
            }

            var sumTotal = partsOfSpeech.Sum(x => x.Value);
            foreach (var pos in partsOfSpeech)
            {
                partsOfSpeech[pos.Key] = (double)pos.Value / (double)sumTotal * 100d;
            }

            var uniqueList = unique.ToList();

            string uniqueJson = JsonConvert.SerializeObject(uniqueList, Newtonsoft.Json.Formatting.Indented);

            //File.WriteAllText("E:\\alphabet\\unique.json", uniqueJson);

            // Serialize the dictionary to JSON
            string json = JsonConvert.SerializeObject(partsOfSpeech, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText("E:\\alphabet\\partsOfSpeech.json", json);

            // Write JSON to file
            //File.WriteAllText(outputFilePath, json);
        }
    }
}
