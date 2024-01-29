namespace NaturalLanguageProcess
{
    public enum SentimentType
    {
        None = 0,
        Emotive = 1, // poetry
        Personal = 2, // poetry, blog, autobiography, memoir
        Tragic = 3, // drama
        Comedic = 4, // drama
        Romantic = 5, // poetry, love letter
        Informative = 6, // conference, seminar, speech, talk, lecture, documentary, news report, public report
        Neutral = 7, // essay, article, manual, user guide, panel discussion, letter of inquiry, lecture, documentary, catalog, newspaper, court document, news report, research paper, public report, contract, scholarly article, thesis, letter of resignation, biography, policy document
        Formal = 8, // policy document
        Persuasive = 9, // documentary, talk, petition, documentary
        Critical = 10, // documentary, letter to the editor, petition, documentary, editorial
        Opinionated = 11, // letter to the editor, newspaper, editorial
        Technical = 12, // white paper, manual
        Argumentative = 13, // essay, legal opinion, panel discussion, debate, thesis
        Instructional = 14, // user guide
        Analytical = 15, // Legal opinion, scholarly article, thesis
        Reflective = 16, // essay, autobiography
        Promotional = 17, // press release, letter of application
        Advocacy = 18, // petition
        Professional = 19, // conference
        Questioning = 20, // letter of inquiry
        Supportive = 21, // letter to the editor, letter of recommendation, editorial
        Positive = 22, // eulogy, workshop, letter of recommendation, letter of application, catalog, book review, movie review, press release, travel review, restaurant review, biography
        Descriptive = 23, // catalog
        Assertive = 24, // ultimatum
        Negative = 25, // ultimatum, book review, movie review, travel review, restaurant review, letter of resignation
        Moralistic = 26, // sermon
        Inspirational = 27, // sermon, autobiography
        Educational = 28, // seminar, workshop
        Motivational = 29, // self-help
        Admiring = 30, // biography
        Historical = 31, // biography, novel, documentary
        Legal = 32, // contract
        Political = 33, // speech, bill, act, statute, constitution
        Respectful = 34, // eulogy
        Commemorative = 35, // eulogy
        Factual = 36, // newspaper, court document, biography
        FutureOriented = 37, // business plan, forecast
        PastOriented = 38 // autobiography, memoir, documentary, biography
    }
}
