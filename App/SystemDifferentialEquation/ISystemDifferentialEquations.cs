using App.Equation;

namespace App.SystemDifferentialEquation
{
    interface ISystemDifferentialEquations
    {
        IEquation[] Equations { get; }

        double[] Calculate(double[] input);
    }
}
