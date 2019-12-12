using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Handler
    {
        public void Message(string type)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0} **** Сортировка массива {1} окончена! *****{0}", Environment.NewLine, type);
            Console.ResetColor();
        }
    }
}
