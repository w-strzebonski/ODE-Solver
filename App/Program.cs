using App.Equations;
using App.Equations.ExactSolutionEquations;
using App.Factories;
using App.Interfaces;
using App.Models;
using App.Solvers;
using App.System;
using App.SystemDifferentialEquations;
using System;
using System.IO;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = SolvingSystemInitializer.Execute();
            var odeFatory = OdeSystemFactoryGenerator.Generate();

            var systemOfEquations = odeFatory.CreateSystemDifferentialEquations();
            var exactSolutionEquation = odeFatory.CreateExactSolutionEquation();
            var initialConditions = odeFatory.CreateInitialConditions(system.StartingPoint);

            var solver = new RungeKuttaFehlberg56(systemOfEquations, system.Step);

            var numericalResolver = new MainResolver(solver, system.StartingPoint, system.EndingPoint, system.Step);
            var exactResolver = new ExactSolutionResolver(exactSolutionEquation, system.StartingPoint, system.EndingPoint, system.Step);
            var errorCalculator = new NumericalExactErrorCalculator(numericalResolver, exactResolver);

            numericalResolver.Execute(initialConditions);
            exactResolver.Execute(initialConditions);
            errorCalculator.Calculate();

            var savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/danesymulacji.txt";

            var resultWriter = new TxtFileSaver(numericalResolver, exactResolver, errorCalculator, savePath);

            resultWriter.Execute();
        }
    }
}
