using System;

namespace App.Equation.SecondOrderEquation
{
    public class SecondOrderFinalEquation : IEquation
    {
        public double CalculateResult(double[] input)
        {
            double x = input[0];
            double y1 = input[1];
            double y2 = input[2];

            //dy2/dx = ...
            return Math.Sin(x) - 2 * y2 - 3 * y1;
        }
    }
}
