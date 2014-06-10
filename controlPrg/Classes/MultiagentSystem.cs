using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controlPrg.Classes
{
    class MultiagentSystem
    {
        private List<Element> templates;
        private const int SENSORS_COUNT = 5;
        private int relations_counter = 1;
        private List<Agent> agents;
        private List<Relation> relations;

        public MultiagentSystem()
        {
            templates = new List<Element>();
            relations = new List<Relation>();
            agents = new List<Agent>();
        }

        public void AddTemplate(Element e)
        {
            templates.Add(e); // клонировать?
            agents.Add(new Agent(e, e.Struct_Size));
        }
        public void AddRelation(Relation r)
        {
            relations.Add(r); // клонировать?
        }
        public Element GetElement(int number)
        {
            return templates[number];
        }
        public Relation GetRelation(int number)
        {
            return relations[number];
        }
        public List<Element> GetElements()
        {
            return templates;
        }
        public List<Relation> GetRelations()
        {
            return relations;
        }
        public int GetCountElements()
        {
            return templates.Count;
        }
        public int GetCountRelations()
        {
            return relations.Count;
        }

        public string getOut(Element[] input)
        {
            List<Element> agentsLayerOut = new List<Element>();
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < agents.Count; j++)
                {
                    if (agents[j].getOut(input[i]))
                    {
                        agentsLayerOut.Add(agents[j].getSpecializationElement());
                    }
                }
            }

            if (agentsLayerOut.Count != input.Length) return "-1";

            Relation relation_buffer = null;
            int elements_counter = 0;
            char result = '-';
            int k = 0;

            // вообще не уверен в этом алгоритме
            while (result == '-' && k < relations.Count)
            {
                if (relation_buffer == null)
                {
                    if (relations[k].checkElement(agentsLayerOut[elements_counter], agentsLayerOut[elements_counter + 1]))
                    {
                        relation_buffer = relations[k]; // клонировать?
                        elements_counter += 2;
                        if ((result = relations[k].checkChar()) == '-')
                            k = 0;
                    }
                }
                else
                {
                    if (relations[k].checkRelation(relation_buffer, agentsLayerOut[elements_counter]))
                    {
                        relation_buffer = relations[k]; // клонировать?
                        elements_counter++;
                        if ((result = relations[k].checkChar()) == '-')
                            k = 0;
                    }
                }
                k++;
            }
            return result.ToString();
        }
    }
}
