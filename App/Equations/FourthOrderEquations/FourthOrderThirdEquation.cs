using App.SystemDifferentialEquations;

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
