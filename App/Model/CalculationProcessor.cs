using System;
using App.Equation;
using App.Solver;
using App.System;

namespace App.Model
{
    public class CalculationProcessor
    {
        public CalculationRecord[] CalculationRecords { get; }

        private readonly ISolver _numericalSolver;
        private readonly IEquation _exactSolutionEquation;
        private readonly ISolvingSystemData _solvingSystem;

        public CalculationProcessor(ISolver numericalSolver, IEquation exactSolutionEquation, ISolvingSystemData solvingSystem)
        {
            _numericalSolver = numericalSolver;
            _exactSolutionEquation = exactSolutionEquation;
            _solvingSystem = solvingSystem;

            CalculationRecords = new CalculationRecord[_solvingSystem.NumberOfIterations];
        }

        public void StartCalculations(double[] initialConditions)
        {
            var tempData = new double[initialConditions.Length];

            for (int i = 0; i < tempData.Length; i++)
            {
                tempData[i] = initialConditions[i];
            }

            for (int i = 0; i < _solvingSystem.NumberOfIterations; i++)
            {
                var xValue = tempData[0];
                var calculatedSolverValue = tempData[1];
                var exactSolutionValue = _exactSolutionEquation.CalculateResult(new[] { xValue });
                var error = calculatedSolverValue - exactSolutionValue;

                CalculationRecords[i] = new CalculationRecord(xValue, calculatedSolverValue, exactSolutionValue, error);
                
                tempData = _numericalSolver.Solve(tempData);
                tempData[0] = Math.Round(xValue + _solvingSystem.Step, 5);
            }
        }
    }
}
