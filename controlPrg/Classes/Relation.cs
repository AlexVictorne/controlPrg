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
        private bool end_flag = false, final_relation;
        private char my_char;
        public Relation(Element e1, Element e2, char c, bool final_relation)
        {
            this.e1 = e1;
            this.e2 = e2;
            this.my_char = c;
            this.final_relation = final_relation;
        }

        public Relation(Relation r, Element e, char c, bool final_relation)
        {
            r1 = r;
            e2 = e;
            this.my_char = c;
            this.final_relation = final_relation;
        }

        public Relation(Relation r1, Relation r2, char c, bool final_relation)
        {

        }

        public bool checkElement(Element e1, Element e2)
        {
            if (this.e1 == null || this.e2 == null) return false;
            if (this.e1.Equals(e1))
                if (this.e2.Equals(e2))
                {
                    end_flag = true;
                    return true;
                }
            return false;
        }

        public bool checkRelation(Relation r, Element e)
        {
            if (this.r1 == null || this.e2 == null) return false;
            if (this.r1.Equals(r))
                if (this.e2.Equals(e))
                {
                    end_flag = true;
                    return true;
                }
            return false;
        }

        public char checkChar()
        {
            if (end_flag && final_relation)
                return my_char;
            else
                return '-';
        }
    }
}
