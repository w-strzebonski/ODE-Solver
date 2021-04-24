﻿using App.Equations;
using App.Equations.ExactSolutionEquations;
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
            ISolvingSystem solvingSystem = SolvingSystemInitializer.Execute();
            
            
            var step = 0.0001;
            var from = 0d;
            var to = 1d;

            var equations = new FourthOrderSystemEquation();
            var exacEquation = new FourthOrderExactEquation();
            var solver = new RungeKuttaFehlberg56(equations, step);

            var numericalResolver = new MainResolver(solver, from, to, step);
            var exactResolver = new ExactSolutionResolver(exacEquation, from, to, step);
            var errorCalculator = new NumericalExactErrorCalculator(numericalResolver, exactResolver);

            double[] initialConditions = new double[equations.Equations.Length + 1];

            initialConditions[0] = from;
            initialConditions[1] = 0d;
            initialConditions[2] = 0d;
            initialConditions[3] = 4d;
            initialConditions[4] = 0d;

            numericalResolver.Execute(initialConditions);
            exactResolver.Execute(initialConditions);
            errorCalculator.Calculate();

            var savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/danesymulacji.txt";

            var resultWriter = new TxtFileSaver(numericalResolver, exactResolver, errorCalculator, savePath);

            resultWriter.Execute();
        }
    }
}
