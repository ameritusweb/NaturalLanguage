using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageProcess
{
    public class WordSpherePopulater
    {
        public void Populate()
        {
            var words = File.ReadAllText("E:\\alphabet\\newwords.json");
            var newwords = JsonConvert.DeserializeObject<List<string>>(words);
            HashSet<string> set = new HashSet<string>(newwords);
            newwords = set.ToList();

            Random rand = new Random(Guid.NewGuid().GetHashCode());
            newwords = newwords.OrderBy(x => rand.Next()).ToList();

            int maxWords = 100008;
            var list = newwords.Take(maxWords).ToList();
            var sublist = list.Take(maxWords / 2).ToList();
            var otherlist = list.Skip(maxWords / 2).ToList();
            var random = sublist.Select(x => rand.NextDouble()).ToList();
            double[] decimals = new double[] { 0.5588d, 0.1574d, 0.2436d, 0.0365d, 0.00066d, 0.001222d, 0.00055d,  };
            //double[] decimals = new double[] { 0.5588d, 0.2005d, 0.2005d, 0.0365d, 0.00066d, 0.001222d, 0.00055d, };
            var sublistWithPartsOrSpeech = sublist.Select((x, i) => { 
                if (random[i] < decimals[0])
                {
                    return new Word(x, PartOfSpeech.Noun);
                }
                else if (random[i] < decimals.Take(2).Sum())
                {
                    return new Word(x, PartOfSpeech.Verb);
                }
                else if (random[i] < decimals.Take(3).Sum())
                {
                    return new Word(x, PartOfSpeech.Adjective);
                }
                else if (random[i] < decimals.Take(4).Sum())
                {
                    return new Word(x, PartOfSpeech.Adverb);
                }
                else if (random[i] < decimals.Take(5).Sum())
                {
                    return new Word(x, PartOfSpeech.Pronoun);
                }
                else if (random[i] < decimals.Take(6).Sum())
                {
                    return new Word(x, PartOfSpeech.Preposition);
                }
                else if (random[i] < decimals.Take(7).Sum())
                {
                    return new Word(x, PartOfSpeech.Conjunction);
                }
                else
                {
                    return new Word(x, PartOfSpeech.Interjection);
                }
            }).ToList();

            var concatList = sublistWithPartsOrSpeech.Concat(otherlist.Select(x => new Word(x))).ToList();

            WordSphere sphere = new WordSphere(100, 1000, list.Count, concatList);
            var serializedWords = sphere.Serialize();
            File.WriteAllText("E:\\alphabet\\wordsphere.json", JsonConvert.SerializeObject(serializedWords));
        }
    }
}
