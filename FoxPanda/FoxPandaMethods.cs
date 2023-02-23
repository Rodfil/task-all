using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxPanda
{
    public class FoxPandaMethods
    {
        public void FoxPandaInput()
        {
            
            while (true)
            {
                try
                {
                    int[] numInput = new int[2];

                    for (int i = 0; i < numInput.Length; i++)
                    {
                        Console.WriteLine($"Enter num ({i + 1}): ");
                        numInput[i] = Convert.ToInt32(Console.ReadLine());
                    }
                    
                    bool checkNumbers = checkInput(numInput);
                    if (checkNumbers)
                    {
                        ShowFoxPanda(numInput);
                    }
                    else
                    {
                        throw new Exception("First input must be lesser than second input!");
                    }
                    Console.WriteLine("Enter any key to go back to the main menu.");
                    break;
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"{ex} Invalid Input!");
                }
            }
        }


        public bool checkInput(int[] numInput) 
        {
            if (numInput[0] <= numInput[1])
                return true;
            else
                return false;
        }

        public void ShowFoxPanda(int[] numInput)
        {
            List <string> list = new List <string>();
            for (int i = numInput[0]; i <= numInput[1];i++)
            {
                Console.ForegroundColor= ConsoleColor.DarkYellow; 
                if (i % 5 == 0 && i % 2 == 0)
                {
                    Console.Write("(Fox Panda) ");
                    list.Add("(Fox Panda)");
                }
                else if (i % 2 == 0)
                {
                    Console.Write("(Fox) ");
                    list.Add("(Fox)");
                }
                else if (i % 5 == 0)
                {
                    Console.Write("(Panda) ");
                    list.Add("(Panda)");
                }
                else
                {
                    Console.Write($"{i} ");
                }
            }

            Console.WriteLine();

            foreach (string displayList in list)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"{displayList} ");

            }

            Console.ReadLine();
        }
    }
}
