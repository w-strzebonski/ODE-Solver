using System;
using System.Collections.Generic;
using System.Text;

namespace App.System
{
    class SolvingSystem : ISolvingSystem
    {
        public double StartingPoint { get; private set; }

        public double EndingPoint { get; private set; }

        public double Step { get; private set; }

        public int NumberOfIterations { get; private set; }

        public SolvingSystem()
        {
            StartingPoint = 0;
            EndingPoint = 1;
            Step = 0.05;
            NumberOfIterations = CalculateNumberOfIterations();
        }

        public SolvingSystem(double startingPoint, double endingPoint, double step)
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
