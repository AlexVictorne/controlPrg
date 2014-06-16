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

        public int AgentExist(Element e)
        {
            int result = 0;
            foreach (Agent a in agents)
            {
                if (a.getOut(e))
                    return result;
                result++;
            }
            return -1;
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
        public int GetNumberOfElement(int number)
        {
            return templates[number].Number;
        }
        public void SetNumberOfElement(int number)
        {
            templates[number].Number = number;
        }
        public void SetElementParametrs(int number, Element e)
        {
            templates[number].BeginPoint = e.BeginPoint;
            templates[number].EndPoint = e.EndPoint;
            templates[number].Curvature = e.Curvature;
            templates[number].Type = e.Type;
            templates[number].Length = e.Length;
            templates[number].Struct_Size = e.Struct_Size;
        }

        public void RemoveElementAt(int i)
        {
            if (i > -1)
                templates.RemoveAt(i);
        }

        public void RemoveRelationAt(int i)
        {
            if (i > -1)
                relations.RemoveAt(i);
        }

        public void SetRelationParametrs(int number, Relation r)
        {
            relations[number].Specialization_Char = r.Specialization_Char;
            relations[number].setFinal(r.isFinal());
        }
        public void ClearAll()
        {
            templates.Clear();
            relations.Clear();
        }

        private Element[] input;
        private int input_counter = 0;
        public string getOut(Element[] input)
        {
            this.input = input;
            List<Element> agentsLayerOut = new List<Element>();
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < agents.Count; j++)
                {
                    if (agents[j].getOut(input[i]))
                    {
                        agentsLayerOut.Add(agents[j].getSpecializationElement());
                        break;
                    }
                }
            }

            if (agentsLayerOut.Count != input.Length) return CheckResult(input);

            Relation relation_buffer = null;
            int elements_counter = 0;
            char result = '-';
            int k = 0;

            // вообще не уверен в этом алгоритме
            while (result == '-' && k < relations.Count)
            {
                if (relation_buffer == null)
                {
                    try
                    {
                        if (relations[k].checkElement(agentsLayerOut[elements_counter], agentsLayerOut[elements_counter + 1]))
                        {
                            relation_buffer = relations[k]; // клонировать?
                            elements_counter += 2;
                            if ((result = relations[k].checkChar()) == '-')
                                k = 0;
                        }
                    }
                    catch (Exception e)
                    {
                        if (relations[k].checkElement(agentsLayerOut[elements_counter], null))
                        {
                            relation_buffer = relations[k]; // клонировать?
                            elements_counter += 2;
                            if ((result = relations[k].checkChar()) == '-')
                                k = 0;
                        }
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

        private string CheckResult(Element[] input)
        {
            string result = "-1";

            List<Element> agentsLayerOut = new List<Element>();
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < agents.Count; j++)
                {
                    if (agents[j].checkResult(input[i]))
                    {
                        agentsLayerOut.Add(agents[j].getSpecializationElement());
                    }
                }
            }

            List<Relation> possibleRelations = new List<Relation>();

            for (int i = 0; i < agentsLayerOut.Count; i++)
            {
                for (int j = 0; j < agentsLayerOut.Count; j++)
                {
                    if (i != j)
                    {
                        for (int k = 0; k < relations.Count; k++)
                        {
                            if (!relations[k].itRel())
                            {
                                if (relations[k].checkElement(agentsLayerOut[i], agentsLayerOut[j]))
                                {
                                    possibleRelations.Add(relations[k]);
                                }
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < possibleRelations.Count; i++)
            {
                result = FindRelations(possibleRelations[i], agentsLayerOut).ToString();
                if (!result.Equals("-1") && !result.Equals("-1"))
                    return result;
            }

            return result;
        }
        
        private char FindRelations(Relation rel, List<Element> el)
        {
            char result = '-';

            List<Relation> possibleRelations = new List<Relation>();

            for (int j = 0; j < el.Count; j++)
            {
                for (int k = 0; k < relations.Count; k++)
                {
                    if (relations[k].itRel())
                    {
                        if (relations[k].checkRelation(rel, el[j]))
                        {
                            if ((result = relations[k].checkChar()) == '-')
                                result = FindRelations(relations[k], el);
                        }
                    }
                }
                
            }
            return result;
        }
    }
}
