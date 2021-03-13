using App.Equations;
using App.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.SystemDifferentialEquations
{
    class TestOneEquationAsSystem : ISystemDifferentialEquations
    {
        public IEquation[] Equations { get; private set; }

        public TestOneEquationAsSystem()
        {
            PrepareEquations();
        }

        public double[] Calculate(double[] input)
        {
            double[] result = new double[2];

            result[0] = input[0];
            result[1] = Equations[0].CalculateResult(input);

            return result;
        }
        private void PrepareEquations()
        {
            Equations = new IEquation[1];

            Equations[0] = new WolframEquation();
        }
    }
}
