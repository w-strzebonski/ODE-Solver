using System;

namespace App.Equation.ExactSolutionEquation
{
    public class SecondOrderExactEquation : IEquation
    {
        public double CalculateResult(double[] input)
        {
            double x = input[0];

            return Math.Exp(-x) * Math.Sin(Math.Sqrt(2) * x) * Math.Sqrt(2) / 2 + Math.Exp(-x) * (Math.Cos(Math.Sqrt(2) * x) 
                - Math.Cos(x) + Math.Sin(x)) / 4;
        }
    }
}