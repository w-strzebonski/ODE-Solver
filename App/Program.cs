using App.Equations;
using App.Equations.ExactSolutionEquations;
using App.Models;
using App.Solvers;
using App.SystemDifferentialEquations;
using System;
using System.IO;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var step = 0.0001;
            var from = 0d;
            var to = 3d;

            var equations = new TestOneEquationAsSystem();
            var exacEquation = new WolframExactEquation();
            var solver = new RungeKuttaFehlberg56(equations, step);

            var numericalResolver = new MainResolver(solver, from, to, step);
            var exactResolver = new ExactSolutionResolver(exacEquation, from, to, step);
            var errorCalculator = new NumericalExactErrorCalculator(numericalResolver, exactResolver);

            double[] initialConditions = new double[equations.Equations.Length + 1];

            initialConditions[0] = from;
            initialConditions[1] = 2d;

            numericalResolver.Execute(initialConditions);
            exactResolver.Execute(initialConditions);
            errorCalculator.Calculate();

            var savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/danesymulacji.txt";

            var resultWriter = new TxtFileSaver(numericalResolver, exactResolver, errorCalculator, savePath);

            resultWriter.Execute();
        }
    }
}
