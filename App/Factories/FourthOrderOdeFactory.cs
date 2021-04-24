using App.Equations.ExactSolutionEquations;
using App.Interfaces;
using App.SystemDifferentialEquations;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Factories
{
    class FourthOrderOdeFactory : IOdeSystemFactory
    {
        public IEquation CreateExactSolutionEquation()
        {
            return new FourthOrderExactEquation();
        }

        public ISystemDifferentialEquations CreateSystemDifferentialEquations()
        {
            return new FourthOrderSystemEquation();
        }
    }
}
