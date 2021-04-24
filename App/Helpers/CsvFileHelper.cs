using App.Models;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace App.Helpers
{
    class CsvFileHelper
    {
        public string Path { get; private set; }

        private readonly string _desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private readonly string _fileName = "calculationData.csv";
        private string _exceptionMessage = string.Empty;

        public static CsvFileHelper Create()
        {
            Console.WriteLine("Please enter the full path where the csv file from the calculation will be saved");
            Console.WriteLine("If you don't enter the path, the file will be saved to the desktop");
            Console.WriteLine("> ");

            var path = Console.ReadLine();

            if (string.IsNullOrEmpty(path))
                return new CsvFileHelper();
            else
                return new CsvFileHelper(path);
        }

        public bool SaveCSV(IEnumerable<CalculationRecord> data)
        {
            if (string.IsNullOrEmpty(Path)) return false;

            try
            {
                using (var writer = new StreamWriter(Path))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(data);
                }
            }
            catch (Exception e)
            {
                _exceptionMessage = e.Message;
                return false;
            }

            return true;
        }

        public void DisplaySavingResultMessageAndExit()
        {
            if (string.IsNullOrEmpty(_exceptionMessage))
            {
                Console.WriteLine("The calculations were correctly saved in the indicated location! Press any key to exit...");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine($"Error! {_exceptionMessage}");
                Environment.Exit(-1);
            }
        }

        private CsvFileHelper()
        {
            Path = $"{_desktopPath}\\{_fileName}";
        }

        private CsvFileHelper(string path)
        {
            Path = $"{path}\\{_fileName}";
        }
    }
}
