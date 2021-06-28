using System;

namespace App.Factory
{
    public static class OdeSystemFactoryGenerator
    {
        public static IOdeSystemFactory Generate()
        {
            DisplayChooseDiffEquationMessage();
            var input = Console.ReadLine();
            Console.WriteLine();

            if (!int.TryParse(input, out var inputAsNumber) || inputAsNumber > 3 || inputAsNumber < 1)
                DisplayErrorMessageAndExit("Entered input must be a number between 1 and 3!");

            return inputAsNumber switch
            {
                1 => new FirstOrderOdeFactory(),
                2 => new SecondOrderOdeFactory(),
                3 => new FourthOrderOdeFactory(),
                _ => null
            };
        }

        private static void DisplayChooseDiffEquationMessage()
        {
            Console.WriteLine("Choose the differential equation to solve, type number and press ENTER:");
            Console.WriteLine("1. dy/xd = 2 * y * x");
            Console.WriteLine("2. d^2y/dx^2 = sin(x) - 2dy/dx - 3y");
            Console.WriteLine("3. d^4y/dx^4 = y^2(x) - x^10 + 4x^9 - 4x^8 - 4x^7 + 8x^6 -4x^4 + 120x - 48");
            Console.Write("> ");
        }

        private static void DisplayErrorMessageAndExit(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
            Environment.Exit(-1);
        }
    }
}
