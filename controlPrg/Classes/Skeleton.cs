using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;

namespace controlPrg
{
    [DataContract]
    public class Skeleton
    {
        [DataMember(Name = "Chains")]
        public List<cell> list_of_cell = new List<cell>();
        [DataMember(Name = "Size")]
        public Point Size;
        [DataMember(Name = "Length")]
        public int length;
        public Skeleton() { }
        [DataContract(Name = "Chain")]
        public class cell
        {
            [DataMember(Name = "Nodes")]
            public List<node> list_of_node = new List<node>();

            public cell() { }

            public void add_node(int x, int y)
            {
                list_of_node.Add(new node(x, y));
            }
        }
        [DataContract(Name = "Node")]
        public class node
        {
            [DataMember]
            public int x, y;
            public node(int x_, int y_)
            {
                x = x_;
                y = y_;
            }
        }


    }
}
