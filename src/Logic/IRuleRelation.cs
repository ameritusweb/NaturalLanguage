using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageProcess.Logic
{
    public interface IRuleRelation
    {
        public ILogicalRule Antecedent { get; }

        public ILogicalRule Consequent { get; }
    }
}
