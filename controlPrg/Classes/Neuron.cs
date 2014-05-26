//Copyright (C) 2014 AlexVictorne, Nikita_blackbeard

using System;
using System.Threading;

namespace controlPrg
{
    public class Neuron
    {

        private double[] w;

        public Neuron(int InputsCount)
        {
            w = new double[InputsCount];
            initWeights();
            Thread.Sleep(50);
        }

        private void initWeights()
        {
            Random rnd = new Random();

            for (int i = 0; i < w.Length; i++)
            {
                w[i] = rnd.NextDouble() / 50;
            }
        }

        public double neuron_out(int[] x)
        {
            double nec = 0;

            for (int i = 0; i < w.Length; i++)
            {
                nec += x[i] * w[i];
            }
            return nec;
            /*
            if (nec > s){
                return 1;
            }else{
                return 0;
            }
            //*/
        }

        public double[] getW()
        {
            return w;
        }

        public void changeWeights(double v, int d, int[] x)
        {
            for (int i = 0; i < w.Length; i++)
            {
                w[i] += v * d * x[i];
            }
        }
    }
}
