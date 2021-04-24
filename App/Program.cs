using App.Display;
using App.Factories;
using App.Helpers;
using App.Models;
using App.Solvers;
using App.System;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleDisplayer.DisplayWelcomeMessage();

            var solvingSystem = SolvingSystemInitializer.Execute();
            var odeFatory = OdeSystemFactoryGenerator.Generate();

            var systemOfEquations = odeFatory.CreateSystemDifferentialEquations();
            var exactSolutionEquation = odeFatory.CreateExactSolutionEquation();
            var initialConditions = odeFatory.CreateInitialConditions(solvingSystem.StartingPoint);

            var solver = new RungeKuttaFehlberg56(systemOfEquations, solvingSystem.Step);
            var calculationProcessor = new CalculationProcessor(solver, exactSolutionEquation, solvingSystem);

            calculationProcessor.StartCalculations(initialConditions);

            var csvHelper = new CsvFileHelper();
            csvHelper.SaveCSV(calculationProcessor.CalculationRecords);

            ConsoleDisplayer.DisplayFarewellMessage();
        }
    }
}
