using App.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Equations
{
    class SecondOrderFirstEquation : IEquation
    {
        public double CalculateResult(double[] input)
        {
            //dy1/dx = y2
            return input[2];
        }
    }
}
