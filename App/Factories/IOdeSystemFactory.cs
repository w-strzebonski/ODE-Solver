using App.Interfaces;

namespace App.Factories
{
    interface IOdeSystemFactory
    {
        ISystemDifferentialEquations CreateSystemDifferentialEquations();
        IEquation CreateExactSolutionEquation();

        double[] CreateInitialConditions(double startPoint);
    }
}
