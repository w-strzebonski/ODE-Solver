using App.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace App.Models
{
    class TxtFileSaver
    {
        private IResolver _resolver;
        private string _path;

        public TxtFileSaver(IResolver resolver, string path)
        {
            _resolver = resolver;
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
            string[] lines = new string[_resolver.Data.Length];
            int counter = 0;

            foreach (var data in _resolver.Data)
            {
                lines[counter] = $"{data.Item1}, {data.Item2}";
                counter++;
            }

            return lines;
        }

        //Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/danesymulacji.txt"
    }
}
