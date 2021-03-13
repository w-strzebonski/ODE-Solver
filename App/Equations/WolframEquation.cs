using App.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Equations
{
    class WolframEquation : IEquation
    {
        public double CalculateResult(double[] input)
        {
            double x = input[0];
            double y = input[1];

            return -2 * x * y;
        }
    }
}
