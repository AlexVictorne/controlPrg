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
        private Relation r1, r2;
        private int counter = 0;
        private bool end_flag = false;
        private char my_char;
        public Relation(Element e1, Element e2, char c)
        {
            this.e1 = e1;
            this.e2 = e2;
            this.my_char = c;
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

        public bool checkElement(Element e1, Element e2)
        {
            if (this.e1.Equals(e1))
                if (this.e2.Equals(e2))
                    return true;
            return false;
        }

        public bool checkRelation(Relation r, Element e)
        {
            if (this.r1.Equals(r))
                if (this.e2.Equals(e))
                    return true;
            return false;
        }

        public char checkChar()
        {
            if (end_flag)
                return my_char;
            else
                return '-';
        }
    }
}
