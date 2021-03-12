using App.Interfaces;
using System;

namespace App.Solvers
{
    class RungeKuttaFehlberg56 : IRungeKuttaSolver
    {
        public double[] aCoefficients { get; private set; }

        public double[] bCoefficients { get; private set; }

        public double[,] cCoeficcients { get; private set; }

        public RungeKuttaFehlberg56()
        {
            aCoefficients = new double[6];
            bCoefficients = new double[6];
            cCoeficcients = new double[6, 6];

            InitializeACoefficients();
            InitializeBCoefficients();
            InitializeCCoefficients();
        }

        public double Solve(double xi, double yi)
        {
            throw new NotImplementedException();
        }

        private void InitializeACoefficients()
        {
            aCoefficients[0] = 16d / 135d;
            aCoefficients[1] = 0d;
            aCoefficients[2] = 6656d / 12825d;
            aCoefficients[3] = 28561d / 56430d;
            aCoefficients[4] = -9d / 50d;
            aCoefficients[5] = 2d / 55d;
        }

        private void InitializeBCoefficients()
        {
            bCoefficients[0] = 0d;
            bCoefficients[1] = 1d / 4d;
            bCoefficients[2] = 3d / 8d;
            bCoefficients[3] = 12d / 13d;
            bCoefficients[4] = 1d;
            bCoefficients[5] = 1d / 2d;
        }

        private void InitializeCCoefficients()
        {
            cCoeficcients[1, 0] = 1d / 4d;
            cCoeficcients[2, 0] = 3d / 32d;
            cCoeficcients[2, 1] = 9d / 32d;
            cCoeficcients[3, 0] = 1932d / 2197d;
            cCoeficcients[3, 1] = -7200d / 2197d;
            cCoeficcients[3, 2] = 7296d / 2197d;
            cCoeficcients[4, 0] = 439d / 216d;
            cCoeficcients[4, 1] = -8d;
            cCoeficcients[4, 2] = 3680d / 513d;
            cCoeficcients[4, 3] =  -845d / 4104d;
            cCoeficcients[5, 0] = -8d / 27d;
            cCoeficcients[5, 1] = 2d;
            cCoeficcients[5, 2] = -3544d / 2565d;
            cCoeficcients[5, 3] = 1859d / 4104d;
            cCoeficcients[5, 4] = -11d / 40d;
        }
    }
}
