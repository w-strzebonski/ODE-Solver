using App.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace App.Models
{
    class TxtFileSaver
    {
        private IResolver _numericalResolver;
        private IResolver _exactResolver;
        private IErrorCalculator _errorCalculator;
        private string _path;

        public TxtFileSaver(IResolver numericalResolver, IResolver exactResolver, IErrorCalculator errorCalculator, string path)
        {
            _numericalResolver = numericalResolver;
            _exactResolver = exactResolver;
            _errorCalculator = errorCalculator;
            _path = path;
        }

        public bool Execute()
        {
            var dataAsStrings = TransferDataToStringLines();
            
            try
            {
                File.WriteAllLines(_path, dataAsStrings);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private IEnumerable<string> TransferDataToStringLines()
        {
            string[] lines = new string[_numericalResolver.Data.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = $"{_numericalResolver.Data[i].Item1}, {_numericalResolver.Data[i].Item2}, {_exactResolver.Data[i].Item2}, {_errorCalculator.Data[i].Item2}";
            }

            return lines;
        }
    }
}
