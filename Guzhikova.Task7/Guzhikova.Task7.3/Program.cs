using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Guzhikova.Task7._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("************ TASK 7.3. EMAIL FINDER **********{0}", Environment.NewLine);
            Console.WriteLine("Please enter text:");

            string text = Console.ReadLine();

            Regex dateRegex = new Regex(@"\b([a-zA-Z0-9][a-zA-Z0-9.\-_]*[a-zA-Z0-9])@([a-zA-Z0-9][a-zA-Z0-9\-]*[a-zA-Z0-9].){1,}[a-zA-Z]{2,6}\b");

            var emails = dateRegex.Matches(text);

            Console.WriteLine($"{Environment.NewLine}The following correct email addresses were found:");

            foreach (var item in emails)
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadKey();
        }
    }
}
