using System;
using System.Collections.Generic;
using System.Text;

namespace App.Interfaces
{
    interface IRungeKuttaSolver
    {
        int[] aCoefficients { get; }
        int[] bCoefficients { get; }
        int[,] cCoeficcients { get; }

        double Solve(double xi, double yi);
    }
}
