using App.Equations;
using App.SystemDifferentialEquations;

namespace App.Factories
{
    interface IOdeSystemFactory
    {
        ISystemDifferentialEquations CreateSystemDifferentialEquations();
        IEquation CreateExactSolutionEquation();

        double[] CreateInitialConditions(double startPoint);
    }
}
