namespace NaturalLanguageProcess
{
    public enum SentenceType
    {
        None = 0,
        Declarative, // States a fact or opinion.
        Interrogative, // Asks a question.
        Imperative, // Gives a command or request.
        Exclamatory, // Expresses strong emotion.
        Conditional, // Expresses a condition and its possible outcome.
        Comparative, // Compares two or more entities.
        Compound, // Combines two independent clauses.
        Complex, // Contains an independent clause and one or more dependent clauses.
        CompoundComplex, // Combines multiple independent clauses and at least one dependent clause.
        Fragment, // An incomplete sentence.
        RunOn, // Incorrectly constructed, overly long sentence.
        Question, // Another term for interrogative.
        Statement, // Another term for declarative.
        Command, // Another term for imperative.
        Exclamation, // Another term for exclamatory.
        Simple, // Contains a single independent clause.
        Quotation, // Contains a direct quote.
        Narrative, // Tells a story or describes a sequence of events.
        Descriptive, // Describes a person, place, thing, or idea.
        Persuasive, // Aims to persuade the reader or listener.
        Expository, // Provides information or explains a topic.
        RhetoricalQuestion, // A question asked for effect with no answer expected.
        Hypothetical, // Discusses a hypothetical situation.
        Concessive, // Acknowledges a contrasting point.
        Causal, // Indicates cause-and-effect relationships.
        List, // Contains a list of items or ideas.
        ParallelStructure, // Uses the same pattern of words to show equal importance.
        Introductory, // Begins a paragraph or passage.
        Concluding, // Concludes a paragraph or passage.
        Transitional, // Indicates a transition between points or ideas.
        Reflective, // Reflects on an experience or thought.
        Analytical, // Breaks down a concept or process for analysis.
        Summarizing, // Provides a summary of information.
        Clarifying, // Clarifies or explains a point.
        Emphatic, // Places emphasis on a particular point.
        Ironical, // Expresses irony.
        Sarcasm, // Expresses sarcasm.
        Juxtaposition, // Places contrasting ideas close together.
        Other // For unspecified or custom sentence types.
    }
}
