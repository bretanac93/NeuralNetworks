using System;
using System.Collections.Generic;

namespace Perceptron
{
    public class SampleTraining
    {
		int[] sensorValues;
		int desiredOutput;
		double[] initialWeights,ouputPerSensor,finalWeight;
		double ouputSum,ouputNetwork,error,correction;

        public SampleTraining(int[] sensorValues, int desiredOutput, double[] initialWeights, double[] ouputPerSensor, double ouputSum, double ouputNetwork, double error, double correction, double[] finalWeight)
        {
            this.sensorValues = sensorValues;
            this.desiredOutput = desiredOutput;
            this.initialWeights = initialWeights;
            this.ouputPerSensor = ouputPerSensor;
            this.ouputSum = ouputSum;
            this.ouputNetwork = ouputNetwork;
            this.error = error;
            this.correction = correction;
            this.finalWeight = finalWeight;
        }

        public double Error {
			get { return error;}
        }

		public int[] SensorValues {
			get {
				return sensorValues;
			}
		}

		public int DesiredOutput {
			get {
				return desiredOutput;
			}
		}

		public double[] InitialWeights {
			get {
				return initialWeights;
			}
		}

		public double[] OuputPerSensor {
			get {
				return ouputPerSensor;
			}
		}

		public double[] FinalWeight {
			get {
				return finalWeight;
			}
		}

		public double OuputSum {
			get {
				return ouputSum;
			}
		}

		public double OuputNetwork {
			get {
				return ouputNetwork;
			}
		}

		public double Correction {
			get {
				return correction;
			}
		}

		public override string ToString ()
		{
			return string.Format ("Error={0},DesiredOutput={1},OuputSum={2},OuputNetwork={3},Correction={4}", Error, DesiredOutput, OuputSum, OuputNetwork, Correction);
		}

		public override bool Equals (object obj)
		{
			return obj.GetType() == GetType () && obj.ToString() == ToString();
		}

		public override int GetHashCode ()
		{
			return ToString ().GetHashCode ();
		}
    }
}
