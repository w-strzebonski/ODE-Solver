namespace App.Equation.FirstOrderEquation
{
    public class FirstOrderFinalEquation : IEquation
    {
        public double CalculateResult(double[] input)
        {
            double x = input[0];
            double y = input[1];

            return -2 * x * y;
        }
    }
}
