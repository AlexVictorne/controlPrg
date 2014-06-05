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
            agents.Add(new Agent(e, e.getStructSize()));
        }

        public void setRelation(Relation r)
        {
            relations.Add(r); // клонировать?
        }

        public void test()
        {
            /*
            templates[0] = new Element(0, new Point(0, 0), new Point(0, 10), Math.PI * 5 * 0.5, 5); // первая дуга буквы х
            templates[1] = new Element(1, new Point(10, 0), new Point(10, 10), Math.PI * 5 * 0.5, 5); // вторая дуга буквы х
            templates[2] = new Element(0, new Point(2, 2), new Point(2, 12), Math.PI * 6 * 0.5, 6); // первая дуга буквы х
            templates[3] = new Element(1, new Point(12, 2), new Point(12, 12), Math.PI * 6 * 0.5, 6); // первая дуга буквы х

            Agent[] agents = new Agent[templates.Length - 2];
            for (int i = 0; i < agents.Length; i++)
            {
                agents[i] = new Agent(templates[i], SENSORS_COUNT);
            }

            Relation r = new Relation(templates[0], templates[1], 'х'); // отношение для буквы х
            Relation test_r = new Relation(templates[2], templates[3], 'х'); // отношение для буквы х

            if (agents[0].getOut(templates[2]))
                if (r.checkElement(agents[0].getSpecializationElement(), relations_counter))
                    relations_counter++;
            if (agents[1].getOut(templates[3]))
                if (r.checkElement(agents[1].getSpecializationElement(), relations_counter++))
                    relations_counter++;
            Console.WriteLine(r.checkChar());
            /*
            for (int i = 0; i < agents.Length; i++)
            {
                if (agents[i] == null) continue;
                if (templates[i] == null) continue;
                if (agents[i].getOut(templates[i]))
                {
                    if (r.checkElement(agents[i].getSpecializationElement(), relations_counter))
                    {
                        relations_counter++;
                        if (relations_counter > 2)
                        {
                            Console.WriteLine(r.checkChar());
                            relations_counter = 0;
                        }
                    }
                    if (test_r.checkElement(agents[i].getSpecializationElement(), relations_counter))
                    {
                        relations_counter++;
                        if (relations_counter > 2)
                        {
                            Console.WriteLine(r.checkChar());
                            relations_counter = 0;
                        }
                    }
                }
            }
             */
        }

        public void getOut(Element[] input)
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

            if (agentsLayerOut.Count != input.Length) return;

            Relation[] relation_buffer = new Relation[input.Length];

            for (int i = 0; i < agentsLayerOut.Count; i++)
            {
                for (int j = 0; j < relations.Count; j++)
                {
                    if (relation_buffer.Length < 0)
                        if (relations[j].checkElement(agentsLayerOut[i], agentsLayerOut[i + 1]))
                        {
                            //????????????????????????????????????????
                        }
                }
            }
        }
    }
}
