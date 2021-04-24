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

        public SolvingSystem()
        {
            StartingPoint = 0;
            StartingPoint = 1;
            Step = 0.05;
        }

        public SolvingSystem(double startingPoint, double endingPoint, double step)
        {
            StartingPoint = startingPoint;
            EndingPoint = endingPoint;
            Step = step;
        }
    }
}
