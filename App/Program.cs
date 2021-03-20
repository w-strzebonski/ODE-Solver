using App.Equations;
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
            var step = 0.1;
            var from = 0d;
            var to = 10d;

            var equations = new TestSystemEquation();
            var solver = new RungeKuttaFehlberg56(equations, step);

            var resolver = new MainResolver(solver, from, to, step);

            double[] initialConditions = new double[equations.Equations.Length + 1];

            initialConditions[0] = from;
            initialConditions[1] = 0d;
            initialConditions[2] = 1d;

            resolver.Execute(initialConditions);

            var savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/danesymulacji.txt";

            var resultWriter = new TxtFileSaver(resolver, savePath);
            resultWriter.Execute();
        }
    }
}
