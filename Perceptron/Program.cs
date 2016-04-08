using System;
using System.Collections.Generic;

namespace Perceptron
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] array1 = new int[3];
            array1[0] = 1;
            array1[1] = 0;
            array1[2] = 0;
            Sample s1 = new Sample(array1, 1);

            int[] array2 = new int[3];
            array2[0] = 1;
            array2[1] = 0;
            array2[2] = 1;
            Sample s2 = new Sample(array2, 1);

            int[] array3 = new int[3];
            array3[0] = 1;
            array3[1] = 1;
            array3[2] = 0;
            Sample s3 = new Sample(array3, 1);

            int[] array4 = new int[3];
            array4[0] = 1;
            array4[1] = 1;
            array4[2] = 1;
            Sample s4 = new Sample(array4, 0);

            double[] Weight_I = new double[3];
            Weight_I[0] = 0;
            Weight_I[1] = 0;
            Weight_I[2] = 0;

            Sample[] Samples = new Sample[4];
            Samples[0] = s1;
            Samples[1] = s2;
            Samples[2] = s3;
            Samples[3] = s4;

            List<SampleTraining> a = Perceptron_Simple(3, 0.1, true , 0.5, Weight_I ,Samples);

            Console.WriteLine("Network training finished");
             
        }



        public static List<SampleTraining> Perceptron_Simple(int Number_N, double Learning_rate, bool Bias, double Threshold, double[] Weight_I, Sample[] Samples)
        {
            int cont = 0;
            List<SampleTraining> List_Sample = new List<SampleTraining>();
            while (!Condition_of_stop(List_Sample))
            {

                for (int i = 0; i < Samples.Count(); i++)
                {


                    double[] Ouput_Per_Sensor = new double[Samples[0].GetData().Count()];
                    double Ouput_Sum = 0;
                    double Ouput_Network;
                    double Error;
                    double Correction;
                    double[] Final_Weight = new double[Weight_I.Count()];

                    for (int j = 0; j < Ouput_Per_Sensor.Length; j++)
                    {
                        Ouput_Per_Sensor[j] = Samples[i].GetData()[j] * Weight_I[j];
                        Ouput_Sum += Samples[i].GetData()[j] * Weight_I[j];

                    }

                    Ouput_Network = Escalon(Threshold, Ouput_Sum);
                    Error = Samples[i].GetOuput() - Ouput_Network;
                    Correction = Learning_rate * Error;

                    for (int j = 0; j < Weight_I.Count(); j++)
                    {
                        Final_Weight[j] = Weight_I[j] + (Samples[i].GetData()[j] * Correction);

                    }


                    List_Sample.Add(new SampleTraining(Samples[i].GetData(), Samples[i].GetOuput(), Weight_I, Ouput_Per_Sensor, Math.Round(Ouput_Sum,2), Ouput_Network, Error, Correction, Final_Weight));
                    cont++;
                    Weight_I = Final_Weight;

                }

            }
            return List_Sample;

        }

        /*Preguntar Si se usa bias en la funcion de activacion ,  usar numero de neuronas*/
          
       
        public static bool Condition_of_stop(List<SampleTraining> List_Sample)
        {
            if ((List_Sample.Count() == 0))
                return false;
            if (List_Sample.ElementAt(List_Sample.Count() - 1).GetError() == 0 && List_Sample.ElementAt(List_Sample.Count() - 2).GetError() == 0 && List_Sample.ElementAt(List_Sample.Count() - 3).GetError() == 0 && List_Sample.ElementAt(List_Sample.Count() - 4).GetError() == 0)
                return true;
            return false;

        }

        public static double Escalon(double Threshold, double Sum)
        {
			return Sum > Threshold ? 1 : 0;
        }

        

    }
}
