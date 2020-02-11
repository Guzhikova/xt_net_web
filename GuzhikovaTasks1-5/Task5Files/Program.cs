using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Files
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------- Добро пожаловать в BACKUP SYSTEM! ---------------{0}", Environment.NewLine);

            ModeControls mode = new ModeControls();
            mode.ChoosingMode();

            Console.ReadKey();
        }


    }
}
