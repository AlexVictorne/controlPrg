﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controlPrg.Classes
{
    class Element
    {
        private int e_number, curvature;
        private Point Pe, Pb;
        private double length;
        public Element(int e_number, Point Pb, Point Pe, double length, int curvature)
        {
            this.e_number = e_number;
            this.Pb = Pb;
            this.Pe = Pe;
            this.length = length;
            this.curvature = curvature;
        }

        public int getNumber()
        {
            return e_number;
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
    }
}