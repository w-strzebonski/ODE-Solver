using App.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Factories
{
    interface IOdeSystemFactory
    {
        ISystemDifferentialEquations CreateSystemDifferentialEquations();
        IEquation CreateExactSolutionEquation();
    }
}
