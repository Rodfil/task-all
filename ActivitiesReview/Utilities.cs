using AverageNum;
using FoxPanda;
using OddEven;
using ManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ActivitiesReview
{
    internal class Utilities
    {
        private static AverageNumMethods Average = new AverageNumMethods();
        private static OddEvenMethods Odd_Even = new OddEvenMethods();
        private static FoxPandaMethods FoxPanda = new FoxPandaMethods();
        private static ManagementSystemMethods ManagementSystem = new ManagementSystemMethods();
        public  void DisplayMenu()
        {
            string? decision;
            
            
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Select the Application that you want to open.");
                Console.Write("1. Average Three Numbers\n2. Even or Odd\n3. Fox Panda\n4. Management System\n5. Exit Application\nChoice (1-5): ");
                Console.ForegroundColor = ConsoleColor.Red;
                decision = Console.ReadLine();
                Console.ResetColor();

                switch (decision)
                {
                    case "1":
                        Console.Clear();
                        Average.AverageNumInput();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "2":
                        Console.Clear();
                        Odd_Even.OddEvenInput();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "3":
                        Console.Clear();
                        FoxPanda.FoxPandaInput();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "4":
                        Console.Clear();
                        ManagementSystem.DisplayMenu();
                        Console.Clear();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Invalid Input!");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }while (decision != "5");
        }
    }
}
