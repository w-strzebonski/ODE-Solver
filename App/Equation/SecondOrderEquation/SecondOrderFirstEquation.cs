namespace App.Equation.SecondOrderEquation
{
    public class SecondOrderFirstEquation : IEquation
    {
        public double CalculateResult(double[] input)
        {
            //dy1/dx = y2
            return input[2];
        }
    }
}
