namespace App.Interfaces
{
    interface ISolver
    {
        ISystemDifferentialEquations SystemDifferentialEquations { get; }
        double[] Solve(double[] input);
    }
}
