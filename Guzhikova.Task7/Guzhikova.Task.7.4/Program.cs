using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Guzhikova.Task7._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("************ TASK 7.4. NUMBER VALIDATOR **********{0}", Environment.NewLine);

            Console.WriteLine("Enter 'q' to exit{0}_____", Environment.NewLine);

            DetermineNumbersNotation();

            Console.ReadKey();
        }

        private static void DetermineNumbersNotation()
        {
            string number = "";

            Regex normalRegex = new Regex(@"^[-+]?\d+[,.]?\d*$");
            Regex scientificRegex = new Regex(@"^([-+]?\d+[,.]?\d*)(([×*]10[+-]?\d+)|([eE][-+]?\d+))$");

            do
            {
                Console.Write($"{Environment.NewLine}Please enter number: ");

                number = Console.ReadLine();

                if (normalRegex.IsMatch(number))
                {
                    Console.WriteLine($"This is the NORMAL notation for number.{Environment.NewLine}");
                }
                else if (scientificRegex.IsMatch(number))
                {
                    Console.WriteLine($"This is the SCIENTIFIC notation for number.{Environment.NewLine}");
                }
                else if (number.ToLower() != "q")
                {
                    Console.WriteLine($"It is not a number!{Environment.NewLine}");
                }

            } while (number.ToLower() != "q");
        }
    }
}
