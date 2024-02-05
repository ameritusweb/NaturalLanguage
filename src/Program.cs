using NaturalLanguageProcess.Stories;
using Newtonsoft.Json;

namespace NaturalLanguageProcess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StoryGenerator storyGenerator = new StoryGenerator();
            Dialogue dialogue = new Dialogue(storyGenerator, SentencePurposeType.WarnOfImpendingDanger);
            ExpositionCollection expositionCollection = new ExpositionCollection();
            expositionCollection.CreateDialogue(dialogue);
            //BirthOfLucifer birthOfLucifer = new BirthOfLucifer();
            //birthOfLucifer.Write();
            //ChildrenOfTheDmz childrenOfTheDmz = new ChildrenOfTheDmz();
            //childrenOfTheDmz.Write();
            //OrbOfTime orbOfTime = new OrbOfTime();
            //orbOfTime.Write();
            //SeedsOfEden seedsOfEden = new SeedsOfEden();
            //seedsOfEden.Write();
            //StoryGenerator storyGenerator = new StoryGenerator();
            //storyGenerator.Generate();
            //GlyphGenerator glyphGenerator = new GlyphGenerator();
            //glyphGenerator.Generate();
            //var res = BinaryConverter.Convert(200);
            //var text = File.ReadAllText("E:\\alphabet\\wordsphere.json");
            //var words = JsonConvert.DeserializeObject<List<SerializableWord>>(text, new ListStringToSerializableWordConverter());
            //var customMap = new CustomDictionary();
            //customMap.Deserialize(words);
            //customMap.CreateGroups();
            //WordSpherePopulater wordSpherePopulater = new WordSpherePopulater();
            //wordSpherePopulater.Populate();
            //ProcessDictionary.GetPercentages();
            //ProcessDictionary.ConvertTextToJson("E:\\alphabet\\WebstersEnglishDictionary.txt", "E:\\alphabet\\syllables2.json");
        }
    }
}