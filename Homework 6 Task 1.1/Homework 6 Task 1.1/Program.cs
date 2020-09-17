using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Homework_6_Task_1._1
{
    class Program
    {
        static public void Hakaton(int[] numbers)
        {
            //Переменные в которых будут храниться значения ОТ и ДО 
            int For = 0;
            int To = 0;

            //Переменная "от"
            For = numbers.Length - 1;
            //Переменная "до"
            To = For / 2 + 1;

            int[] array = new int[To];
            int index = 0;

            while (For != 0)
            {
                for (int i = For; i >= To; i--)
                {
                    array[index] = numbers[i];
                    index++;
                }

                //Сортируем массив
                Array.Sort(array);
                //Записываем массив в наш файл 
                StreamWrite(array);
                //Сбрасываем индекс 
                index = 0;
                //меняем переменную "от"
                For = To - 1;
                //меняем переменную "до"
                To = For / 2;
                //Меняем массив на подходящий размер
                array = new int[To+1];
            }
        }


        /// <summary>
        /// Метод читает данные из файла и выводит их на экран консоли
        /// </summary>
        static public void StreamRead()
        {
            using (StreamReader sr = new StreamReader("Numbers.txt", Encoding.Unicode))
            {
                string line;
   
                while ((line = sr.ReadLine()) != null)
                {
                    Console.Write($"{line} \n");
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// метод принимает массив чисел и записывает этот массив в виде строки в файл 
        /// </summary>
        /// <param name="numbers">массив чисел</param>
        static public void StreamWrite(int[] numbers)
        {
            int i = 0;

            using (StreamWriter sw = new StreamWriter("Numbers.txt", true, Encoding.Unicode))
            {
                while (i < numbers.Length)
                {
                    string note = string.Empty;
                    note += Convert.ToString(numbers[i]);
                    sw.Write(note+" ");
                    i++;
                }
                sw.WriteLine();
            }
        }

        /// <summary>
        /// вставляет в массив значения от 1 и далее
        /// </summary>
        /// <param name="numbers">массив</param>
        /// <returns></returns>
        static public int[] PushNumb(int[] numbers)
        {
            int count = 1;

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = count++;
            }

            return numbers;
        }

        /// <summary>
        /// Метод выводит на экран весь текст из файла
        /// </summary>
        static public void DisplayAll()
        {
            string text = File.ReadAllText(@"Numbers.txt");
            Console.WriteLine(text);
        }

        /// <summary>
        /// Метод определяет есть ли файл
        /// </summary>
        static public void ExistsFile()
        {
            File.Exists(@"Numbers.txt");
            if (File.Exists(@"Numbers.txt")) Console.WriteLine("Такой файл существует");
            else
                Console.WriteLine("Нет такого файла");
        }

        /// <summary>
        /// Метод удаляет файл
        /// </summary>
        static public void DeleteFile()
        {
            File.Delete(@"Numbers.txt");
        }

        static void Main(string[] args)
        {
            int[] n = new int[10];

            PushNumb(n);
            Hakaton(n);
            //StreamWrite(n);
            StreamRead();
            DeleteFile();
            
        }
    }
}
