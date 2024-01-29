using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageProcess
{
    public class Word
    {
        public string Text { get; set; }
        public Vector3 Position { get; set; }
        public PartOfSpeech PartOfSpeech { get; set; }
        public HyponymRelationshipType HyponymRelationshipType { get; set; }
        public List<Word> Synonyms { get; set; } = new List<Word>();
        public List<Word> Antonyms { get; set; } = new List<Word>();
        public List<Word> Hypernyms { get; set; } = new List<Word>();
        public List<Word> Hyponyms { get; set; } = new List<Word>();

        public Word()
        {

        }

        public Word(string text)
        {
            Text = text;
        }

        public Word(string text, PartOfSpeech partOfSpeech)
        {
            Text = text;
            PartOfSpeech = partOfSpeech;
        }

        public SerializableWord Serialize()
        {
            return new SerializableWord()
            {
                SerializedWord = $"{Text}_{Position.X}_{Position.Y}_{Position.Z}_{(int)PartOfSpeech}_{(int)HyponymRelationshipType}_{string.Join(",", Synonyms.Select(x => x.Text))}_{string.Join(",", Antonyms.Select(x => x.Text))}_{string.Join(",", Hypernyms.Select(x => x.Text))}_{string.Join(",", Hyponyms.Select(x => x.Text))}"
            };
        }

        public static Dictionary<string, Word> DeserializePartial(List<SerializableWord> words)
        {
            Dictionary<string, Word> wordsMap = new Dictionary<string, Word>();
            foreach (var word in words)
            {
                var split = word.SerializedWord.Split('_');
                wordsMap.Add(split[0], new Word()
                {
                    Text = split[0],
                    Position = new Vector3(float.Parse(split[1]), float.Parse(split[2]), float.Parse(split[3])),
                    PartOfSpeech = (PartOfSpeech)int.Parse(split[4]),
                    HyponymRelationshipType = (HyponymRelationshipType)int.Parse(split[5])
                });
            }
            return wordsMap;
        }

        public static Word Deserialize(SerializableWord serializableWord, Dictionary<string, Word> wordsMap)
        {
            var split = serializableWord.SerializedWord.Split('_');
            var text = split[0];
            Word word = wordsMap[text];
            word.Synonyms = split[6].Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => wordsMap[x]).ToList();
            word.Antonyms = split[7].Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => wordsMap[x]).ToList();
            word.Hypernyms = split[8].Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => wordsMap[x]).ToList();
            word.Hyponyms = split[9].Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => wordsMap[x]).ToList();
            return word;
        }
    }
}
