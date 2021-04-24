using System;
using System.Collections.Generic;
using System.Text;

namespace App.Display
{
    static class ConsoleDisplayer
    {
        public static void DisplayWelcomeMessage()
        {
            Console.WriteLine("*****************************");
            Console.WriteLine("*         CREADED BY        *");
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

        public static void DisplayFarewellMessage()
        {
            Console.WriteLine("The calculations were correctly saved in the indicated location! Press any key to exit...");
            Console.ReadKey();
        }
    }
}
