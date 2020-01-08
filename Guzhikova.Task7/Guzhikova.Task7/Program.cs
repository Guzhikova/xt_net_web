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

            Console.WriteLine("Task 7.1. The application for searching date format dd-mm-yyyy", Environment.NewLine);
            Console.WriteLine("Please enter text: ");

            string text = Console.ReadLine();

            Regex dateRegex = new Regex(@"\b(0?[1-9]|[1-2][0-9]|[3][0-1])-(0?[1-9]|[1][0-2])-[1-9]\d{3}\b");

            var dates = dateRegex.Matches(text);

            Console.WriteLine($"{Environment.NewLine}The following correct dates were found:");

            foreach (var date in dates)
            {
                if (DateTime.TryParse(date.ToString(), out tempDate))
                {
                    Console.WriteLine(date.ToString());
                }
            }
            
            Console.ReadKey();
        }
    }
}
