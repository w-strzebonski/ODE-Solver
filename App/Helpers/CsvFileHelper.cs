using App.Models;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace App.Helpers
{
    class CsvFileHelper
    {
        private readonly string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public string Path { get; private set; }

        public CsvFileHelper()
        {
            Path = DesktopPath + "/calculationData.csv";
        }

        public CsvFileHelper(string path)
        {
            Path = path;
        }

        public bool SaveCSV(IEnumerable<CalculationRecord> data)
        {
            if (string.IsNullOrEmpty(Path)) return false;

            using (var writer = new StreamWriter(Path))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(data);
            }

            return true;
        }
    }
}
