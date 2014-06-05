using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controlPrg.Classes
{
    class Relation
    {
        private Element e1, e2;
        private int char_counter;
        private bool end_flag;
        public Relation(Element e1, Element e2)
        {
            this.e1 = e1;
            this.e2 = e2;
        }

        public Relation(Relation r, Element e)
        {

        }

        public Relation(Element e, Relation r)
        {

        }

        public Relation(Relation r1, Relation r2)
        {

        }

        public bool checkElement(Element e, int pos) // не дописанная херня
        {
            if (pos == 0)
            {

            }
            return false;
        }
    }
}
