using System;
using System.Collections.Generic;
using System.Text;

namespace App.Interfaces
{
    interface IResolver
    {
        ISolver DifferentialSolver { get; }
        double Step { get; }
        double StartBoundary { get; }
        double StopBoundary { get; }
        (double, double)[] Data { get; }

        void Execute(double[] initialConditions);
    }
}
