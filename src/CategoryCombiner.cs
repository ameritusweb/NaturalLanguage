using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageProcess
{
    public class CategoryCombiner
    {
        private Random rand;
        private int[] offset;
        public CategoryCombiner()
        {
            this.rand = new Random(Guid.NewGuid().GetHashCode());
            offset = new int[] { this.rand.Next() % 100, this.rand.Next() % 100, this.rand.Next() % 100, this.rand.Next() % 100, this.rand.Next() % 100 };
        }

        public string Combine(StoryThemeType storyTheme, SentimentType sentiment, VividVisualImageryType visual, VividEmotionalEvocationType emotional, VividAuditoryImageryType auditory)
        {
            int totalThemes = Enum.GetValues(typeof(StoryThemeType)).Length;
            int totalSentiments = Enum.GetValues(typeof(SentimentType)).Length;
            int totalVisuals = Enum.GetValues(typeof(VividVisualImageryType)).Length;
            int totalEmotionals = Enum.GetValues(typeof(VividEmotionalEvocationType)).Length;
            int totalAuditories = Enum.GetValues(typeof(VividAuditoryImageryType)).Length;

            int combined = CombineCategories((int)storyTheme, (int)sentiment, (int)visual, (int)emotional, (int)auditory, totalThemes, totalSentiments, totalVisuals, totalEmotionals, totalAuditories);
            var res = BinaryConverter.Convert(combined).PadLeft(105, '0');
            return res;
        }

        private int CalculateBitsNeeded(int typeCount)
        {
            return (int)Math.Ceiling(Math.Log2(typeCount));
        }

        private int CombineCategories(int cat1, int cat2, int cat3, int cat4, int cat5, int A, int B, int C, int D, int E)
        {
            cat1 += offset[0];
            A += offset[0];
            cat2 += offset[1];
            B += offset[1];
            cat3 += offset[2];
            C += offset[2];
            cat4 += offset[3];
            D += offset[3];
            cat5 += offset[4];
            E += offset[4];

            // Calculate bits needed for each category
            int bitsForCat1 = CalculateBitsNeeded(A);
            int bitsForCat2 = CalculateBitsNeeded(B);
            int bitsForCat3 = CalculateBitsNeeded(C);
            int bitsForCat4 = CalculateBitsNeeded(D);
            int bitsForCat5 = CalculateBitsNeeded(E);

            // Validate inputs
            if (cat1 < 0 || cat1 >= A) throw new ArgumentOutOfRangeException(nameof(cat1));
            if (cat2 < 0 || cat2 >= B) throw new ArgumentOutOfRangeException(nameof(cat2));
            if (cat3 < 0 || cat3 >= C) throw new ArgumentOutOfRangeException(nameof(cat3));
            if (cat4 < 0 || cat4 >= D) throw new ArgumentOutOfRangeException(nameof(cat4));
            if (cat5 < 0 || cat5 >= E) throw new ArgumentOutOfRangeException(nameof(cat5));

            // Combine categories
            int shiftForCat2 = bitsForCat1;
            int shiftForCat3 = shiftForCat2 + bitsForCat2;
            int shiftForCat4 = shiftForCat3 + bitsForCat3;
            int shiftForCat5 = shiftForCat4 + bitsForCat4;

            return (cat1 << (shiftForCat5))
                 + (cat2 << (shiftForCat4))
                 + (cat3 << (shiftForCat3))
                 + (cat4 << (shiftForCat2))
                 + cat5;
        }
    }
}
