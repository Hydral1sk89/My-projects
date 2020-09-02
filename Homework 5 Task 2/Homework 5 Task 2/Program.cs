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

        /// <summary>
        /// Метод выводит на консоль самое длинное и самое короткое слово в тексте
        /// </summary>
        /// <param name="text">текст на проверку</param>
        /// <returns></returns>
        public static string LongShortText(string text)
        {
            char[] cha = { ' ', '.', ',' };
            string[] strArray = text.Split(cha, StringSplitOptions.RemoveEmptyEntries);

            string minStr = strArray[0];
            string maxStr = strArray[0];
            int StrLength;

            for (int i = 0; i < strArray.Length; i++)
            {
                if (minStr.Length > strArray[i].Length && strArray[i] != "") minStr = strArray[i];
                if (maxStr.Length < strArray[i].Length) maxStr = strArray[i];
            }

            StrLength = maxStr.Length;

            for (int k = 0; k < strArray.Length; k++)
            {
                if (StrLength == strArray[k].Length && maxStr != strArray[k])
                {
                    maxStr += " " + strArray[k];
                }
            }

            Console.WriteLine($"Слово с максимальным количеством букв: {maxStr}");
            Console.WriteLine($"Слово с минимальным количеством букв: {minStr}");

            return "";
        }

        static void Main(string[] args)
        {
            LongShortText("         Я пошёл гулять на хакатониндзеджимханувпермь      ");

            LongShortText("A 22 333 4444 55555 77777 88888 33333                            1111100000 CCCCCCCCCCCCCCCCCCCCCCC");
        }
    }
}
