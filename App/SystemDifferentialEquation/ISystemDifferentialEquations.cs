using App.Equation;

namespace App.SystemDifferentialEquation
{
    public interface ISystemDifferentialEquations
    {
        IEquation[] Equations { get; }

        double[] Calculate(double[] input);
    }
}
