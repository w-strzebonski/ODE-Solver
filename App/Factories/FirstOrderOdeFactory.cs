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

        public ISystemDifferentialEquations CreateSystemDifferentialEquations()
        {
            return new FirstOrderSystemEquation();
        }
    }
}
