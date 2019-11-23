using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"----------------------Task 1.11. AVERAGE STRING LENGTH----------------------{Environment.NewLine}");
            AverageStringLength();

            Console.WriteLine($"----------------------Task 1.12. CHAR DOUBLER----------------------{Environment.NewLine}");
            CharDoubler();

            Console.ReadKey();
        }

        static void AverageStringLength()
        {
            Console.WriteLine("Введите текстовую строку: " + Environment.NewLine);

            char[] text = (Console.ReadLine().Trim()).ToCharArray();

            int words = 1;
            int letters = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsLetterOrDigit(text[i]))
                {
                    letters += 1;
                }
                if (Char.IsSeparator(text[i]) || char.IsWhiteSpace(text[i]))
                {
                    words += 1;
                }
            }

            float average = (float)letters / words;

            Console.WriteLine($"{Environment.NewLine}Количество слов: {words}. Количество букв: {letters}. Средняя длина слова: {average}");

        }

        static void CharDoubler()
        {
            Console.WriteLine("Введите первую строку: ");
            StringBuilder string1 = new StringBuilder(Console.ReadLine().ToLower());

            Console.WriteLine($"{Environment.NewLine}Введите вторую строку: ");
            StringBuilder string2 = new StringBuilder(Console.ReadLine().ToLower());
            
            CharDoubler_DeleteDoubles(string2);

            CharDoubler_TransformString(string1, string2);

            Console.WriteLine($"{Environment.NewLine}Результирующая строка: {Environment.NewLine}{string1}");

        }

        static void CharDoubler_DeleteDoubles(StringBuilder currentString)
        {
            char[] secondStringToChars = currentString.ToString().ToArray();

            Array.Sort(secondStringToChars);

            currentString.Clear();

            for (int i = 0; i < secondStringToChars.Length - 1; i++)
            {
                if (!secondStringToChars[i].Equals(secondStringToChars[i + 1]))
                {
                    currentString.Append(secondStringToChars[i]);                   
                }
            }
            currentString.Append(secondStringToChars[secondStringToChars.Length - 1]);
        }
        static void CharDoubler_TransformString(StringBuilder transformableString, StringBuilder checkingString)
        {
           char[] checkingChars =  checkingString.ToString().ToArray();

            for (int i = 0; i < checkingChars.Length; i++)
            {
                    transformableString.Replace(checkingChars[i].ToString(), $"{checkingChars[i]}{checkingChars[i]}");
            }            
        }

    }
}
