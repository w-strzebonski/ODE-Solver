using App.Interfaces;

namespace App.Equations
{
    class SecondOrderSystemEquation : ISystemDifferentialEquations
    {
        public IEquation[] Equations { get; private set; }

        public SecondOrderSystemEquation()
        {
            PrepareEquations();
        }

        public double[] Calculate(double[] input)
        {
            double[] result = new double[3];

            result[0] = input[0];
            result[1] = Equations[0].CalculateResult(input);
            result[2] = Equations[1].CalculateResult(input);

            return result;
        }

        private void PrepareEquations()
        {
            Equations = new IEquation[2];

            Equations[0] = new SecondOrderFirstEquation();
            Equations[1] = new SecondOrderFinalEquation();
        }
    }
}
