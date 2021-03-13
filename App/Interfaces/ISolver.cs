using System;
using System.Collections.Generic;
using System.Text;

namespace App.Interfaces
{
    interface ISolver
    {
        ISystemDifferentialEquations SystemDifferentialEquations { get; }
        double[] Solve(double[] input);
    }
}
