namespace NaturalLanguageProcess
{
    public class SentencePurpose
    {
        public SentencePurposeType Purpose { get; set; }

        public List<SentenceBase> Sentences { get; set; }

        public SentencePurpose(SentencePurposeType purpose)
        {
            Purpose = purpose;
            Sentences = new List<SentenceBase>();
        }

        public void AddSentence(SentenceBase sentence)
        {
            Sentences.Add(sentence);
        }
    }
}
