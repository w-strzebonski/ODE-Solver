using App.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models
{
    class MainResolver : IResolver
    {
        public ISolver DifferentialSolver { get; private set; }

        public double Step { get; private set; }

        public double StartBoundary { get; private set; }

        public double StopBoundary { get; private set; }

        public (double, double)[] Data { get; private set; }

        public MainResolver(ISolver solver, double startBoundary, double stopBoundary, double step)
        {
            DifferentialSolver = solver;
            StartBoundary = startBoundary;
            StopBoundary = stopBoundary;
            Step = step;
        }

        public void Execute(double[] initialConditions)
        {
            int numberOfSamples = Convert.ToInt32(Math.Abs(StopBoundary - StartBoundary) / Step);
            Data = new (double, double)[numberOfSamples];

            double[] tempData = new double[DifferentialSolver.SystemDifferentialEquations.Equations.Length + 1];

            for (int i = 0; i < initialConditions.Length; i++)
            {
                tempData[i] = initialConditions[i];
            }

            double x = StartBoundary;

            for (int i = 0; i < numberOfSamples; i++)
            {
                Data[i].Item1 = tempData[0];
                Data[i].Item2 = tempData[1];

                tempData = DifferentialSolver.Solve(tempData);

                tempData[0] = Math.Round(Data[i].Item1 + Step, 5);
            }
        }
    }
}
