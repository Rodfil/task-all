using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddEven
{
    public class OddEvenMethods
    {
        public void OddEvenInput()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter a number: ");
                    int num = Convert.ToInt32(Console.ReadLine());

                    bool checkNum = (checkNumber.IsEvenNumber(num));

                    if (checkNum)
                    {
                        Console.WriteLine($"{num} is EVEN!");
                    }
                    else
                    {
                        Console.WriteLine($"{num} is ODD!");
                    }

                    Console.WriteLine("Returning you back to the main menu!");
                    Console.WriteLine("Enter any key to go back to the main menu.");
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

            }
        }

        static class checkNumber
        {
            public static bool IsEvenNumber(int num)
            {
                if (num % 2 == 0)
                    return true;
                else
                    return false;
            }
        }
    }
}
