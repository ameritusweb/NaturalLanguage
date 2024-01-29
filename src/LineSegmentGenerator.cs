using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageProcess
{
    public class LineSegmentGenerator
    {
        public static List<LineSegment> GenerateAllPossibleLineSegments(int rows, int columns)
        {
            var lineSegments = new List<LineSegment>();

            for (int x1 = 0; x1 < rows; x1++)
            {
                for (int y1 = 0; y1 < columns; y1++)
                {
                    for (int x2 = x1; x2 < rows; x2++)
                    {
                        for (int y2 = (x1 == x2 ? y1 + 1 : 0); y2 < columns; y2++)
                        {
                            lineSegments.Add(new LineSegment(new Point(x1, y1), new Point(x2, y2)));
                        }
                    }
                }
            }

            return lineSegments;
        }
    }
}
