using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageProcess
{
    public class Glyph
    {
        public StoryThemeType Theme { get; set; }

        public SentimentType Sentiment { get; set; }

        public VividVisualImageryType Visual { get; set; }

        public VividEmotionalEvocationType Emotional { get; set; }

        public VividAuditoryImageryType Auditory { get; set; }

        public List<LineSegment> LineSegments { get; set; }

        public Glyph(StoryThemeType theme, SentimentType sentiment, VividVisualImageryType visual, VividEmotionalEvocationType emotional, VividAuditoryImageryType auditory)
        {
            Theme = theme;
            Sentiment = sentiment;
            Visual = visual;
            Emotional = emotional;
            Auditory = auditory;
        }

        public void AddLineSegment(LineSegment lineSegment)
        {
            if (LineSegments == null)
            {
                LineSegments = new List<LineSegment>();
            }

            LineSegments.Add(lineSegment);
        }
    }
}
