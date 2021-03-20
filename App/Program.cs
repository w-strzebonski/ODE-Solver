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

            double[] initialConditions = new double[equations.Equations.Length + 1];

            initialConditions[0] = from;
            initialConditions[1] = 2d;

            numericalResolver.Execute(initialConditions);
            exactResolver.Execute(initialConditions);

            var savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/danesymulacji.txt";
            var savePathExact = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/danesymulacjidokladne.txt";
            var savePathError = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/danesymulacjiblad.txt";

            var resultWriter = new TxtFileSaver(numericalResolver, savePath);
            var resultWriterExact = new TxtFileSaver(exactResolver, savePathExact);

            string[] error = new string[numericalResolver.Data.Length];

            for (int i = 0; i < error.Length; i++)
            {
                error[i] = (numericalResolver.Data[i].Item2 - exactResolver.Data[i].Item2).ToString();
            }

            resultWriter.Execute();
            resultWriterExact.Execute();
            File.WriteAllLines(savePathError, error);
        }
    }
}
