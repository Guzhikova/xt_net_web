using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Guzhikova.Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime tempDate = default(DateTime);

            Console.WriteLine("************ TASK 7.1. DATE EXISTANCE **********{0}", Environment.NewLine);
            Console.WriteLine("The application for searching date format dd-mm-yyyy.{0}", Environment.NewLine);
            Console.WriteLine($"Please enter text:{Environment.NewLine}");

            string text = Console.ReadLine();

            Regex dateRegex = new Regex(@"\b(0?[1-9]|[1-2][0-9]|[3][0-1])-(0?[1-9]|[1][0-2])-[1-9]\d{3}\b");

            var date = dateRegex.Match(text);

            if (DateTime.TryParse(date.ToString(), out tempDate))
            {
                Console.WriteLine($"{Environment.NewLine}Text contains correct date.");
            }
            else
            {
                Console.WriteLine($"{Environment.NewLine}Text does not contain correct date.");
            }

            Console.ReadKey();
        }
}
}
