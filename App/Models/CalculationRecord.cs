using CsvHelper.Configuration.Attributes;

namespace App.Models

{
    struct CalculationRecord
    {
        [Name("Calculation point value")]
        public double XValue { get; set; }

        [Name("Calculated value")]
        public double SolverCalculationResult { get; set; }

        [Name("Exact solution value")]
        public double ExactSolutionResult { get; set; }

        [Name("Error")]
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
