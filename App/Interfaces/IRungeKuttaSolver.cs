using System;
using System.Collections.Generic;
using System.Text;

namespace App.Interfaces
{
    interface IRungeKuttaSolver : ISolver
    {
        double[] aCoefficients { get; }
        double[] bCoefficients { get; }
        double[,] cCoeficcients { get; }
    }
}
