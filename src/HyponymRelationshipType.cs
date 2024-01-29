using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageProcess
{
    public enum HyponymRelationshipType
    {
        None = -1,
        TypeOf = 0,          // Classic "is a type of" relationship
        PartWhole = 1,       // Meronym-Holonym relationships (Part-Whole)
        MemberCollection = 2,// "is a member of" relationship (Individual-Group)
        SubstanceMaterial = 3,// "is made of" relationship
        FunctionUse = 5,     // Defined by function or use
        PhaseStage = 6,      // Different stages or phases within a lifecycle
        AttributeBased = 7,  // Defined by specific attributes
        ActionEvent = 8      // Specific actions or events within broader categories
    }

}
