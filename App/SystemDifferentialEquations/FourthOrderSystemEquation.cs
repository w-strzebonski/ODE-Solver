using App.Equations.FourthOrderEquations;
using App.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.SystemDifferentialEquations
{
    class FourthOrderSystemEquation : ISystemDifferentialEquations
    {
        public IEquation[] Equations { get; private set; }

        public FourthOrderSystemEquation()
        {
            PrepareEquations();
        }

        public double[] Calculate(double[] input)
        {
            double[] result = new double[Equations.Length + 1];

            result[0] = input[0];
            result[1] = Equations[0].CalculateResult(input);
            result[2] = Equations[1].CalculateResult(input);
            result[3] = Equations[2].CalculateResult(input);
            result[4] = Equations[3].CalculateResult(input);

            return result;
        }

        private void PrepareEquations()
        {
            Equations = new IEquation[4];

            Equations[0] = new FourthOrderFirstEquation();
            Equations[1] = new FourthOrderSecondEquation();
            Equations[2] = new FourthOrderThirdEquation();
            Equations[3] = new FourthOrderFinalEquation();
        }
    }
}
