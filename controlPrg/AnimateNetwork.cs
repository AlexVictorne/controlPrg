using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace controlPrg
{
    class AnimateNetwork
    {
        List<ElementNeuron> list_neurons = new List<ElementNeuron>();
        List<ElementConnect> list_connect = new List<ElementConnect>();
        Graphics graphProc;
        int layer_count = 0;
        int width, heigth;
        public AnimateNetwork(Graphics e)
        {
            graphProc = e;
            width = (int)graphProc.VisibleClipBounds.Width;
            heigth = (int)graphProc.VisibleClipBounds.Height;
        }
        
        int previos_neuroncount = 0;
        public void create_layer(int layer_type,int neuroncount)
        {
            switch (layer_type)
            {
                case 0:
                    list_neurons.Add(new ElementNeuron(width / 6, heigth / 2));
                    break;
                case 1:
                    layer_count++;
                    int first_new = list_neurons.Count;
                    int x = list_neurons[list_neurons.Count - 1].GetCoordPoint().X + width / 6;
                    int y = heigth / 2;
                    int dy = (heigth / (neuroncount+1));
                    for (int i = 1; i < neuroncount+1;i++)
                    {
                        list_neurons.Add(new ElementNeuron(x, dy*i));
                    }

                    if (list_neurons.Count > neuroncount+1)
                        for (int i = first_new; i < first_new + neuroncount; i++)
                            for (int j = first_new - previos_neuroncount; j < first_new; j++)
                                Create_Connect(layer_count - 1, layer_count, j, i);
                    else
                        for (int i = first_new; i < first_new + neuroncount; i++)
                            Create_Connect(layer_count - 1, layer_count, 0, i);
                    previos_neuroncount = neuroncount;
                    break;
                case 2:
                    layer_count++;
                    list_neurons.Add(new ElementNeuron(list_neurons[list_neurons.Count - 1].GetCoordPoint().X + width / 6, heigth / 2));
                    for (int i = list_neurons.Count - previos_neuroncount-1; i < list_neurons.Count - 1; i++)
                    {
                        Create_Connect(layer_count - 1, layer_count, i, list_neurons.Count - 1);
                    }
                    break;
            }
        }

        void Create_Connect(int layer1, int layer2, int e1, int e2)
        {
            list_connect.Add(new ElementConnect(layer1, layer2, list_neurons[e1].GetCoordPoint(), list_neurons[e2].GetCoordPoint()));
        }
        public void Paint_Structure(Graphics e)
        {
            foreach (ElementNeuron en in list_neurons)
            {
                en.PaintNeuron(e);
            }
            foreach (ElementConnect ec in list_connect)
            {
                ec.PaintConnect(e);
                ec.PaintPulse(e);
            }
        }
        public void Pulsar_Layer(int first_layer, int second_layer)
        {
            foreach (ElementConnect ec in list_connect)
            {
                if ((ec.layer_1 == first_layer) && (ec.layer_2 == second_layer))
                    ec.Pulsar();
            }
        }
        public void StopAllPulsar()
        {
            foreach (ElementConnect ec in list_connect)
            {
                if (ec.pulsar_flag)
                    ec.Pulsar();
            }
        }
    }
}
    class ElementNeuron
    {
        int x, y;
        int mode;
        public ElementNeuron(int cX, int cY)
        {
            x = cX;
            y = cY;
        }
        public void PaintNeuron(Graphics e)
        {
            e.FillEllipse(Brushes.Black, x - 6, y - 6, 12, 12);
        }
        public Point GetCoordPoint()
        {
            return new Point(x, y);
        }
    }
    class ElementConnect
    {
        public int layer_1, layer_2;
        int x1, y1, x2, y2;
        public bool pulsar_flag = false;
        int pulsar_x = 0, pulsar_y = 0;
        public ElementConnect(int e1, int e2, int cX1, int cY1, int cX2, int cY2)
        {
            layer_1 = e1;
            layer_2 = e2;
            x1 = cX1;
            y1 = cY1;
            x2 = cX2;
            y2 = cY2;
        }
        public ElementConnect(int e1, int e2, Point xy, Point xy1)
        {
            layer_1 = e1;
            layer_2 = e2;
            x1 = xy.X;
            y1 = xy.Y;
            x2 = xy1.X;
            y2 = xy1.Y;
        }
        public void PaintConnect(Graphics e)
        {
            e.DrawLine(Pens.Black, x1, y1, x2, y2);
        }
        public void PaintPulse(Graphics e)
        {
            if ((pulsar_x != 0) && (pulsar_y != 0) && (pulsar_x != x2) && (pulsar_y != y2))
                e.FillEllipse(Brushes.Red, pulsar_x - 3, pulsar_y - 3, 6, 6);
        }
        public void Pulsar()
        {
            if (pulsar_flag)
                pulsar_flag = false;
            else
            {
                pulsar_flag = true;
                Thread ht = new Thread(move);
                ht.Start();
            }
        }
        void move()
        {
            while (pulsar_flag)
            {
                Point xy = new Point(x1, y1);
                Point xy1 = new Point(x2, y2);
                int x, y, dx, dy, incx, incy, pdx, pdy, es, el, err;
                dx = xy1.X - xy.X;
                dy = xy1.Y - xy.Y;
                if (dy==0)
                {
                    dy = 3;
                }
                incx = Math.Sign(dx);
                incy = Math.Sign(dy);
                if (dx < 0)
                    dx = -dx;
                if (dy < 0)
                    dy = -dy;
                if (dx > dy)
                {
                    pdx = incx;
                    es = dy;
                    pdy = 0;
                    el = dx;
                }
                else
                {
                    pdx = 0;
                    es = dx;
                    pdy = incy;
                    el = dy;
                }
                x = xy.X;
                y = xy.Y;
                err = el / 2;
                Pen myPen = new Pen(Color.Tomato);
                
                for (int t = 0; t < el; t++)
                {
                    if (pulsar_flag)
                    {
                        err -= es;
                        if (err < 0)
                        {
                            err += el;
                            x += incx;
                            y += incy;
                        }
                        else
                        {
                            x += pdx;
                            y += pdy;
                        }
                        pulsar_x = x;
                        pulsar_y = y;
                        Thread.Sleep(20);
                    }
                    else
                    {
                        pulsar_x = 0;
                        pulsar_y = 0;
                    }
                }
                xy = new Point(x, y);
            }
        }
    }

