using App.Solvers;
using System;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var solver = new RungeKuttaFehlberg56();
        }
    }
}
