using App.Equation;
using App.Equation.ExactSolutionEquation;
using App.SystemDifferentialEquation;

namespace App.Factory
{
    class FirstOrderOdeFactory : IOdeSystemFactory
    {
        public IEquation CreateExactSolutionEquation()
        {
            return new FirstOrderExactEquation();
        }

        public double[] CreateInitialConditions(double startingPoint)
        {
            var initialConditions = new double[2];
            initialConditions[0] = startingPoint;
            initialConditions[1] = 2d;

            return initialConditions;
        }

        public ISystemDifferentialEquations CreateSystemDifferentialEquations()
        {
            return new FirstOrderSystemEquation();
        }
    }
}
