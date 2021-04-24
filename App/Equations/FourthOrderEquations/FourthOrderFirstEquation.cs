using App.SystemDifferentialEquations;

namespace App.Equations.FourthOrderEquations
{
    class FourthOrderFirstEquation : IEquation
    {
        public double CalculateResult(double[] input)
        {
            //dy1/dx = y2
            return input[2];
        }
    }
}
