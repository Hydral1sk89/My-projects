using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace Homework_6_Task_1._1
{
    class Program
    {
        //Путь к файлу по умолчанию
        public static string path = @"D:\Numbers.txt";
        public static string destinationPath = @"D:\Numbers2.txt";

        /// <summary>
        /// Метод записывает путь к файлу
        /// </summary>
        public static void InputPath()
        {
            Console.WriteLine("Введите путь к файлу:");
            Console.WriteLine("Пример: D:\\Numbers.txt");
            path = Console.ReadLine();
            path = $@"{path}";
            Console.WriteLine("Куда сохранить результат?");
            destinationPath = Console.ReadLine();
            destinationPath = $@"{destinationPath}";
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
                if (array.Length == 1 && array[0] == 2)
                {
                    CountGroup++;
                    array[0] = 1;
                    StreamWrite(array, CountGroup);
                    break;
                }
                //Сбрасываем индекс 
                index = 0;
                //меняем переменную "от" 
                For = To - 1;
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

            using (StreamReader sr = new StreamReader(destinationPath, Encoding.Unicode))
            {
                string line;


                while ((line = sr.ReadLine()) != null)
                {
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        /// Метод принимает массив с цифрами и возвращает количество групп
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int GetM(int[] array)
        {
            int group = 0;
            int d = array.Length;

            while (d != 1)
            {
                d = d / 2;
                if (d != 1)d = d + 1;
                group++;
            }

            return group;
        }

        /// <summary>
        /// Метод читает данные из файла и выводит их на экран консоли
        /// </summary>
        static public void DisplayFile()
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
            int[] lastNumber = new int[1];

            using (StreamReader sr = new StreamReader(path, Encoding.Unicode))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    int[] array = line.Split(' ').Select(int.Parse).ToArray();
                    lastNumber = array;
                }
            }
            return lastNumber;
        }

        /// <summary>
        /// Метод читает файл и возвращает массив с цифрами из файла
        /// </summary>
        /// <returns></returns>
        static public int[] ReadFile(string path)
        {
            int[] array;
            string[] arrayS;
            string file;

            file = File.ReadAllText(path);
            arrayS = file.Split(' ');

            array = Array.ConvertAll(arrayS, int.Parse);

            return array;
        }

        /// <summary>
        /// метод принимает массив чисел и записывает этот массив в виде строки в файл 
        /// </summary>
        /// <param name="numbers">массив чисел</param>
        /// <param name="CountGroup">Счетчик группы</param>
        static public void StreamWrite(int[] numbers, int CountGroup)
        {
            int i = 0;

            using (StreamWriter sw = new StreamWriter(destinationPath, true, Encoding.Unicode))
            {
                sw.Write($"Группа{CountGroup}: ");
                while (i < numbers.Length)
                {
                    string note = string.Empty;
                    note += Convert.ToString(numbers[i]);
                    sw.Write(note + " ");
                    i++;
                }
                sw.WriteLine();
            }
        }

        /// <summary>
        /// метод принимает массив чисел и записывает этот массив в виде строки в файл
        /// </summary>
        /// <param name="numbers">массив чисел</param>
        static public void StreamWrite(int[] numbers)
        {
            int i = 0;

            using (StreamWriter sw = new StreamWriter(destinationPath, true, Encoding.Unicode))
            {
                while (i < numbers.Length)
                {
                    string note = string.Empty;
                    note += Convert.ToString(numbers[i]);
                    sw.Write(note);
                    if (i != numbers.Length - 1) sw.Write(" ");
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
        /// Метод создает массив указанного размера
        /// </summary>
        /// <param name="length">длина массива</param>
        /// <returns></returns>
        static public int[] CreateArray(int length)
        {
            int[] array = new int[length];

            return array;
        }

        /// <summary>
        /// Метод выводит на экран весь текст из файла
        /// </summary>
        static public void DisplayAll(string path)
        {
            string text = File.ReadAllText(path);
            Console.WriteLine(text);
        }

        /// <summary>
        /// Метод определяет есть ли файл
        /// </summary>
        static public void ExistsFile(string path)
        {
            File.Exists(path);
            if (File.Exists(path)) Console.WriteLine("Такой файл существует");
            else
                Console.WriteLine("Нет такого файла");
        }

        /// <summary>
        /// Метод удаляет файл
        /// </summary>
        static public void DeleteFile(string path)
        {
            File.Delete(path);
        }

        /// <summary>
        /// Метод перемещает файл
        /// </summary>
        /// <param name="path">путь к файлу</param>
        /// <param name="newPath">новый путь к файлу</param>
        static public void MoveFile(string path, string newPath)
        {
            File.Move($@"{path}", $@"{newPath}");
        }

        /// <summary>
        /// Метод копирует файл
        /// </summary>
        /// <param name="path">путь к файлу</param>
        /// <param name="newPath">путь куда будет скопирован файл</param>
        static public void CopyFile(string path, string newPath)
        {
            File.Copy($@"{path}", $@"{newPath}");
        }

        /// <summary>
        /// Метод выводит массив на экран
        /// </summary>
        /// <param name="array"></param>
        static public void DisplayArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }

        /// <summary>
        /// Метож архивирует файл
        /// </summary>
        /// <param name="path">путь к файлу который необходимо заархивировать</param>
        /// <param name="destPath">путь куда необходимо сохранить заархивированный файл</param>
        static public void CompressFile(string path, string destPath)
        {
            using (FileStream ss = new FileStream(path, FileMode.OpenOrCreate))
            {
                using (FileStream ts = File.Create(destPath))   // поток для записи сжатого файла
                {
                    // поток архивации
                    using (GZipStream cs = new GZipStream(ts, CompressionMode.Compress))
                    {
                        ss.CopyTo(cs); // копируем байты из одного потока в другой
                        Console.WriteLine("Сжатие файла {0} завершено. Было: {1}  стало: {2}.",
                                          path,
                                          ss.Length,
                                          ts.Length);
                    }
                }
            }
        }

        /// <summary>
        /// Метод разархивирует сжатый файл
        /// </summary>
        /// <param name="path">путь к заархивированному файлу</param>
        /// <param name="destPath">путь куда сохранить разархивированный файл</param>
        static public void DecompressFile(string path, string destPath)
        {
            using (FileStream ss = new FileStream(path, FileMode.OpenOrCreate))  // поток для чтения из сжатого файла
            {

                using (FileStream ts = File.Create($"{destPath}_.txt")) // поток для записи восстановленного файла
                {
                    // поток разархивации
                    using (GZipStream ds = new GZipStream(ss, CompressionMode.Decompress))
                    {
                        ds.CopyTo(ts);
                        Console.WriteLine($"{destPath} разархивирован");

                        Console.WriteLine("Востановление файла {0} завершено. Было: {1}  стало: {2}.",
                                          path,
                                          ss.Length,
                                          ts.Length);
                    }
                }
            }

        }

        /// <summary>
        /// Главное меню
        /// </summary>
        static public void Menu()
        {
            int menu = -1;
            bool isNum = false;

            while (!isNum || menu < 0 || menu > 9)
            {
                Console.Clear();

                Console.WriteLine("10 - Ввести путь к файлу.\n" +
                    "11 - Создать массив, заполнить его числами и сохранить в файл.\n\n"+
                    "1 - Узнать количество групп." +
                    "\n2 - Получить заполненные группы и записать их в файл." +
                    "\n3 - Удалить файл." +
                    "\n4 - Проверить существует ли файл по указанному пути." +
                    "\n5 - Переместить файл." +
                    "\n6 - Скопировать файл." +
                    "\n7 - Заархивировать файл." +
                    "\n8 - Разархивировать файл." +
                    "\n9 - Показать данные из файла на экране консоли.");

                string strMenu = Console.ReadLine();
                isNum = Int32.TryParse(strMenu, out menu);

                switch (menu)
                {
                    case 11:
                        {
                            Console.WriteLine("Введите длину массива:");
                            int length = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Введите путь куда будет сохранен файл:");
                            destinationPath = Console.ReadLine();

                            //Создаем массив указанной длины, заполняем массив числами от 1 до длины массива и сохраняем результат в файл
                            StreamWrite(PushNumb(CreateArray(length)));

                            Console.WriteLine("Файл создан.");
                            Console.ReadLine();
                            Menu();
                            break;
                        }
                    case 10:
                        {
                            InputPath();
                            Console.WriteLine("Путь к файлам сохранён.");
                            Console.ReadLine();
                            Menu();
                            break;
                        }
                    case 1:
                        {
                            Console.Clear();
                            DateTime date = DateTime.Now;

                            int m = GetM(ReadFile(path));
                            Console.WriteLine("Количество групп - " + m);

                            TimeSpan span = date - DateTime.Now;
                            Console.WriteLine($"Время выполнения в секундах {span.TotalSeconds}");
                            Console.WriteLine($"Время выполнения в миллисекундах {span.TotalMilliseconds}");

                            Console.ReadLine();
                            Console.Clear();
                            Menu();
                            break;
                        }
                    case 2:
                        {
                            InputPath();

                            Console.Clear();
                            DateTime date = DateTime.Now;

                            Hakaton(ReadFile(path));
                            DisplayAll(destinationPath);

                            TimeSpan span = date - DateTime.Now;
                            Console.WriteLine($"Время выполнения в секундах {span.TotalSeconds}");
                            Console.WriteLine($"Время выполнения в миллисекундах {span.TotalMilliseconds}");
                            Console.ReadLine();

                            string choose = "0";

                            while (choose != "1" || choose != "2")
                            {
                                Console.WriteLine("Хотите заархивировать файл с результатом?");
                                Console.WriteLine("1 - да" +
                                "\n2 - нет");

                                choose = Console.ReadLine();

                                if (choose == "1")
                                {
                                    Console.WriteLine("Введите путь для сохранения файла:");
                                    Console.WriteLine("Пример: D:\\Numbers.txt");
                                    string path = Console.ReadLine();

                                    CompressFile(destinationPath, path);
                                    Console.ReadLine();
                                    Menu();
                                }

                                if (choose == "2")
                                {
                                    Menu();
                                }
                            }
                            Menu();
                            break;  
                        }
                    case 3:
                {
                    Console.WriteLine("Введите путь к файлу который хотите удалить:");
                    Console.WriteLine("Пример: D:\\Numbers.txt");

                    string path = Console.ReadLine();
                    DeleteFile(path);

                    Console.WriteLine("Файл удалён.");
                    Console.ReadLine();

                    Menu();
                            break;
                }
                    case 4:
                {
                    Console.WriteLine("Введите путь к файлу:");
                    Console.WriteLine("Пример: D:\\Numbers.txt");
                    ExistsFile(Console.ReadLine());
                    Console.ReadLine();
                    Menu();
                            break;
                }
                    case 5:
                {
                    Console.WriteLine("Введите путь к файлу:");
                    Console.WriteLine("Пример: D:\\Numbers.txt");

                    string path = Console.ReadLine();

                    Console.WriteLine("Введите путь куда будет перемещен файл:");

                    string newPath = Console.ReadLine();

                    MoveFile(path, newPath);
                    Console.WriteLine("Файл перемещен.");
                    Console.ReadLine();
                    Menu();
                            break;
                        }
                    case 6:
                {
                    Console.WriteLine("Введите путь к файлу:");
                    Console.WriteLine("Пример: D:\\Numbers.txt");

                    string path = Console.ReadLine();

                    Console.WriteLine("Введите путь куда будет скопирован файл:");

                    string newPath = Console.ReadLine();

                    CopyFile(path, newPath);
                    Console.WriteLine("Файл скопирован.");
                    Console.ReadLine();
                    Menu();
                            break;
                }
                    case 7:
                {
                    Console.Clear();

                    InputPath();

                    CompressFile(path, destinationPath);

                    Console.ReadLine();
                    Console.Clear();
                    Menu();
                            break;
                }
                    case 8:
                {
                    Console.Clear();

                    InputPath();

                    DecompressFile(path, destinationPath);

                    Console.ReadLine();
                    Console.Clear();
                    Menu();
                            break;
                }
                    case 9:
                {
                    Console.WriteLine("Введите путь к файлу данные которого выведутся на экран:");
                    Console.WriteLine("Пример: D:\\Numbers.txt");
                    string path = Console.ReadLine();
                    Console.Clear();
                    DisplayAll(path);
                    Console.ReadLine();
                            Menu();
                            break;
                }

                }
            }
        }


        static void Main(string[] args)
        {
            Menu();
        }

    }
}
