using System.Collections.Generic;
using App.SystemDifferentialEquation;

namespace App.Solver
{
    class RungeKuttaFehlberg56 : ISolver
    {
        private double[] _g1, _g2, _g3, _g4, _g5, _g6;
        
        private readonly ISystemDifferentialEquations _systemOfEquations;
        
        private readonly double _step;
        private readonly double[] _aCoefficients, _bCoefficients;
        private readonly double[,] _cCoefficients;

        public RungeKuttaFehlberg56(ISystemDifferentialEquations equations, double step)
        {
            _systemOfEquations = equations;
            _step = step;

            _aCoefficients = new double[6];
            _bCoefficients = new double[6];
            _cCoefficients = new double[6, 6];

            InitializeACoefficients();
            InitializeBCoefficients();
            InitializeCCoefficients();
        }

        public double[] Solve(double[] input)
        {
            _g1 = _systemOfEquations.Calculate(input);

            double[] shiftedValue = PrepareShiftedValuesForG2(input);
            _g2 = _systemOfEquations.Calculate(shiftedValue);

            shiftedValue = PrepareShiftedValuesForG3(input);
            _g3 = _systemOfEquations.Calculate(shiftedValue);

            shiftedValue = PrepareShiftedValuesForG4(input);
            _g4 = _systemOfEquations.Calculate(shiftedValue);

            shiftedValue = PrepareShiftedValuesForG5(input);
            _g5 = _systemOfEquations.Calculate(shiftedValue);

            shiftedValue = PrepareShiftedValuesForG6(input);
            _g6 = _systemOfEquations.Calculate(shiftedValue);

            return ReturnCalculatedValues(input);
        }

        private void InitializeACoefficients()
        {
            _aCoefficients[0] = 16d / 135d;
            _aCoefficients[1] = 0d;
            _aCoefficients[2] = 6656d / 12825d;
            _aCoefficients[3] = 28561d / 56430d;
            _aCoefficients[4] = -9d / 50d;
            _aCoefficients[5] = 2d / 55d;
        }

        private void InitializeBCoefficients()
        {
            _bCoefficients[0] = 0d;
            _bCoefficients[1] = 1d / 4d;
            _bCoefficients[2] = 3d / 8d;
            _bCoefficients[3] = 12d / 13d;
            _bCoefficients[4] = 1d;
            _bCoefficients[5] = 1d / 2d;
        }

        private void InitializeCCoefficients()
        {
            _cCoefficients[1, 0] = 1d / 4d;
            _cCoefficients[2, 0] = 3d / 32d;
            _cCoefficients[2, 1] = 9d / 32d;
            _cCoefficients[3, 0] = 1932d / 2197d;
            _cCoefficients[3, 1] = -7200d / 2197d;
            _cCoefficients[3, 2] = 7296d / 2197d;
            _cCoefficients[4, 0] = 439d / 216d;
            _cCoefficients[4, 1] = -8d;
            _cCoefficients[4, 2] = 3680d / 513d;
            _cCoefficients[4, 3] =  -845d / 4104d;
            _cCoefficients[5, 0] = -8d / 27d;
            _cCoefficients[5, 1] = 2d;
            _cCoefficients[5, 2] = -3544d / 2565d;
            _cCoefficients[5, 3] = 1859d / 4104d;
            _cCoefficients[5, 4] = -11d / 40d;
        }

        private double[] PrepareShiftedValuesForG2(IReadOnlyList<double> input)
        {
            double[] result = new double[input.Count];

            result[0] = input[0] + _step * _bCoefficients[1];

            for (int i = 1; i < input.Count; i++)
            {
                result[i] = input[i] + _step * _cCoefficients[1, 0] * _g1[i];
            }

            return result;
        }

        private double[] PrepareShiftedValuesForG3(IReadOnlyList<double> input)
        {
            double[] result = new double[input.Count];

            result[0] = input[0] + _step * _bCoefficients[2];

            for (int i = 1; i < input.Count; i++)
            {
                result[i] = input[i] + _step * (_cCoefficients[2, 0] * _g1[i] + 
                                                _cCoefficients[2, 1] * _g2[i]);
            }

            return result;
        }

        private double[] PrepareShiftedValuesForG4(IReadOnlyList<double> input)
        {
            double[] result = new double[input.Count];

            result[0] = input[0] + _step * _bCoefficients[3];

            for (int i = 1; i < input.Count; i++)
            {
                result[i] = input[i] + _step * (_cCoefficients[3, 0] * _g1[i] + 
                                                _cCoefficients[3, 1] * _g2[i] + 
                                                _cCoefficients[3, 2] * _g3[i]);
            }

            return result;
        }

        private double[] PrepareShiftedValuesForG5(IReadOnlyList<double> input)
        {
            double[] result = new double[input.Count];

            result[0] = input[0] + _step * _bCoefficients[4];

            for (int i = 1; i < input.Count; i++)
            {
                result[i] = input[i] + _step * (_cCoefficients[4, 0] * _g1[i] + 
                                                _cCoefficients[4, 1] * _g2[i] + 
                                                _cCoefficients[4, 2] * _g3[i] + 
                                                _cCoefficients[4, 3] * _g4[i]);
            }

            return result;
        }

        private double[] PrepareShiftedValuesForG6(IReadOnlyList<double> input)
        {
            double[] result = new double[input.Count];

            result[0] = input[0] + _step * _bCoefficients[5];

            for (int i = 1; i < input.Count; i++)
            {
                result[i] = input[i] + _step * (_cCoefficients[5, 0] * _g1[i] + 
                                                _cCoefficients[5, 1] * _g2[i] + 
                                                _cCoefficients[5, 2] * _g3[i] + 
                                                _cCoefficients[5, 3] * _g4[i] + 
                                                _cCoefficients[5, 4] * _g5[i]);
            }

            return result;
        }

        private double[] ReturnCalculatedValues(IReadOnlyList<double> input)
        {
            double[] result = new double[input.Count];

            result[0] = input[0];

            for (int i = 1; i < result.Length; i++)
            {
                result[i] = input[i] + _step * (_aCoefficients[0] * _g1[i] + 
                                                _aCoefficients[1] * _g2[i] +
                                                _aCoefficients[2] * _g3[i] +
                                                _aCoefficients[3] * _g4[i] + 
                                                _aCoefficients[4] * _g5[i] + 
                                                _aCoefficients[5] * _g6[i]);
            }

            return result;
        }
    }
}
