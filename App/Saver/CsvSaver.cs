using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using App.Model;
using CsvHelper;

namespace App.Saver
{
    class CsvSaver : ISaver
    {
        public string SaveErrorMessage { get; private set; }
        public string Path { get; }

        private readonly string _desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private readonly string _fileName = "calculationData.csv";

        public static CsvSaver Create()
        {
            DisplayCreationMessage();
           
            var path = Console.ReadLine();
            Console.WriteLine();

            return string.IsNullOrEmpty(path) ? new CsvSaver() : new CsvSaver(path);
        }

        public bool Save(IEnumerable<CalculationRecord> data)
        {
            if (string.IsNullOrEmpty(Path)) return false;

            try
            {
                using var writer = new StreamWriter(Path);
                using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
                csv.WriteRecords(data);
            }
            catch (Exception e)
            {
                SaveErrorMessage = e.Message;
                return false;
            }

            return true;
        }

        private CsvSaver()
        {
            Path = $"{_desktopPath}\\{_fileName}";
        }

        private CsvSaver(string path)
        {
            Path = $"{path}\\{_fileName}";
        }

        private static void DisplayCreationMessage()
        {
            Console.WriteLine("Please enter the full path where the csv file from the calculation will be saved");
            Console.WriteLine("If you don't enter the path, the file will be saved to the desktop");
            Console.Write("> ");
        }
    }
}
