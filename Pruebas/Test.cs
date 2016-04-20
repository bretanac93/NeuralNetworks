using System;
using NUnit.Framework;
using Perceptron;

namespace Pruebas
{
	[TestFixture ()]
	public class Test
	{
		double[] weightI;
		Sample[] samples;

		public Test ()
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

			weightI = new double[3];
			weightI[0] = 0;
			weightI[1] = 0;
			weightI[2] = 0;

			samples = new Sample[4];
			samples[0] = s1;
			samples[1] = s2;
			samples[2] = s3;
			samples[3] = s4;
		}

		[Test ()]
		public void TestPerceptron ()
		{			
			var a = Program.SimplePerceptron(0.1, 0.5, weightI ,samples);
			for (int i = 0; i != a.Count; i++) {
				Console.WriteLine (a[i]);
			}
			Console.WriteLine("Network training finished");
		}

		[Test ()]
		public void TestAdaline (){
			var a = Program.Adaline (0.1, 0.5, weightI, samples);
			for (int i = 0; i != a.Count; i++) {
				Console.WriteLine (a[i]);
			}
			Console.WriteLine("Network training finished");
		}
	}
}