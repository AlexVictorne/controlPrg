using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controlPrg.Classes
{
    class Agent
    {
        private int sensors_count;
        private Element my_element, input_element;
        private const double t = 0.5;
        public Agent(Element e, int sensors_count)
        {
            this.my_element = e;
            this.sensors_count = sensors_count;
        }

        private double calcVectorLength(Point p1, Point p2)
        {
            return Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
        }

        private double calcLengthDifference(double l1, double l2)
        {
            return l1 - l2;
        }

        private int calcCurvatureDifference(int c1, int c2)
        {
            return c1 - c2;
        }

        public void setInputElement(Element e)
        {
            this.input_element = e;
        }

        public bool getOut(Element e)
        {
            double result = activationFunction(compareElements(this.my_element, e));

            if (result < 0.8) 
                return true;
            else 
                return false;
        }

        private double compareElements(Element e1, Element e2)
        {
            double beginVectorLength = calcVectorLength(e1.BeginPoint, e2.BeginPoint);
            double endVectorLength = calcVectorLength(e1.EndPoint, e2.EndPoint);
            double lengthDifference = calcLengthDifference(e1.Length, e2.Length);
            double curvatureDifference = calcCurvatureDifference(e1.Curvature, e2.Curvature);

            return 0.5 * Math.Sqrt(beginVectorLength * beginVectorLength + endVectorLength * endVectorLength +
                lengthDifference * lengthDifference +
                curvatureDifference * curvatureDifference);
        }

        private double activationFunction(double x)
        {
            return 1 / ((double)(1 + Math.Pow(Math.E, (-t * x))));
        }

        public Element getSpecializationElement()
        {
            return my_element;
        }
    }
}
