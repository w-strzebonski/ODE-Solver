using App.Interfaces;
using App.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models
{
    class MainResolver : INumericalResolver
    {
        public ISolver DifferentialSolver { get; private set; }

        private ISolvingSystem _solvingSystem;

        public (double, double)[] Data { get; private set; }

        public MainResolver(ISolver solver, ISolvingSystem solvingSystem)
        {
            DifferentialSolver = solver;
            _solvingSystem = solvingSystem;
        }

        public void Execute(double[] initialConditions)
        {
            Data = new (double, double)[_solvingSystem.NumberOfIterations];

            double[] tempData = new double[DifferentialSolver.SystemDifferentialEquations.Equations.Length + 1];

            for (int i = 0; i < initialConditions.Length; i++)
            {
                tempData[i] = initialConditions[i];
            }

            double x = _solvingSystem.StartingPoint;

            for (int i = 0; i < _solvingSystem.NumberOfIterations; i++)
            {
                Data[i].Item1 = tempData[0];
                Data[i].Item2 = tempData[1];

                tempData = DifferentialSolver.Solve(tempData);

                tempData[0] = Math.Round(Data[i].Item1 + _solvingSystem.Step, 5);
            }
        }
    }
}
