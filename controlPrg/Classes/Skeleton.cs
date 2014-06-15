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


        public void sort()
        {
            List<cell> cell_buffer = new List<cell>();
            int left_node;
            int left_cell;
            int cell_pos;
            int cell_list_size = list_of_cell.Count;

            while (cell_buffer.Count < cell_list_size)
            {
                left_cell = System.Int32.MaxValue;
                left_node = System.Int32.MaxValue;
                cell_pos = 0;
                for (int i = 0; i < list_of_cell.Count; i++)
                {                    
                    for (int j = 0; j < list_of_cell[i].list_of_node.Count; j++)
                    {
                        if (left_node > list_of_cell[i].list_of_node[j].x)
                        {
                            left_node = list_of_cell[i].list_of_node[j].x;
                        }
                    }
                    if (left_cell > left_node)
                    {
                        left_cell = left_node;
                        cell_pos = i;
                    }
                }
                cell_buffer.Add(list_of_cell[cell_pos]);
                list_of_cell.RemoveAt(cell_pos);
            }
            list_of_cell = cell_buffer;
        }

        public void checkSmallChains()
        {
            for (int i = 0; i < list_of_cell.Count; i++)
            {
                if (list_of_cell[i].list_of_node.Count < 7)
                {                 
                    for (int j = 0; j < list_of_cell[i].list_of_node.Count; j++)
                    {
                        if (i > 0)
                        {
                            list_of_cell[i - 1].add_node(list_of_cell[i].list_of_node[j].x, 
                                list_of_cell[i].list_of_node[j].y);

                        }
                        else
                        {
                            list_of_cell[i + 1].list_of_node.Insert(0, list_of_cell[i].list_of_node[j]);
                        }
                    }
                    list_of_cell.RemoveAt(i);
                }
            }
        }

    }
}
