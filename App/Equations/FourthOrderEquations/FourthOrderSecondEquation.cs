using App.Interfaces;

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
