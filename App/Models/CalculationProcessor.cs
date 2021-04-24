using App.Interfaces;
using App.System;
using System;

namespace App.Models
{
    class CalculationProcessor
    {
        public CalculationRecord[] CalculationRecords { get; private set; }

        private ISolver _numericalSolver;
        private IEquation _exactSolutionEquation;
        private ISolvingSystemData _solvingSystem;

        public CalculationProcessor(ISolver numericalSolver, IEquation exactSolutionEquation, ISolvingSystemData solvingSystem)
        {
            _numericalSolver = numericalSolver;
            _exactSolutionEquation = exactSolutionEquation;
            _solvingSystem = solvingSystem;

            CalculationRecords = new CalculationRecord[_solvingSystem.NumberOfIterations];
        }

        public bool StartCalculations(double[] initialConditions)
        {
            double[] tempData = new double[initialConditions.Length];

            for (int i = 0; i < tempData.Length; i++)
            {
                tempData[i] = initialConditions[i];
            }

            for (int i = 0; i < _solvingSystem.NumberOfIterations; i++)
            {
                double xValue = tempData[0];
                double calculatedSolverValue = tempData[1];
                double exactSolutionValue = _exactSolutionEquation.CalculateResult(new double[] { xValue });
                double error = calculatedSolverValue - exactSolutionValue;

                CalculationRecords[i] = new CalculationRecord(xValue, calculatedSolverValue, exactSolutionValue, error);
                
                tempData = _numericalSolver.Solve(tempData);
                tempData[0] = Math.Round(xValue + _solvingSystem.Step, 5);
            }

            return false;
        }
    }
}
