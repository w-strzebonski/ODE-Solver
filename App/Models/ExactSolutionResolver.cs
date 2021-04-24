using App.Interfaces;
using System;

namespace App.Models
{
    class ExactSolutionResolver : IExactSolutionResolver
    {
        public IEquation ExactSolutionEquation { get; private set; }

        public double Step { get; private set; }

        public double StartBoundary { get; private set; }

        public double StopBoundary { get; private set; }

        public (double, double)[] Data { get; private set; }

        public ExactSolutionResolver(IEquation exactSolutionEquaiton, double startBoundary, double stopBoundary, double step)
        {
            ExactSolutionEquation = exactSolutionEquaiton;
            StartBoundary = startBoundary;
            StopBoundary = stopBoundary;
            Step = step;
        }

        public void Execute(double[] initialConditions)
        {
            int numberOfSamples = Convert.ToInt32(Math.Abs(StopBoundary - StartBoundary) / Step);
            Data = new (double, double)[numberOfSamples];

            double[] tempData = new double[1];
            tempData[0] = StartBoundary;

            for (int i = 0; i < numberOfSamples; i++)
            {
                Data[i].Item1 = tempData[0];
                Data[i].Item2 = ExactSolutionEquation.CalculateResult(tempData);

                tempData[0] = Math.Round(Data[i].Item1 + Step, 5);
            }
        }
    }
}
