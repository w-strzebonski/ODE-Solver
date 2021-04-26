using System;

namespace App.Display
{
    static class ConsoleDisplayer
    {
        public static void DisplayWelcomeMessage()
        {
            Console.WriteLine("*****************************");
            Console.WriteLine("*         CREATED BY        *");
            Console.WriteLine("* WOJCIECH STRZEBOŃSKI 2021 *");
            Console.WriteLine("*****************************");
            Console.WriteLine();
            Console.WriteLine("That program was created to solve differential equations");
            Console.WriteLine("and compare the obtained solution with the exact solution");
            Console.WriteLine("and save results to CSV file.");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
