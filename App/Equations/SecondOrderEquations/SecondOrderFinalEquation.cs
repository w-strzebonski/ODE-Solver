using App.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Equations
{
    class SecondOrderFinalEquation : IEquation
    {
        public double CalculateResult(double[] input)
        {
            double x = input[0];
            double y1 = input[1];
            double y2 = input[2];

            //dy2/dx = ...
            return Math.Exp(x) * (Math.Pow(y1, 2) + y1 * y2) - 2 * Math.Exp(-x);
        }
    }
}
