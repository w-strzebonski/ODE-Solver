﻿using App.Equation;
using App.SystemDifferentialEquation;

namespace App.Factory
{
    interface IOdeSystemFactory
    {
        ISystemDifferentialEquations CreateSystemDifferentialEquations();
        IEquation CreateExactSolutionEquation();

        double[] CreateInitialConditions();
    }
}