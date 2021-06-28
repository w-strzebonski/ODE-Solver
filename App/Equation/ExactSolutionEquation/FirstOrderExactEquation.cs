using System;

namespace App.Equation.ExactSolutionEquation
{
    public class FirstOrderExactEquation : IEquation
    {
        public double CalculateResult(double[] input)
        {
            //y(x) = 2 * e^(-x^2)
            double x = input[0];
            return 2 * Math.Exp(-Math.Pow(x, 2));
        }
    }
}
