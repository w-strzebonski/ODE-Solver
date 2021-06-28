using App.Equation;
using App.SystemDifferentialEquation;

namespace App.Factory
{
    public interface IOdeSystemFactory
    {
        ISystemDifferentialEquations CreateSystemDifferentialEquations();
        IEquation CreateExactSolutionEquation();

        double[] CreateInitialConditions(double startingPoint);
    }
}
