using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Entities;
using UsersAndAwards.Ioc;


namespace Guzhikova.Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            var logic = DependencyResolver.UserLogic;

            var current = logic.Add(new User()
            {
                Name = "Egorov Aleksey",
            });

            foreach (var item in logic.GetAll())
            {
                Console.WriteLine(item.Name);
            }

            Console.ReadKey();
        }
    }
}
