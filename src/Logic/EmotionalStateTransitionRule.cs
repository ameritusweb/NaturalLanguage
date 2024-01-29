namespace NaturalLanguageProcess.Logic
{
    class EmotionalStateTransitionRule : ILogicalRule
    {
        public StoryWord Subject { get; set; }
        public StoryWord Verb { get; set; }
        public StoryWord Object { get; set; }
        public StoryWord NewState { get; set; }  // The new emotional state

        public EmotionalStateTransitionRule(StoryWord subject, StoryWord verb, StoryWord @object, StoryWord newState)
        {
            Subject = subject;
            Verb = verb;
            Object = @object;
            NewState = newState;
        }

        public bool Evaluate(StoryContext context)
        {
            // Check if the specified action (e.g., stubbing a toe) has occurred
            return context.HasObjectRelatedActionOccurred(Subject, Verb, Object);
        }

        public void Apply(StoryContext context)
        {
            // Update the emotional state of the subject in the story context
            context.RecordCharacteristic(Subject, NewState);
        }
    }

}
