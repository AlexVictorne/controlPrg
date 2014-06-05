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
        private Element[] templates;
        private const int SENSORS_COUNT = 5;
        private int relations_counter = 1;

        public MultiagentSystem(int templates_count)
        {
            templates = new Element[templates_count];
        }

        public void test()
        {
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
    }
}
