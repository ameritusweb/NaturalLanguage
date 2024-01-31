using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageProcess
{
    public enum CardinalityType
    {
        None,
        Singular, // Only one exists (e.g., a unique artifact)
        Limited,  // Limited number exists (e.g., a few magical swords)
        Plentiful, // Abundant, but not infinite (e.g., trees in a forest)
        Infinite,  // Unlimited availability (e.g., stars in the sky)
        Other // Cardinality is not defined or known
    }
}
