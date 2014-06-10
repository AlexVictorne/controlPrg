using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controlPrg
{
    class NeuronWithWeight
    {
        int _neuronNumber;
        double _neuronWeight;
        public NeuronWithWeight(int nn, double nw)
        {
            _neuronNumber = nn;
            _neuronWeight = nw;
        }
        public double NeuronWeight
        {
            get { return _neuronWeight; }
            set { _neuronWeight = value; }
        }
        public int NeuronNumber
        {
            get { return _neuronNumber; }
            set { _neuronNumber = value; }
        }
    }
}