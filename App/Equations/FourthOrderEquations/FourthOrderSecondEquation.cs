using App.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Equations.FourthOrderEquations
{
    class FourthOrderSecondEquation : IEquation
    {
        public double CalculateResult(double[] input)
        {
            //dy2/dx = y3
            return input[3];
        }
    }
}
