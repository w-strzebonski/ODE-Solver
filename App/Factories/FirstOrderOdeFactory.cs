using App.Equations.ExactSolutionEquations;
using App.Interfaces;
using App.SystemDifferentialEquations;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Factories
{
    class FirstOrderOdeFactory : IOdeSystemFactory
    {
        public IEquation CreateExactSolutionEquation()
        {
            return new FirstOrderExactEquation();
        }

        public double[] CreateInitialConditions(double startPoint)
        {
            var initialConditions = new double[2];
            initialConditions[1] = 2d;

            return initialConditions;
        }

        public ISystemDifferentialEquations CreateSystemDifferentialEquations()
        {
            return new FirstOrderSystemEquation();
        }
    }
}
