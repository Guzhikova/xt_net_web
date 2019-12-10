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

            Console.WriteLine($"{Environment.NewLine}----------------------Task 3.2.	WORD FREQUENCY----------------------{Environment.NewLine}");
            WordFrequency();

            Console.ReadKey();

        }


        #region Functions for Task 3.1. LOST

        public static void ExcludePeople()
        {
            List<Person> people = new List<Person>();

            CreateCircleOfPeople(people);

            Exclude(people);

            foreach (var item in people)
            {
                Console.WriteLine("{0}Остался {1} человек под номером {2}",
                    Environment.NewLine, people.Count, item.NumberOfPerson);
            }
        }

        public static void CreateCircleOfPeople(List<Person> peopleList)
        {
            Console.WriteLine("Сколько человек поставить в круг?");

            int count = ForConsole.ReadPositiveNumberWithoutZero();

            Console.WriteLine("{0}В круге {1} человек с порядковыми номерами: ",
                Environment.NewLine, count);

            for (int i = 0; i < count; i++)
            {
                peopleList.Add(new Person(i + 1));

                Console.Write($" {peopleList.ElementAt(i).NumberOfPerson} ");
            }
            Console.WriteLine($"{Environment.NewLine}");
        }

        public static void Exclude(List<Person> peopleList)
        {
            People<Person> people = new People<Person>(peopleList);
            try
            {
                foreach (var item in people)
                {
                    Console.WriteLine($"- Исключен человек под номером {item.NumberOfPerson.ToString()}");

                    peopleList.Remove(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion  

        #region Functions for Task 3.2. WORD FREQUENCY

        public static void WordFrequency()
        {
            Dictionary<string, int> wordsFrequency = new Dictionary<string, int>();

            Console.WriteLine($"Введите текст:{Environment.NewLine}");
            string text = Console.ReadLine().ToLower();            

            TextToDictionary(text, wordsFrequency);

            Console.WriteLine($"{Environment.NewLine}Проанализирована частота встречаемости каждого слова в тексте:");

            ShowSortedDictionary(wordsFrequency);
        }

        public static void TextToDictionary(string text, Dictionary<string, int> wordsFrequency)
        {
            string[] words = text.Split(new Char[] { ' ', ',', '.', ':', '?', '\t' });

            int counter = 0;

            foreach (var item in words)
            {
                string word = item.Trim();

                if (word != "")
                {
                    try
                    {
                        wordsFrequency.Add(word, 1);
                    }
                    catch (ArgumentException)
                    {
                        wordsFrequency.TryGetValue(word, out counter);
                        wordsFrequency[word] = counter + 1;

                    }
                }
            }
        }

        public static void ShowSortedDictionary(Dictionary<string, int> wordsFrequency)
        {
            Console.WriteLine($"* cлово = встречаемость{Environment.NewLine}");

            foreach (var item in wordsFrequency.OrderByDescending(item => item.Value))
            {
                Console.WriteLine($"{item.Key} = {item.Value}");
            }
        }

        #endregion
    }


}
