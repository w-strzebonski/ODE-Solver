using System;
using System.Collections.Generic;
using System.Text;

namespace App.Factories
{
    class OdeSystemFactoryGenerator
    {
        public static IOdeSystemFactory Generate()
        {
            DisplayChooseDiffEquationMessage();

            var input = Console.ReadLine();
            if (!int.TryParse(input, out var inputAsNumber) || inputAsNumber > 3 || inputAsNumber < 1)
                DisplayErrorMessageAndExit("Entered input must be a number between 1 and 3!");

            switch (inputAsNumber)
            {
                case 1:
                    return new FirstOrderOdeFactory();
                case 2:
                    return new FirstOrderOdeFactory(); //to change!
                case 3:
                    return new FourthOrderOdeFactory();
            }

            return null;
        }

        private static void DisplayChooseDiffEquationMessage()
        {
            Console.WriteLine("Choose the differential equation to solve, type number and press ENTER:");
            Console.WriteLine("1. dy/xd = 2 * y * x");
            Console.WriteLine("2. NOT IMPLEMENTED");
            Console.WriteLine("3. d^4y/dx^4 = y^2(x) - x^10 + 4x^9 - 4x^8 - 4x^7 + 8x^6 -4x^4 + 120x - 48");
            Console.Write("> ");
        }

        private static void DisplayErrorMessageAndExit(string message)
        {
            Console.WriteLine(message);
            Environment.Exit(-1);
        }
    }
}
