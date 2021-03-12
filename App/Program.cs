using App.Equations;
using App.Solvers;
using System;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var step = 0.0001;
            var equation = new TestEquation();
            var solver = new RungeKuttaFehlberg56(equation, step);


        }
    }
}
