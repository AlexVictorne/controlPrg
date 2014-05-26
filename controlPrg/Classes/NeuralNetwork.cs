//Copyright (C) 2014 AlexVictorne, Nikita_blackbeard

using System;

namespace controlPrg
{
    public class NeuralNetwork
    {
        private Neuron[] neurons;
        private int NeuronsCount;
        private const double t = 1;

        public NeuralNetwork(int NeuronsCount, int InputsCount)
        {
            this.NeuronsCount = NeuronsCount;
            neurons = new Neuron[this.NeuronsCount];

            for (int i = 0; i < neurons.Length; i++)
            {
                neurons[i] = new Neuron(InputsCount);
            }
        }

        private int[] recognize(int[] x)
        {
            double[] y = new double[neurons.Length];
            int[] result = new int[y.Length];

            for (int i = 0; i < y.Length; i++)
            {
                y[i] = Sigmoid(neurons[i].neuron_out(x)) * 1000;
            }
            int num = 0;
            double max = Double.MinValue;
            for (int i = 0; i < y.Length; i++)
            {
                if (y[i] > max)
                {
                    max = y[i];
                    num = i;
                }
            }

            if (max < 800)
            {
                return new int[result.Length];
            }
            for (int i = 0; i < result.Length; i++)
            {
                if ((i == num))
                {
                    result[i] = 1;
                }
                else
                {
                    result[i] = 0;
                }
            }
            return result;
        }

        public void teach(int[] inp, int[] output)
        {
            int d;
            double v = 1;
            int[] t = recognize(inp);

            while (!equal(output, t))
            {
                for (int i = 0; i < neurons.Length; i++)
                {
                    d = output[i] - t[i];
                    if (d != 0)
                        neurons[i].changeWeights(v, d, inp);
                }
                t = recognize(inp);
            }
        }

        public int[] Raspozn(int[] input)
        {
            return recognize(input);
        }

        private bool equal(int[] a, int[] b)
        {
            if (a.Length != b.Length) return false;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                    return false;
            }
            return true;
        }

        private double Sigmoid(double x)
        {
            return 1 / ((double)(1 + Math.Pow(Math.E, (-t * x))));
        }
    }
}
