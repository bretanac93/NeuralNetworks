using System;
using System.Collections.Generic;

namespace Perceptron
{
    public class Program
    {
        public static List<SampleTraining> SimplePerceptron(int numberN, double learningRate, bool bias, double threshold, double[] weightI, Sample[] samples)
        {
            int cont = 0;
			List<SampleTraining> lsSample = new List<SampleTraining>();
            while (!StopCondition(lsSample))
            {
				for (int i = 0; i < samples.Length; i++)
                {
					double[] outputPerSensor = new double[samples[0].Data.Length];
					double outputSum = 0;
					double outputNetwork;
					double error;
					double correction;
					double[] finalWeight = new double[weightI.Length];

                    for (int j = 0; j < outputPerSensor.Length; j++)
                    {
                        outputPerSensor[j] = samples[i].Data[j] * weightI[j];
                        outputSum += samples[i].Data[j] * weightI[j];

                    }

                    outputNetwork = Escalon(threshold, outputSum);
                    error = samples[i].Ouput - outputNetwork;
                    correction = learningRate * error;

					for (int j = 0; j < weightI.Length; j++)
                    {
                        finalWeight[j] = weightI[j] + (samples[i].Data[j] * correction);

                    }

                    lsSample.Add(new SampleTraining(samples[i].Data, samples[i].Ouput, weightI, outputPerSensor, Math.Round(outputSum,2), outputNetwork, error, correction, finalWeight));
                    cont++;
                    weightI = finalWeight;
                }
            }
            return lsSample;
        }

        /*Preguntar Si se usa bias en la funcion de activacion ,  usar numero de neuronas*/
          
       
        public static bool StopCondition(List<SampleTraining> lsSample)
        {
			bool r = lsSample.Count != 0;            
			for (int i = 1; r && i != lsSample.Count && i != 5; i++) {
				r = lsSample [lsSample.Count - i].Error == 0;
			}
            return r;
        }

        public static double Escalon(double Threshold, double Sum)
        {
			return Sum > Threshold ? 1 : 0;
        }
    }
}