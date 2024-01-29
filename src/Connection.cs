using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageProcess
{
    public class Connection
    {
        public Word Start { get; private set; }
        public Word End { get; private set; }
        public Vector3 StartPosition => Start.Position;
        public Vector3 EndPosition => End.Position;

        public Connection(Word start, Word end)
        {
            Start = start;
            End = end;
        }
    }

}
