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
            string[] lines = new string[_resolver.Data.Count];
            int counter = 0;

            foreach (var item in _resolver.Data)
            {
                lines[counter] = $"{item.Key}, {item.Value}";
            }

            return lines;
        }

        //Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/danesymulacji.txt"
    }
}
