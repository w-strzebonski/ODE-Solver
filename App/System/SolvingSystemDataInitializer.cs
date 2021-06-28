using System;

namespace App.System
{
    public static class SolvingSystemDataInitializer
    {
        public static ISolvingSystemData Execute()
        {
            var startingPointInput = ReadInformationFromUser("Insert the beginning of calculation interval");
            var endingPointInput = ReadInformationFromUser("Insert the end of calculation interval");
            var stepInput = ReadInformationFromUser("Insert the solution step value");

            if (!double.TryParse(startingPointInput, out var startingPoint))
                DisplayMessageAndExit("Entered value of the beginning of calculation interval must be a floating-point number");

            if (!double.TryParse(endingPointInput, out var endingPoint))
                DisplayMessageAndExit("Entered value of the end of calculation must be a floating-point number");

            if (!double.TryParse(stepInput, out var step) && step <= 0)
                DisplayMessageAndExit("Entered value of the solution step must be a floating-point number and greater than zero");

            if (startingPoint > endingPoint)
                DisplayMessageAndExit("Entered value of beginning of calculation must be lesser than the end of calculation interval");

            return new SolvingSystemData(startingPoint, endingPoint, step);
        }

        private static string ReadInformationFromUser(string displayMessage)
        {
            Console.WriteLine(displayMessage);
            Console.Write("> ");

            var input = Console.ReadLine();
            Console.WriteLine();

            return input;
        }
        
        private static void DisplayMessageAndExit(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
            Environment.Exit(-1);
        }
    }
}
