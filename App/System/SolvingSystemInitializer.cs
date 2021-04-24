using System;

namespace App.System
{
    static class SolvingSystemInitializer
    {
        public static SolvingSystem Execute()
        {
            var startingPointInput = ReadInformationFromUser("Insert starting point value");
            var endingPointInput = ReadInformationFromUser("Insert ending point value");
            var stepInput = ReadInformationFromUser("Insert step value");

            if (!double.TryParse(startingPointInput, out var startingPoint))
                DisplayMessageAndExit("Entered value of Starting Point must be a floating-point number");

            if (!double.TryParse(endingPointInput, out var endingPoint))
                DisplayMessageAndExit("Entered value of Starting Point must be a floating-point number");

            if (!double.TryParse(stepInput, out var step) && step <= 0)
                DisplayMessageAndExit("Entered value of Starting Point must be a floating-point number and greater than zero");

            if (startingPoint > endingPoint)
                DisplayMessageAndExit("Entered value of Starting Point must be lesser than Ending Point");

            return new SolvingSystem(startingPoint, endingPoint, step);
        }

        private static string ReadInformationFromUser(string displayMessage)
        {
            Console.WriteLine(displayMessage);
            Console.Write("> ");
            return Console.ReadLine();
        }
        
        private static void DisplayMessageAndExit(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
            Environment.Exit(-1);
        }
    }
}
