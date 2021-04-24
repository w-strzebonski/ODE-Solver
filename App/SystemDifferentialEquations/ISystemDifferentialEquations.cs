using App.Equations;

namespace App.SystemDifferentialEquations
{
    interface ISystemDifferentialEquations
    {
        IEquation[] Equations { get; }

        double[] Calculate(double[] input);
    }
}
