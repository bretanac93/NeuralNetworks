using System;
using System.Collections.Generic;

namespace Perceptron
{
    class SampleTraining
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

        public double Error
        {
			get { return error; }
        }
    }
}
