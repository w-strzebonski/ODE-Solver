using App.SystemDifferentialEquations;

namespace App.Solvers
{
    interface ISolver
    {
        ISystemDifferentialEquations SystemDifferentialEquations { get; }
        double[] Solve(double[] input);
    }
}
