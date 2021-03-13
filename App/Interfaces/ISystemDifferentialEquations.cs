using System;
using System.Collections.Generic;
using System.Text;

namespace App.Interfaces
{
    interface ISystemDifferentialEquations
    {
        IEquation[] Equations { get; }

        double[] Calculate(double[] input);
    }
}
