using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controlPrg.Classes
{
    public class Element
    {
        private int e_type, curvature;
        private Point Pe, Pb;
        private double length;
        private int struct_size;
        public Element(int e_type, Point Pb, Point Pe, double length, int curvature)
        {
            this.e_type = e_type;
            this.Pb = Pb;
            this.Pe = Pe;
            this.length = length;
            this.curvature = curvature;
            struct_size = 5;
        }

        public void SetType(int type)
        {
            this.e_type = type;
        }

        public int getType()
        {
            return e_type;
        }

        public int getCurvature()
        {
            return curvature;
        }

        public Point getBeginPoint()
        {
            return Pb;
        }

        public Point getEndPoint()
        {
            return Pe;
        }

        public double getLength()
        {
            return length;
        }

        public int getStructSize()
        {
            return struct_size;
        }
    }
}
