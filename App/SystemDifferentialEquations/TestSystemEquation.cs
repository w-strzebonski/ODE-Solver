using App.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Equations
{
    class TestSystemEquation : ISystemDifferentialEquations
    {
        public IEquation[] Equations { get; private set; }

        public TestSystemEquation()
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

            Equations[0] = new FirstTestEquation();
            Equations[1] = new SecondTestEquation();
        }
    }
}
