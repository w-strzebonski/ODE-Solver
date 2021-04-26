using System;

namespace App.System
{
    class SolvingSystemData : ISolvingSystemData
    {
        public double StartingPoint { get; }

        public double EndingPoint { get; }

        public double Step { get; }

        public int NumberOfIterations { get; }

        public SolvingSystemData()
        {
            StartingPoint = 0;
            EndingPoint = 1;
            Step = 0.05;
            NumberOfIterations = CalculateNumberOfIterations();
        }

        public SolvingSystemData(double startingPoint, double endingPoint, double step)
        {
            StartingPoint = startingPoint;
            EndingPoint = endingPoint;
            Step = step;
            NumberOfIterations = CalculateNumberOfIterations();
        }

        private int CalculateNumberOfIterations()
        {
            int numberOfIterations = Convert.ToInt32(Math.Abs(EndingPoint - StartingPoint) / Step);

            return numberOfIterations;
        }
    }
}
