using App.Equation;
using App.Equation.ExactSolutionEquation;
using App.SystemDifferentialEquation;

namespace App.Factory
{
    public class SecondOrderOdeFactory : IOdeSystemFactory
    {
        public ISystemDifferentialEquations CreateSystemDifferentialEquations()
        {
            return new SecondOrderSystemEquation();
        }

        public IEquation CreateExactSolutionEquation()
        {
            return new SecondOrderExactEquation();
        }

        public double[] CreateInitialConditions(double startingPoint)
        {
            var initialConditions = new double[3];
            initialConditions[0] = startingPoint;
            initialConditions[1] = 0d;
            initialConditions[2] = 1d;

            return initialConditions;
        }
    }
}