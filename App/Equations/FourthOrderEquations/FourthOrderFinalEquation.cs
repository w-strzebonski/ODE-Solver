using App.Interfaces;
using System;

namespace App.Equations.FourthOrderEquations
{
    class FourthOrderFinalEquation : IEquation
    {
        public double CalculateResult(double[] input)
        {
            //dy4/dx = y1^2(x) - x^10 + 4x^9 - 4x^8 - 4x^7 + 8x^6 - 4x^4 + 120x - 48
            double x = input[0];
            double y1 = input[1];

            return Math.Pow(y1, 2) - Math.Pow(x, 10) + 4 * Math.Pow(x, 9) - 4 * Math.Pow(x, 8) - 4 * Math.Pow(x, 7) + 8 * Math.Pow(x, 6) - 4 * Math.Pow(x, 4) + 120 * x - 48;
        }
    }
}
