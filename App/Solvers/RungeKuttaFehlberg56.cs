using App.Solvers;

namespace App.SystemDifferentialEquations
{
    class RungeKuttaFehlberg56 : IRungeKuttaSolver
    {
        public double[] aCoefficients { get; private set; }

        public double[] bCoefficients { get; private set; }

        public double[,] cCoeficcients { get; private set; }

        public ISystemDifferentialEquations SystemDifferentialEquations { get; private set; }
        private double _step;
        private double[] _k1, _k2, _k3, _k4, _k5, _k6;

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

            _k1 = SystemDifferentialEquations.Calculate(input);

            shiftedValue = PrepareShiftedValuesForK2(input);
            _k2 = SystemDifferentialEquations.Calculate(shiftedValue);

            shiftedValue = PrepareShiftedValuesForK3(input);
            _k3 = SystemDifferentialEquations.Calculate(shiftedValue);

            shiftedValue = PrepareShiftedValuesForK4(input);
            _k4 = SystemDifferentialEquations.Calculate(shiftedValue);

            shiftedValue = PrepareShiftedValuesForK5(input);
            _k5 = SystemDifferentialEquations.Calculate(shiftedValue);

            shiftedValue = PrepareShiftedValuesForK6(input);
            _k6 = SystemDifferentialEquations.Calculate(shiftedValue);

            return ReturnCalculatedValues(input);
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

        private double[] PrepareShiftedValuesForK2(double[] input)
        {
            double[] result = new double[input.Length];

            result[0] = input[0] + _step * bCoefficients[1];

            for (int i = 1; i < input.Length; i++)
            {
                result[i] = input[i] + _step * cCoeficcients[1, 0] * _k1[i];
            }

            return result;
        }

        private double[] PrepareShiftedValuesForK3(double[] input)
        {
            double[] result = new double[input.Length];

            result[0] = input[0] + _step * bCoefficients[2];

            for (int i = 1; i < input.Length; i++)
            {
                result[i] = input[i] + _step * (cCoeficcients[2, 0] * _k1[i] + cCoeficcients[2, 1] * _k2[i]);
            }

            return result;
        }

        private double[] PrepareShiftedValuesForK4(double[] input)
        {
            double[] result = new double[input.Length];

            result[0] = input[0] + _step * bCoefficients[3];

            for (int i = 1; i < input.Length; i++)
            {
                result[i] = input[i] + _step * (cCoeficcients[3, 0] * _k1[i] + cCoeficcients[3, 1] * _k2[i] + cCoeficcients[3, 2] * _k3[i]);
            }

            return result;
        }

        private double[] PrepareShiftedValuesForK5(double[] input)
        {
            double[] result = new double[input.Length];

            result[0] = input[0] + _step * bCoefficients[4];

            for (int i = 1; i < input.Length; i++)
            {
                result[i] = input[i] + _step * (cCoeficcients[4, 0] * _k1[i] + cCoeficcients[4, 1] * _k2[i] + cCoeficcients[4, 2] * _k3[i] + cCoeficcients[4, 3] * _k4[i]);
            }

            return result;
        }

        private double[] PrepareShiftedValuesForK6(double[] input)
        {
            double[] result = new double[input.Length];

            result[0] = input[0] + _step * bCoefficients[5];

            for (int i = 1; i < input.Length; i++)
            {
                result[i] = input[i] + _step * (cCoeficcients[5, 0] * _k1[i] + cCoeficcients[5, 1] * _k2[i] + cCoeficcients[5, 2] * _k3[i] + cCoeficcients[5, 3] * _k4[i] + cCoeficcients[5, 4] * _k5[i]);
            }

            return result;
        }

        private double[] ReturnCalculatedValues(double[] input)
        {
            double[] result = new double[input.Length];

            result[0] = input[0];

            for (int i = 1; i < result.Length; i++)
            {
                result[i] = input[i] + _step * (aCoefficients[0] * _k1[i] + aCoefficients[1] * _k2[i] + aCoefficients[2] * _k3[i] + aCoefficients[3] * _k4[i] + aCoefficients[4] * _k5[i] + aCoefficients[5] * _k6[i]);
            }

            return result;
        }
    }
}
