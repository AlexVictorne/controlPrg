using Emgu.CV;
using System.Drawing;
using System.Runtime.Serialization;

namespace controlPrg.Classes
{
    [DataContract]
    public class Element
    {
        [DataMember]
        private int e_type, curvature;
        [DataMember]
        private Point coordinate;
        [DataMember]
        private bool was_chosen = false;
        [DataMember]
        private Point Pe, Pb;
        [DataMember]
        private double length;
        [DataMember]
        public static int struct_size;
        [DataMember]
        private int number=0;

        private Bitmap img;
        public void Paint(Graphics g)
        {
            if (was_chosen)
            {
                g.FillEllipse(Brushes.White, coordinate.X - 8, coordinate.Y - 8, 16, 16);
                g.DrawEllipse(Pens.Red, coordinate.X - 8, coordinate.Y - 8, 16, 16);
            }
            else
            {
                g.FillEllipse(Brushes.White, coordinate.X - 8, coordinate.Y - 8, 16, 16);
                g.DrawEllipse(Pens.Black, coordinate.X - 8, coordinate.Y - 8, 16, 16);
            }
            g.DrawString(number.ToString(), new Font("Arial", 8), Brushes.Black, new Point(coordinate.X - 6, coordinate.Y - 6));
        }

        public Element(int x,int y)
        {
            this.coordinate.X = x;
            this.coordinate.Y = y;
            struct_size = 5;
        }
        public Element(int e_type, Point Pb, Point Pe, double length, int curvature)
        {
            this.e_type = e_type;
            this.Pb = Pb;
            this.Pe = Pe;
            this.length = length;
            this.curvature = curvature;
            struct_size = 5;
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
        public int Type
        {
            get { return e_type; }
            set {e_type = value; }
        }
        public int Curvature
        {
            get { return curvature; }
            set { curvature= value; }
        }
        public Point BeginPoint
        {
            get { return Pb; }
            set { Pb = value; }
        }
        public Point EndPoint
        {
            get { return Pe; }
            set { Pe = value; }
        }
        public int Struct_Size
        {
            get { return struct_size; }
            set { struct_size = value; }
        }
        public double Length
        {
            get { return length; }
            set { length = value; }
        }
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        public Bitmap Bitmap
        {
            get { return img; }
            set { img = value; }
        }

        public Element Clone()
        {
            return new Element(this.e_type, this.Pb, this.Pe, this.length, this.curvature);
        }
    }
}
