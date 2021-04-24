using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models
{
    class CalculationRecord
    {
        public double XValue { get; set; }
        public double SolverCalculationResult { get; set; }
        public double ExactSolutionResult { get; set; }
        public double Error { get; set; }

        public CalculationRecord(double xValue, double solverCalculationResult, double exactSolutionResult, double error)
        {
            XValue = xValue;
            SolverCalculationResult = solverCalculationResult;
            ExactSolutionResult = exactSolutionResult;
            Error = error;
        }
    }
}
