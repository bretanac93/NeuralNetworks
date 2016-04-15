using System;

namespace Perceptron
{
    public class Sample
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
			get { return data; }
        }

        public int Ouput
        {
			get { return ouput; }
        }
    }
}
