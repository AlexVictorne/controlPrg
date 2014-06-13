using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace controlPrg.Classes
{
    [DataContract]
    public class Relation
    {
        [DataMember]
        private Point coordinate;
        [DataMember]
        private bool was_chosen = false;
        [DataMember]
        private Element e1, e2;
        [DataMember]
        private Relation r1, r2;
        [DataMember]
        private bool end_flag = false, final_relation = false;
        [DataMember]
        private char my_char;
        public Relation(Element e1, Element e2,int x,int y)
        { 
            this.e1 = e1;
            this.e2 = e2;
            this.coordinate.X = x;
            this.coordinate.Y = y;
        }
        public Relation(Relation r,Element e1,int x,int y)
        {
            this.e1 = e1;
            this.r1 = r;
            this.coordinate.X = x;
            this.coordinate.Y = y;
        }
        public void Paint(Graphics g)
        {
            if (was_chosen)
                g.FillEllipse(Brushes.Red, coordinate.X - 4, coordinate.Y - 4, 8, 8);
            else
            {
                if (final_relation)
                    g.FillEllipse(Brushes.Blue, coordinate.X - 4, coordinate.Y - 4, 8, 8);
                else
                    g.FillEllipse(Brushes.Black, coordinate.X - 4, coordinate.Y - 4, 8, 8);
            }
            g.DrawLine(Pens.Black, e1.Coordinate,coordinate);
            if (e2!=null)
                g.DrawLine(Pens.Black, e2.Coordinate,coordinate);
            else
                g.DrawLine(Pens.Black, r1.coordinate, coordinate);

        }
        public bool itRel()
        {
            if (r1 == null)
                return false;
            else
                return true;
        }
        public Element GetElem(int i)
        {
            if (i == 1)
                return e1;
            else
                return e2;
        }
        public Relation GetRel()
        {
            return r1;
        }


        public bool checkElement(Element e1, Element e2)
        {
            if (this.e1 == null && this.e2 == null) return false;
            if (this.e1.Equals(e1) && e2 == null)
            {
                end_flag = true;
                return true;
            }
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
            if (this.r1 == null || this.e1 == null) return false;
            if (this.r1.Equals(r))
                if (this.e1.Equals(e))
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

        public Point Coordinate
        {
            get { return coordinate; }
            set { coordinate = value; }
        }

        public bool Was_chosen
        {
            get { return was_chosen; }
            set { was_chosen = value; }
        }

        public bool isFinal()
        {
            return final_relation;
        }

        public void setFinal(bool value)
        {
            this.final_relation = value;
        }

        public char Specialization_Char
        {
            get { return my_char; }
            set { my_char = value; }
        }
    }
}
