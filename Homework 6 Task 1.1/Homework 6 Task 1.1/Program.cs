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
        static public void StreamRead()
        {
            using (StreamReader sr = new StreamReader("Numbers.txt", Encoding.Unicode))
            {
                string line;
   
                while ((line = sr.ReadLine()) != null)
                {
                    string[] data = line.Split(' ');

                    Console.Write($"{data[0]} ");                  
                }
            }
            Console.WriteLine();
        }


        static public void StreamWrite(int numbers)
        {
            using (StreamWriter sw = new StreamWriter("Numbers.txt", true, Encoding.Unicode))
            {
                int i = 0;

                while (i < numbers)
                {
                    string note = string.Empty;
                    i++;
                    note += i;
                    sw.WriteLine(note);
                }
            }
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
            StreamWrite(10);
            StreamRead();
            DeleteFile();
        }
    }
}
