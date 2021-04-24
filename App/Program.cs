using App.Display;
using App.Factories;
using App.Helpers;
using App.Models;
using App.SystemDifferentialEquations;
using App.System;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleDisplayer.DisplayWelcomeMessage();

            var systemData = SolvingSystemDataInitializer.Execute();
            var odeFactory = OdeSystemFactoryGenerator.Generate();

            var systemOfEquations = odeFactory.CreateSystemDifferentialEquations();
            var exactSolutionEquation = odeFactory.CreateExactSolutionEquation();
            var initialConditions = odeFactory.CreateInitialConditions(systemData.StartingPoint);

            var solver = new RungeKuttaFehlberg56(systemOfEquations, systemData.Step);
            var calculationProcessor = new CalculationProcessor(solver, exactSolutionEquation, systemData);

            calculationProcessor.StartCalculations(initialConditions);

            var csvHelper = CsvFileHelper.Create();
            csvHelper.SaveCSV(calculationProcessor.CalculationRecords);

            csvHelper.DisplaySavingResultMessageAndExit();
        }
    }
}
