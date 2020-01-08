using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Guzhikova.Task7._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("************ TASK 7.2. HTML REPLACER **********{0}", Environment.NewLine);
            Console.WriteLine("Please enter text:");

            string text = Console.ReadLine();

            string pattern = @"\</?[^\>]+\>";

            text = Regex.Replace(text, pattern, "_");

            Console.WriteLine("{0}Replaced text:{0}{1}", Environment.NewLine, text);

            Console.ReadKey();
        }
    }
}
