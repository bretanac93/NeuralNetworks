using System;

namespace Perceptron
{
    class Sample
    {
        private int[] data;
        private int ouput;

        public Sample(int[] data, int output)
        {
            this.data = data;
            this.ouput = output;
        }

        public int[] Data
        {
			get { return Data; }
        }

        public int Ouput
        {
			get { return Ouput; }
        }

    }
}
