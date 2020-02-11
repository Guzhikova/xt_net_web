using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------------------Task 1.1. RECTANGLE----------------------");
            RectangleArea();

            Console.WriteLine("\n----------------------Task 1.2. TRIANGLE----------------------");
            DrawRightAngledTriangle();

            Console.WriteLine("\n----------------------Task 1.3. ANOTHER TRIANGLE----------------------");
            Console.Write("Введите число: ");
            DrawIsoscelesTriangle(ReadNumberFromConsole());

            Console.WriteLine("\n----------------------Task 1.4. X-MAS TREE----------------------");
            DrawTree();

            Console.WriteLine("\n----------------------Task 1.5. SUM OF NUMBERS----------------------");
            SumOfNumbers();

            Console.WriteLine("\n----------------------Task 1.6. FONT ADJUSTMENT----------------------");
            FontAdjustment();

            Console.ReadKey();
        }

        static int ReadNumberFromConsole()
        {
            int number;
            string enteredString = Console.ReadLine();

            while (!(Int32.TryParse(enteredString, out number) && number > 0))
            {
                if (enteredString.Equals("0") || number < 0)
                {
                    Console.WriteLine("Ошибка! Число должно быть больше нуля!");
                }
                enteredString = Console.ReadLine();
            }

            return number;
        }

        static void RectangleArea()
        {
            Console.Write("Введите сторону а: ");
            int a = ReadNumberFromConsole();

            Console.Write("Введите сторону b: ");
            int b = ReadNumberFromConsole();

            Console.WriteLine("Площадь прямоугольника со сторонами {0} и {1} равна {2}", a, b, a * b);

        }

        static void DrawRightAngledTriangle()
        {
            Console.Write("Введите число:");

            int number = ReadNumberFromConsole();

            StringBuilder stars = new StringBuilder(number);

            for (int i = 0; i < number; i++)
            {
                Console.WriteLine(stars.Append("*"));
            }
        }


        /// <param name="height">The height of triangle is equal to the number of lines</param>
        /// <param name="shift">The left margin</param>
        static void DrawIsoscelesTriangle(int height, int shift = 0)
        {

            StringBuilder stars = new StringBuilder(shift + (height * 2 - 1));
            stars.Append(' ', shift + (height * 2 - 1));

            for (int index = (height - 1); index >= 0; index--)
            {
                stars.Insert(shift + index, "*", (index == height - 1) ? 1 : 2);

                Console.WriteLine(stars.ToString());

                if (index > 0)
                {
                    stars.Remove(index + shift - 1, 1);
                }
            }
        }

        static void DrawTree()
        {
            Console.Write("Введите число: ");
            int numberOfTriangles = ReadNumberFromConsole();

            for (int height = 1; height <= numberOfTriangles; height++)
            {
                DrawIsoscelesTriangle(height, numberOfTriangles - height);
            }

        }

        static void SumOfNumbers()
        {
            int counter = 0;

            for (int number = 1; number < 1000; number++)
            {
                if (number % 3 == 0 || number % 5 == 0)
                {
                    counter += number;
                }
            }
            Console.WriteLine(Environment.NewLine + $"Сумма всех чисел меньше 1000, кратных 3 или 5 равна: {counter}");
        }

        static void FontAdjustment()
        {
            FontStyles fontStyle = FontStyles.None;
  
            Console.WriteLine(Environment.NewLine + $"Текущие параметры надписи: {fontStyle.ToString()}");

            FontAdjustment_Display();

            FontAdjustment_AddRemoveSelectedStyle(fontStyle);        
        }
        
        static void FontAdjustment_Display()
        {
            Console.WriteLine(Environment.NewLine + "Введите номер начертания, для его применения/отмены:");
            Console.WriteLine($"   1: {FontStyles.Bold.ToString()}");
            Console.WriteLine($"   2: {FontStyles.Italic.ToString()}");
            Console.WriteLine($"   3: {FontStyles.Underline.ToString()}");
            Console.WriteLine("Для завершения форматирования введите 4." + Environment.NewLine);
        }
     
        static void FontAdjustment_AddRemoveSelectedStyle(FontStyles fontStyle)
        {
            FontStyles tempFontStyle = FontAdjustment_ReadSelectedStyle();

            while (tempFontStyle != FontStyles.None)
            {
                fontStyle = fontStyle.HasFlag(tempFontStyle) ? (fontStyle ^ tempFontStyle) : (fontStyle | tempFontStyle);

                Console.WriteLine(Environment.NewLine + $"Текущие параметры надписи: {fontStyle.ToString()}");
                FontAdjustment_Display();

                tempFontStyle = FontAdjustment_ReadSelectedStyle();
            }
        }

        static FontStyles FontAdjustment_ReadSelectedStyle()
        {
            FontStyles fontStyle;
            int numberOfStyle = ReadNumberFromConsole();

            while (numberOfStyle > 4)
            {
                Console.WriteLine("Значение вне диапозона!");
                numberOfStyle = ReadNumberFromConsole();
            }

            switch (numberOfStyle)
            {
                case 1:
                    fontStyle = FontStyles.Bold;
                    break;
                case 2:
                    fontStyle = FontStyles.Italic;
                    break;
                case 3:
                    fontStyle = FontStyles.Underline;
                    break;

                // This means that the user has completed font adjustment
                default:
                    fontStyle = FontStyles.None;
                    Console.WriteLine("Завершено!");
                    break;
            }
            return fontStyle;
        }


        [Flags]
        public enum FontStyles
        {
            None = 0,
            Bold = 1,
            Italic = 2,
            Underline = 4
        }
    }

}

