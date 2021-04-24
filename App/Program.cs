using App.Equations;
using App.Equations.ExactSolutionEquations;
using App.Factories;
using App.Helpers;
using App.Interfaces;
using App.Models;
using App.Solvers;
using App.System;
using App.SystemDifferentialEquations;
using CsvHelper;
using System;
using System.Globalization;
using System.IO;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
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
        }
    }
}
