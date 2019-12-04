using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<People> people = new List<People>(); List<People> people2 = new List<People>();

            for (int i = 0; i < 11; i++)
            {
                
                people.Add(new People(i+1));
                Console.WriteLine(people.ElementAt(i).NumberOfPerson);
            }

            MyListEnumeration<People> peopleEnumeration = new MyListEnumeration<People>(people);
            try
            {

                foreach (var item in peopleEnumeration)
                {

                    Console.WriteLine("--" + item.NumberOfPerson.ToString());
                    

                    people.Remove(item);


                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            foreach (var item in people)
            {
  Console.WriteLine(item.NumberOfPerson +"**************");
            }
            Console.WriteLine(people.Count + " count");

            Console.ReadKey();

        }

    }
}
