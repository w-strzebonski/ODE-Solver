using App.Equations;
using App.Equations.ExactSolutionEquations;
using App.SystemDifferentialEquations;

namespace App.Factories
{
    class FourthOrderOdeFactory : IOdeSystemFactory
    {
        public IEquation CreateExactSolutionEquation()
        {
            return new FourthOrderExactEquation();
        }

        public double[] CreateInitialConditions(double startPoint)
        {
            var initialConditions = new double[5];
            initialConditions[1] = 0d;
            initialConditions[2] = 0d;
            initialConditions[3] = 4d;
            initialConditions[4] = 0d;

            return initialConditions;
        }

        public ISystemDifferentialEquations CreateSystemDifferentialEquations()
        {
            return new FourthOrderSystemEquation();
        }
    }
}
