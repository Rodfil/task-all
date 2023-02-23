using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageNum
{
    public class AverageNumMethods
    {
        public void AverageNumInput()
        {
            while (true)
            {
                try
                {
                    double[] numInput = new double[3];

                    for (int i = 0; i < numInput.Length; i++)
                    {
                        Console.Write($"Enter input {i + 1}: ");
                        numInput[i] = Convert.ToDouble(Console.ReadLine());
                    }

                    double result = averageNum(numInput);

                    Console.WriteLine($"Average of ({numInput[0]}), ({numInput[1]}), ({numInput[2]}) is {result}");
                    Console.WriteLine("Press any key to go back to the main menu.");
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex} Invalid Input!");
                }
            }
        }

        public double averageNum(double[] numInput)
        {
            double res = 0;

            for (int i =0; i < numInput.Length;i++)
            {
                res += numInput[i]/3;
            }

            return res;
        }
    }
}
