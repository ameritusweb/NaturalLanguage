using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageProcess.Logic
{
    public class LogicGraphNode
    {
        public ILogicalRule Rule { get; set; }

        public List<RuleRelation> Edges { get; set; }

        public LogicGraphNode()
        {
            this.Edges = new List<RuleRelation>();
        }
    }
}
