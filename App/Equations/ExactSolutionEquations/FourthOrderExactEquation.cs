using App.Interfaces;
using System;

namespace App.Equations.ExactSolutionEquations
{
    class FourthOrderExactEquation : IEquation
    {
        public double CalculateResult(double[] input)
        {
            //y(x) = x^5 - 2x^4 + 2x^2
            double x = input[0];

            return Math.Pow(x, 5) - 2 * Math.Pow(x, 4) + 2 * Math.Pow(x, 2);
        }
    }
}
