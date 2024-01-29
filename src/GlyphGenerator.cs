using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageProcess
{
    public class GlyphGenerator
    {
        public void Generate()
        {
            var lineSegments = LineSegmentGenerator.GenerateAllPossibleLineSegments(5, 3);
            CategoryCombiner combiner = new CategoryCombiner();
            List<Glyph> glyphs = new List<Glyph>();

            foreach (StoryThemeType theme in Enum.GetValues(typeof(StoryThemeType)))
            {
                foreach (SentimentType sentiment in Enum.GetValues(typeof(SentimentType)))
                {
                    foreach (VividVisualImageryType visual in Enum.GetValues(typeof(VividVisualImageryType)))
                    {
                        int activeCount = 0;
                        if (theme != default(StoryThemeType)) activeCount++;
                        if (sentiment != default(SentimentType)) activeCount++;
                        if (visual != default(VividVisualImageryType)) activeCount++;

                        if (activeCount == 3) // Max categories reached, don't continue to next categories
                        {
                            string combined = combiner.Combine(theme, sentiment, visual, default(VividEmotionalEvocationType), default(VividAuditoryImageryType));
                            Glyph glyph = new Glyph(theme, sentiment, visual, default(VividEmotionalEvocationType), default(VividAuditoryImageryType));
                            for (int i = 0; i < 105; ++i)
                            {
                                if (combined[i] == '1')
                                {
                                    glyph.AddLineSegment(lineSegments[i]);
                                }
                            }
                            glyphs.Add(glyph);
                            continue; // Skip the remaining loops
                        }

                        foreach (VividEmotionalEvocationType emotional in Enum.GetValues(typeof(VividEmotionalEvocationType)))
                        {
                            if (emotional != default(VividEmotionalEvocationType)) activeCount++;
                            if (activeCount > 3) break; // Break if more than 3 categories are active

                            foreach (VividAuditoryImageryType auditory in Enum.GetValues(typeof(VividAuditoryImageryType)))
                            {
                                if (auditory != default(VividAuditoryImageryType)) activeCount++;
                                if (activeCount > 3) break; // Break if more than 3 categories are active

                                if (activeCount > 0)
                                {
                                    string combined = combiner.Combine(theme, sentiment, visual, emotional, auditory);
                                    Glyph glyph = new Glyph(theme, sentiment, visual, emotional, auditory);
                                    for (int i = 0; i < 105; ++i)
                                    {
                                        if (combined[i] == '1')
                                        {
                                            glyph.AddLineSegment(lineSegments[i]);
                                        }
                                    }
                                    glyphs.Add(glyph);
                                }
                                if (auditory != default(VividAuditoryImageryType)) activeCount--; // Decrement if we added for auditory
                            }
                            if (emotional != default(VividEmotionalEvocationType)) activeCount--; // Decrement if we added for emotional
                        }
                    }
                }
            }

            using (StreamWriter file = File.CreateText(@"E:\alphabet\glyphs.json"))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                JsonSerializer serializer = new JsonSerializer();
                // Customize the serializer if needed (e.g., settings)
                serializer.Serialize(writer, glyphs);
            }

            string json = JsonConvert.SerializeObject(glyphs, Formatting.Indented);
            File.WriteAllText("E:\\alphabet\\glyphs.json", json);
        }
    }
}
