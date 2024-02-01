using NaturalLanguageProcess.Sentences;

namespace NaturalLanguageProcess
{
    public class ExpositionCollection
    {
        private Dictionary<ScenePurposeType, List<SentencePurpose>> expositions;

        public ExpositionCollection()
        {
            expositions = new Dictionary<ScenePurposeType, List<SentencePurpose>>();
            Initialize();
        }

        private void Initialize()
        {
            var scenePurpose1 = ScenePurposeType.RescuePrincessFromTower;
            SentencePurpose shareAnExperience = new SentencePurpose(SentencePurposeType.ShareAnExperience);
            shareAnExperience.Sentences.Add(new SubjectVerbObject());
            shareAnExperience.Sentences.Add(new SubjectVerbObject());
        }
    }
}
