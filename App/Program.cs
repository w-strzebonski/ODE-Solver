using System;
using App.Display;
using App.Factory;
using App.Model;
using App.Saver;
using App.Solver;
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

            var saver = SaverFactory.CreateCsvSaver();
            var isSavedOk = saver.Save(calculationProcessor.CalculationRecords);

            ConsoleDisplayer.DisplayMessage(isSavedOk
                ? "The calculations were correctly saved in the indicated location! Press any key to exit..."
                : $"Error! {saver.SaveErrorMessage}");
        }
    }
}
