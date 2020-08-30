using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_5_Task_2
{
    class Program
    {
        // Задание 2.
        // 1. Создать метод, принимающий  текст и возвращающий слово, содержащее минимальное количество букв
        // 2.* Создать метод, принимающий  текст и возвращающий слово(слова) с максимальным количеством букв
        // Примечание: слова в тексте могут быть разделены символами (пробелом, точкой, запятой)
        // Пример: Текст: "A ББ ВВВ ГГГГ ДДДД  ДД ЕЕ ЖЖ ЗЗЗ"
        // 1. Ответ: А
        // 2. ГГГГ, ДДДД

        #region Task2
        /// <summary>
        /// Метод выводит на консоль самое длинное и самое короткое слово в тексте
        /// </summary>
        /// <param name="text">текст на проверку</param>
        /// <returns></returns>
        public static string LongShortText(string text)
        {
            StringBuilder sb = new StringBuilder();

            int min = 0;
            int max = 0;
            int difference = 0;
            int counter = 0;

            string[] strArray = new string[text.Length];


            for (int i = 0; i < text.Length; i++)
            {
                if (i == 0) min = i;
                //if (i == text.Length - 1) max = i;                    
                if (text[i] == ' ' || text[i] == '.' || text[i] == ',' || i == text.Length - 1)
                {
                    max = i;
                    if (i == text.Length - 1) max = i + 1;
                    difference = max - min;
                    char[] word = new char[difference];

                    for (int k = 0; k < difference; k++)
                    {
                        word[k] = text[min];
                        min++;
                    }

                    foreach (char ch in word)
                        sb.Append(ch);
                    strArray[counter] = sb.ToString();
                    counter++;
                    min = max + 1;
                    sb.Clear();
                }
            }

            string minStr = strArray[0];
            string maxStr = strArray[0];
            int StrLength;

            for (int i = 0; i < text.Length; i++)
            {
                if (strArray[i] == null) break;
                if (minStr.Length > strArray[i].Length && strArray[i] != "") minStr = strArray[i];
                if (maxStr.Length < strArray[i].Length) maxStr = strArray[i];
            }

            StrLength = maxStr.Length;

            for (int k = 0; k < text.Length; k++)
            {
                if (strArray[k] == null) break;
                if (StrLength == strArray[k].Length && maxStr != strArray[k])
                {
                    maxStr += " " + strArray[k];
                }
            }

            Console.WriteLine($"Слово с максимальным количеством букв: {maxStr}");
            Console.WriteLine($"Слово с минимальным количеством букв: {minStr}");

            return "";
        }
        #endregion

        static void Main(string[] args)
        {
            //пробелы space
            LongShortText("1 22 333 4444 55555 77777 88888 33333                         1111100000 CCCCC");

            //табуляция tab
            LongShortText("A 22 333 4444 55555 77777 88888 33333                            1111100000 CCCCCCCCCCCCCCCCCCCCCCC");
        }
    }
}
