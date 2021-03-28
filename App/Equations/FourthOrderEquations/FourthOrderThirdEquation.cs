using App.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Equations.FourthOrderEquations
{
    class FourthOrderThirdEquation : IEquation
    {
        public double CalculateResult(double[] input)
        {
            //dy3/dx = y4
            return input[4];
        }
    }
}
