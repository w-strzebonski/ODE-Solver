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
            var step = 0.00001;
            var equation = new TestEquation();
            var solver = new RungeKuttaFehlberg56(equation, step);

            var from = 0d;
            var to = 3d;
            var numberOfSamples = Convert.ToInt32(Math.Abs(from - to) / step);

            double[] data = new double[numberOfSamples];
            string[] dataAsString = new string[numberOfSamples];
            double[] tempData = new double[2];

            double x = from;
            data[0] = 2;

            for (int i = 0; i < data.Length - 1; i++)
            {
                tempData[0] = x;
                tempData[1] = data[i];

                Console.WriteLine($"x: {tempData[0]}, y: {tempData[1]}");
                dataAsString[i] = $"{tempData[0]}, {tempData[1]}";

                data[i + 1] = solver.Solve(tempData);
                x += step;
            }

            File.WriteAllLines(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/danesymulacji.txt", dataAsString);
        }
    }
}
