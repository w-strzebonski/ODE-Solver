using App.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models
{
    class NumericalExactErrorCalculator : IErrorCalculator
    {
        public (double, double)[] Data { get; private set; }

        private INumericalResolver _numericalResolver;
        private IExactSolutionResolver _exactResolver;

        public NumericalExactErrorCalculator(INumericalResolver numericalResolver, IExactSolutionResolver exactResolver)
        {
            _numericalResolver = numericalResolver;
            _exactResolver = exactResolver;
        }

        public bool Calculate()
        {
            if (_numericalResolver == null || _exactResolver == null)
                return false;

            Data = new (double, double)[_numericalResolver.Data.Length];

            for (int i = 0; i < Data.Length; i++)
            {
                Data[i].Item1 = _numericalResolver.Data[i].Item1;
                Data[i].Item2 = _numericalResolver.Data[i].Item2 - _exactResolver.Data[i].Item2;
            }

            return true;
        }
    }
}
