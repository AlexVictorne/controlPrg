using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;

namespace controlPrg
{
    [DataContract]
    public class Structure
    {
        [DataMember(Name = "Elements")]
        public List<Classes.Element> list_of_elements = new List<Classes.Element>();
        [DataMember(Name = "Relations")]
        public List<Classes.Relation> list_of_relations = new List<Classes.Relation>();
        public Structure() { }
    }
}