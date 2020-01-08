using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Guzhikova.Task7._5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("************ TASK 7.5. TIME COUNTER **********{0}", Environment.NewLine);
            Console.WriteLine("Please enter text:", Environment.NewLine);

            string text = Console.ReadLine();
            int counter = 0;

            Regex timeRegex = new Regex(@"\b((([0-1]?\d)|(2[0-3])):([0-5]\d))|(24:00)\b");

            var times = timeRegex.Matches(text);            

            foreach (var item in times)
            {
                counter++;
            }

            Console.WriteLine($"{Environment.NewLine}This text contains {counter} references to time.");

            Console.ReadKey();
        }
    }
}
