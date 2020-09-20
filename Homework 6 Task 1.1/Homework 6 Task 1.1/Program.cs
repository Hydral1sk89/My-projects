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
        //Путь к файлу по умолчанию
        public static string path = @"D:\Numbers.txt"; 

        /// <summary>
        /// Метод записывает путь к файлу
        /// </summary>
        public static void InputPath()
        {
            Console.WriteLine("Введите путь к файлу:");
            Console.WriteLine("Пример: D:\\Numbers.txt");
            path = Console.ReadLine();
            path = $@"{path}";
            Console.Clear();
        }

        /// <summary>
        /// Метод принимает массив чисел, разбивает этот массив на группы строк в которых находятся только те числа которые не делятся друг на друга
        /// </summary>
        /// <param name="numbers">массив чисел</param>
        static public void Hakaton(int[] numbers)
        {
            //Переменные в которых будут храниться значения ОТ и ДО 
            int For = 0;
            int To = 0;

            //Переменная "от"
            For = numbers.Length - 1;
            //Переменная "до"
            To = For / 2 + 1;
            //Счётчик группы
            int CountGroup = 0;

            int[] array = new int[To];
            int index = 0;

            while (array.Length >= 1 && array[0] != 1)
            {
                CountGroup++;

                for (int i = For; i >= To; i--)
                {
                    if (index < array.Length)
                    {
                        array[index] = numbers[i];
                        index++;
                    }
                }

                //Сортируем массив
                Array.Sort(array);
                //Записываем массив в наш файл 
                StreamWrite(array, CountGroup);
                //проверка и выход из цикла
                if (array.Length == 1 && array[0] == 1) break;
                if(array.Length==1 && array[0] == 2)
                {
                    CountGroup++;
                    array[0] = 1;
                    StreamWrite(array, CountGroup);
                    break;
                }
                //Сбрасываем индекс 
                index = 0;
                //меняем переменную "от" 
                For = To-1;
                //меняем переменную "до" и устанавливаем необходимый размер массива
                if (For % 2 == 0)
                {
                    To = For / 2;
                    array = new int[To + 1];
                }
                else
                {
                    To = For / 2 + 1;
                    array = new int[To];
                } 
            }
        }

        /// <summary>
        /// Метод возвращает число M - количество групп разделённых чисел 
        /// </summary>
        public static int GetM()
        {
            int count = 0;

            using (StreamReader sr = new StreamReader(path, Encoding.Unicode))
            {
                string line;
                

                while((line = sr.ReadLine()) != null)
                {
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        /// Метод читает данные из файла и выводит их на экран консоли
        /// </summary>
        static public void StreamRead()
        {
            using (StreamReader sr = new StreamReader(path, Encoding.Unicode))
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
        /// Метод загружает из файла числа и возвращает эти числа в массиве
        /// </summary>
        /// <returns></returns>
        static public int[] StreamReadAndPushInArray()
        {
            int[] lastNumber = new int[11];

            char[] CharlastNumber;

            using (StreamReader sr = new StreamReader(path, Encoding.Unicode))
            {
                string line;
                string[] Aline;

                while((line = sr.ReadLine()) != null)
                {
                    //Aline = line.Split(' ');
                    int[] array = line.Split(' ').Select(int.Parse).ToArray();
                    lastNumber = array;
                    //Aline = line.Split().Select(int.Parse).ToArray();
                    //lastNumber = Aline.Select(int.Parse).ToArray();
                    //lastNumber = Array.ConvertAll(Aline, int.Parse);
                    //lastNumber = Array.ConvertAll(Aline, element => (Convert.ToInt32(element)));
                    //lastNumber = Array.ConvertAll(Aline, int.Parse);
                    //DisplayArray(lastNumber);
                }
            }
            return lastNumber;
        }

        /// <summary>
        /// метод принимает массив чисел и записывает этот массив в виде строки в файл 
        /// </summary>
        /// <param name="numbers">массив чисел</param>
        /// <param name="CountGroup">Счетчик группы</param>
        static public void StreamWrite(int[] numbers, int CountGroup)
        {
            int i = 0;           

            using (StreamWriter sw = new StreamWriter(path, true, Encoding.Unicode))
            {
                sw.Write($"Группа{CountGroup}: ");
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
            string text = File.ReadAllText(path);
            Console.WriteLine(text);
        }

        /// <summary>
        /// Метод определяет есть ли файл
        /// </summary>
        static public void ExistsFile()
        {
            File.Exists(path);
            if (File.Exists(path)) Console.WriteLine("Такой файл существует");
            else
                Console.WriteLine("Нет такого файла");
        }

        /// <summary>
        /// Метод удаляет файл
        /// </summary>
        static public void DeleteFile()
        {
            File.Delete(path);
        }

        static public void DisplayArray(int[] array)
        {
            for(int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }

        static void Main(string[] args)
        {
            //InputPath();
            //int[] n = new int[10];
            //StreamWrite(n,1);
            DisplayArray(StreamReadAndPushInArray());
            //DisplayArray(StreamReadAndPushInArray());
            //PushNumb(StreamReadAndPushInArray());
            //Hakaton(StreamReadAndPushInArray());
            //StreamRead();
        }
    }
}
