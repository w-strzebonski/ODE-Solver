using System;
using System.Collections.Generic;
using System.Text;

namespace App.Interfaces
{
    interface IRungeKuttaSolver : ISolver
    {
        int[] aCoefficients { get; }
        int[] bCoefficients { get; }
        int[,] cCoeficcients { get; }
    }
}
