using App.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Equations
{
    class TestEquation : IEquation
    {
        public double CalculateResult(double[] input)
        {
            double x = input[0];
            double y = input[1];

            return Math.Pow(x, 2) * Math.Pow(y, 2);
        }
    }
}
