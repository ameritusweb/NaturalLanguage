using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageProcess
{
    public class WordSphere
    {
        private List<Word> words = new List<Word>();
        private Dictionary<PartOfSpeech, List<Word>> wordsByPos = new Dictionary<PartOfSpeech, List<Word>>();
        private Dictionary<PartOfSpeech, List<Word>> antonymWordsByPos = new Dictionary<PartOfSpeech, List<Word>>();
        private int wordCount;
        private Dictionary<string, Word> wordMap = new Dictionary<string, Word>();
         
        public List<string> Serialize() {             
            var serializedWords = new List<string>();
            foreach (var word in words)
            {
                wordMap[word.Text] = word;
                serializedWords.Add(word.Serialize().SerializedWord);
            }
            return serializedWords;
        }

        public WordSphere(float rInner, float rOuter, int totalWords, List<Word> initialWords)
        {
            this.wordCount = totalWords / 2;  // Use only half of the total words for initial placement

            // Ensure initialWords has at least 'wordCount' words
            if (initialWords.Count < wordCount)
            {
                throw new ArgumentException($"Initial words list must contain at least {wordCount} words.");
            }

            int groupIndex = 0;

            for (int i = 0; i < wordCount; i++)
            {
                Word word = initialWords[i];
                float radius = (groupIndex % 9 == 4) ? rInner : rOuter; // Place hypernyms on the inner sphere

                PlaceWordOnSphere(word, i, radius);

                // Connect hyponyms to their hypernym
                if (groupIndex % 9 != 4) // If it's not a hypernym
                {
                    // The hypernym is the 5th word in each group of 9
                    int hypernymIndex = (i / 9) * 9 + 4; // Calculate the index of the hypernym in the current group
                    if (initialWords.Count > hypernymIndex)
                    {
                        word.HyponymRelationshipType = (HyponymRelationshipType)(groupIndex % 9); // Set the hyponym relationship type
                        ConnectHypernymHyponym(word, initialWords[hypernymIndex]);
                    }
                }

                groupIndex++;
            }

            AssignAntonyms(initialWords.Skip(wordCount).ToList());

            groupIndex = 0;

            for (int i = 0; i < wordCount; ++i)
            {
                Word word = initialWords[i];
                float radius = groupIndex % 9 == 4 ? rInner : rOuter;  // Alternate between inner and outer sphere
                UpdateSynonyms(word, radius);

                groupIndex++;
            }

            // Update synonyms for antonyms
            UpdateAntonymsSynonyms();
        }

        private void PlaceWordOnSphere(Word word, int index, float radius)
        {
            // Calculate the increments for phi and theta based on wordCount
            double phiIncrement = Math.PI / 2 / Math.Ceiling(Math.Sqrt(wordCount)); // Increment for phi to cover a hemisphere
            double thetaIncrement = 2 * Math.PI / wordCount; // Increment for theta

            // Calculate the indices for phi and theta
            double phi = phiIncrement * (index % wordCount); // Ensure phi varies gradually
            double theta = thetaIncrement * (index / (wordCount / Math.Sqrt(wordCount))); // Distribute theta more evenly

            word.Position = new Vector3(
            radius * (float)Math.Sin(phi) * (float)Math.Cos(theta),
            radius * (float)Math.Sin(phi) * (float)Math.Sin(theta),
            radius * (float)Math.Cos(phi));

            // Add the positioned word to the words list and the wordsByPos dictionary
            words.Add(word);
            if (!wordsByPos.ContainsKey(word.PartOfSpeech))
                wordsByPos[word.PartOfSpeech] = new List<Word>();

            wordsByPos[word.PartOfSpeech].Add(word);
        }

        private void UpdateSynonyms(Word newWord, float radius)
        {
            // Define the number of synonyms you want to consider for each word
            int N = 5; // Example: Each word will have 5 synonyms

            // Filter words by the same POS and on the same sphere (inner or outer based on radius)
            var samePosWords = wordsByPos[newWord.PartOfSpeech]
                .Where(w => w != newWord && Math.Abs(w.Position.Length() - radius) < 0.001f)
                .ToList();

            // Calculate distances from the new word to each word with the same POS on the same sphere
            var distances = samePosWords.Select(w => new { Word = w, Distance = Vector3.Distance(newWord.Position, w.Position) });

            // Order by distance and take the N closest words as synonyms
            var closestSynonyms = distances.OrderBy(d => d.Distance).Take(N).Select(d => d.Word).ToList();

            // Update the synonyms list for the new word
            newWord.Synonyms.Clear();
            newWord.Synonyms.AddRange(closestSynonyms);

            // Optionally, update the synonyms lists for the chosen synonyms as well, making the relationship bidirectional
            foreach (var synonym in closestSynonyms)
            {
                if (!synonym.Synonyms.Contains(newWord) && synonym.Synonyms.Count < N)
                {
                    synonym.Synonyms.Add(newWord);
                }
            }
        }

        private void AssignAntonyms(List<Word> remainingWords)
        {
            for (int i = 0; i < words.Count; i++)
            {
                Word word = words[i];

                if (i < remainingWords.Count)
                {
                    Word antonym = remainingWords[i];

                    // Assign the antonym the same part of speech as the original word
                    antonym.PartOfSpeech = word.PartOfSpeech;

                    // Place the antonym at the antipodal point of the original word
                    antonym.Position = new Vector3(-word.Position.X, -word.Position.Y, -word.Position.Z);

                    // Establish the antonym relationship
                    if (word.Antonyms.Count < 5)
                    {
                        word.Antonyms.Add(antonym);
                    }
                    if (antonym.Antonyms.Count < 5)
                    {
                        antonym.Antonyms.Add(word); // Optional: for bidirectional antonymy
                    }

                    // Add the antonym to the antonymWordsByPos dictionary
                    if (!antonymWordsByPos.ContainsKey(antonym.PartOfSpeech))
                    {
                        antonymWordsByPos[antonym.PartOfSpeech] = new List<Word>();
                    }
                    antonymWordsByPos[antonym.PartOfSpeech].Add(antonym);

                    // Add the antonym to the main words list
                    words.Add(antonym);

                    foreach (var hyponym in word.Hyponyms)
                    {
                        foreach (var hypoA in word.Antonyms)
                        {
                            foreach (var hyponymAntonym in hyponym.Antonyms)
                            {
                                hyponymAntonym.Hypernyms.Add(hypoA);
                                hypoA.Hyponyms.Add(hyponymAntonym);
                            }
                        }
                    }

                    foreach (var hypernym in word.Hypernyms)
                    {
                        foreach (var hyperA in word.Antonyms)
                        {
                            foreach (var hypernymAntonym in hypernym.Antonyms)
                            {
                                hypernymAntonym.Hyponyms.Add(hyperA);
                                hyperA.Hypernyms.Add(hypernymAntonym);
                            }
                        }
                    }
                }
            }
        }

        private void ConnectHypernymHyponym(Word hyponym, Word hypernym)
        {
            hypernym.Hyponyms.Add(hyponym);
            hyponym.Hypernyms.Add(hypernym);
        }

        private void UpdateAntonymsSynonyms()
        {
            // Iterate over antonyms
            foreach (var kvp in antonymWordsByPos)
            {
                PartOfSpeech pos = kvp.Key;
                List<Word> antonymsOfPos = kvp.Value;

                foreach (var antonym in antonymsOfPos)
                {
                    float radius = antonym.Position.Length();

                    // Potential synonyms are other antonyms with the same POS and on the same sphere
                    var potentialSynonyms = antonymWordsByPos[pos]
                        .Where(a => a != antonym && Math.Abs(a.Position.Length() - radius) < 0.001f)
                        .ToList();

                    // Calculate distances from the antonym to each potential synonym
                    var distances = potentialSynonyms.Select(a => new { Word = a, Distance = Vector3.Distance(antonym.Position, a.Position) });

                    // Order by distance and take the N closest words as synonyms
                    int N = 5; // Define the number of synonyms you want to consider for each antonym
                    var closestSynonyms = distances.OrderBy(d => d.Distance).Take(N).Select(d => d.Word).ToList();

                    antonym.Synonyms.AddRange(closestSynonyms);

                    foreach (var synonym in closestSynonyms)
                    {
                        foreach (var ant in antonym.Antonyms)
                        {
                            if (!synonym.Antonyms.Contains(ant) && synonym.Antonyms.Count < N)
                            {
                                synonym.Antonyms.Add(ant);
                            }
                        }
                    }

                    // Set the found synonyms as the antonyms of the original antonym's antonyms
                    foreach (var originalAntonym in antonym.Antonyms)
                    {
                        foreach (var ss in closestSynonyms)
                        {
                            if (originalAntonym.Antonyms.Count >= N)
                                break;
                            originalAntonym.Antonyms.Add(ss);
                        }
                    }
                }
            }
        }
    }
}
