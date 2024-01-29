namespace NaturalLanguageProcess.Logic
{
    public interface ILogicalRule
    {
        bool Evaluate(StoryContext context);
        void Apply(StoryContext context);
    }
}
