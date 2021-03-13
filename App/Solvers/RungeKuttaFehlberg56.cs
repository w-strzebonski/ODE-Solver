using App.Interfaces;
using System;

namespace App.Solvers
{
    class RungeKuttaFehlberg56 : IRungeKuttaSolver
    {
        public double[] aCoefficients { get; private set; }

        public double[] bCoefficients { get; private set; }

        public double[,] cCoeficcients { get; private set; }

        public ISystemDifferentialEquations SystemDifferentialEquations { get; private set; }
        private double _step;

        public RungeKuttaFehlberg56(ISystemDifferentialEquations equations, double step)
        {
            SystemDifferentialEquations = equations;
            _step = step;

            aCoefficients = new double[6];
            bCoefficients = new double[6];
            cCoeficcients = new double[6, 6];

            InitializeACoefficients();
            InitializeBCoefficients();
            InitializeCCoefficients();
        }

        public double[] Solve(double[] input)
        {
            double[] shiftedValue;
            
            double[] k1 = SystemDifferentialEquations.Calculate(input);

            shiftedValue = PrepareShiftedValuesForK2(input, k1);
            double[] k2 = SystemDifferentialEquations.Calculate(shiftedValue);

            shiftedValue = PrepareShiftedValuesForK3(input, k1, k2);
            double[] k3 = SystemDifferentialEquations.Calculate(shiftedValue);

            shiftedValue = PrepareShiftedValuesForK4(input, k1, k2, k3);
            double[] k4 = SystemDifferentialEquations.Calculate(shiftedValue);

            shiftedValue = PrepareShiftedValuesForK5(input, k1, k2, k3, k4);
            double[] k5 = SystemDifferentialEquations.Calculate(shiftedValue);

            shiftedValue = PrepareShiftedValuesForK6(input, k1, k2, k3, k4, k5);
            double[] k6 = SystemDifferentialEquations.Calculate(shiftedValue);

            return ReturnCalculatedValues(input, k1, k2, k3, k4, k5, k6);
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

        private double[] PrepareShiftedValuesForK2(double[] input, double[] k1)
        {
            double[] result = new double[input.Length];

            result[0] = input[0] + _step * bCoefficients[1];

            for (int i = 1; i < input.Length; i++)
            {
                result[i] = input[i] + _step * cCoeficcients[1, 0] * k1[i];
            }

            return result;
        }

        private double[] PrepareShiftedValuesForK3(double[] input, double[] k1, double[] k2)
        {
            double[] result = new double[input.Length];

            result[0] = input[0] + _step * bCoefficients[2];

            for (int i = 1; i < input.Length; i++)
            {
                result[i] = input[i] + _step * (cCoeficcients[2, 0] * k1[i] + cCoeficcients[2, 1] * k2[i]);
            }

            return result;
        }

        private double[] PrepareShiftedValuesForK4(double[] input, double[] k1, double[] k2, double[] k3)
        {
            double[] result = new double[input.Length];

            result[0] = input[0] + _step * bCoefficients[3];

            for (int i = 1; i < input.Length; i++)
            {
                result[i] = input[i] + _step * (cCoeficcients[3, 0] * k1[i] + cCoeficcients[3, 1] * k2[i] + cCoeficcients[3, 2] * k3[i]);
            }

            return result;
        }

        private double[] PrepareShiftedValuesForK5(double[] input, double[] k1, double[] k2, double[] k3, double[] k4)
        {
            double[] result = new double[input.Length];

            result[0] = input[0] + _step * bCoefficients[4];

            for (int i = 1; i < input.Length; i++)
            {
                result[i] = input[i] + _step * (cCoeficcients[4, 0] * k1[i] + cCoeficcients[4, 1] * k2[i] + cCoeficcients[4, 2] * k3[i] + cCoeficcients[4, 3] * k4[i]);
            }

            return result;
        }

        private double[] PrepareShiftedValuesForK6(double[] input, double[] k1, double[] k2, double[] k3, double[] k4, double[] k5)
        {
            double[] result = new double[input.Length];

            result[0] = input[0] + _step * bCoefficients[5];

            for (int i = 1; i < input.Length; i++)
            {
                result[i] = input[i] + _step * (cCoeficcients[5, 0] * k1[i] + cCoeficcients[5, 1] * k2[i] + cCoeficcients[5, 2] * k3[i] + cCoeficcients[5, 3] * k4[i] + cCoeficcients[5, 4] * k5[i]);
            }

            return result;
        }

        private double[] ReturnCalculatedValues(double[] input, double[] k1, double[] k2, double[] k3, double[] k4, double[] k5, double[] k6)
        {
            double[] result = new double[input.Length];

            result[0] = input[0];

            for (int i = 1; i < result.Length; i++)
            {
                result[i] = input[i] + _step * (aCoefficients[0] * k1[i] + aCoefficients[1] * k2[i] + aCoefficients[2] * k3[i] + aCoefficients[3] * k4[i] + aCoefficients[4] * k5[i] + aCoefficients[5] * k6[i]);
            }

            return result;
        }
    }
}
