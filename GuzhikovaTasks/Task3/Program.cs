using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functions;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"----------------------Task 3.1. LOST----------------------{Environment.NewLine}");
            ExcludePeople();

            Console.ReadKey();

        }
        public static void ExcludePeople()
        {

            List<Person> peopleList = new List<Person>();

            CreateCircleOfPeople(peopleList);

            Exclude(peopleList);

            foreach (var item in peopleList)
            {
                Console.WriteLine("{0}Остался {1} человек под номером {2}",
                    Environment.NewLine, peopleList.Count, item.NumberOfPerson);

            }
        }

        public static void CreateCircleOfPeople(List<Person> people)
        {
            Console.WriteLine("Сколько человек поставить в круг?");

            int count = ForConsole.ReadPositiveNumberWithoutZero();

            Console.WriteLine("{0}{0}В круге {1} человек с порядковыми номерами: ",
                Environment.NewLine, count);

            for (int i = 0; i < count; i++)
            {

                people.Add(new Person(i + 1));

                Console.Write($" {people.ElementAt(i).NumberOfPerson} ");
            }
            Console.WriteLine($"{Environment.NewLine}");
        }
        public static void Exclude(List<Person> people)
        {
            PeopleEnumeration<Person> peopleEnumeration = new PeopleEnumeration<Person>(people);
            try
            {
                foreach (var item in peopleEnumeration)
                {
                    Console.WriteLine($"- Исключен человек под номером {item.NumberOfPerson.ToString()}");

                    people.Remove(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }


}
