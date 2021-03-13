using App.Equations;
using App.Solvers;
using System;
using System.IO;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var step = 0.0001;
            var equations = new TestSystemEquation();
            var solver = new RungeKuttaFehlberg56(equations, step);

            var from = 0d;
            var to = 10d;
            var numberOfSamples = Convert.ToInt32(Math.Abs(from - to) / step);

            double[] dataY1 = new double[numberOfSamples];
            double[] dataY2 = new double[numberOfSamples];
            string[] dataAsString = new string[numberOfSamples];
            double[] tempData = new double[3];

            double x = from;
            dataY1[0] = 0;
            dataY2[0] = 1;

            for (int i = 0; i < dataY1.Length - 1; i++)
            {
                tempData[0] = x;
                tempData[1] = dataY1[i];
                tempData[2] = dataY2[i];

                Console.WriteLine($"x: {tempData[0]}, y1: {tempData[1]}, y2: {tempData[2]}");
                dataAsString[i] = $"{tempData[0]}, {tempData[1]}, {tempData[2]}";

                tempData = solver.Solve(tempData);
                
                x = Math.Round(x + step, 5);
                dataY1[i + 1] = tempData[1];
                dataY2[i + 1] = tempData[2];
            }

            File.WriteAllLines(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/danesymulacji.txt", dataAsString);
        }
    }
}
