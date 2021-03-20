using App.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Equations.ExactSolutionEquations
{
    class WolframExactEquation : IEquation
    {
        public double CalculateResult(double[] input)
        {
            //y(x) = 2 * e^(-x^2)
            double x = input[0];
            return 2 * Math.Exp(Math.Pow(-x, 2));
        }
    }
}
