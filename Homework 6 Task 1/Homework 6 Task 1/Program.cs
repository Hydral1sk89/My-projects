using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Homework_6_Task_1
{
    class Program
    {
        //Массив массивов где будет хранится вся наша информация
        public static int[][] jaggedArray = new int[1][];
        
        //Переменная в которой хранится количество массивов
        public static int quantity = 0;

        //переменные в которых хранится порядковые числа-названия массивов
        public static int j1 = 0;
        public static int j2 = 1;

        /// <summary>
        /// Метод добавляет ещё один массив в массив массивов JaggedArray
        /// </summary>
        static public void AddArray()
        {
            quantity++;
            Array.Resize(ref jaggedArray, jaggedArray.Length + 1);
            if (jaggedArray[quantity] == null)
            Array.Resize(ref jaggedArray[quantity], 0);
        }

        // Индекс нового числа
        public static int newNumber = 0;

        /// <summary>
        /// Метод делит массив массивов на массивы, где в каждом массиве помещаются числа которые не делятся друг на друга без остатка.
        /// </summary>
        /// <param name="numbers">массив</param>
        static public void hakaton(int[][] numbers)
        {
            //где k - индекс массива массивов
            int k = 0;
            
            //for (int k = 0; k < numbers.Length; k++)
            do
            {
                //Создаем новый массив что бы туда сохранить результат
                AddArray();

                //где i и j - индекс массива
                for (int i = numbers[k].Length - 1; i >= 0; i--)
                {
                    for (int j = numbers[k].Length - 1; j >= 0; j--)
                    {
                        //Если число одинаковые то переходим на следующую итерацию
                        if (numbers[k][i] == numbers[k][j]) continue;

                        //Если число делится без остатка то копируем число в другой массив
                        if (numbers[k][i] % numbers[k][j] == 0)
                        {
                            CopyAndDeleteArr(ref jaggedArray[j1], ref jaggedArray[j2], j);
                            numbers[k] = jaggedArray[j1];
                            if (i > numbers[k].Length - 1) i = numbers[k].Length - 1;
                        }
                    }
                }
                j1++;
                j2++;
                newNumber = 0;
                k++;
                numbers = jaggedArray;
            }
            while (numbers[numbers.Length-1][numbers[k].Length-1] != 1);
        }

        /// <summary>
        /// Метод удаляет из основного массива значение под определенным индексом и делает массив короче. 
        /// Значение под этим индексом попадает во второй массив, второй массив сортируется. 
        /// </summary>
        /// <param name="MainArray">массив из которого будет "вырезано" значение</param>
        /// /// <param name="SecondaryArray">массив куда будет "вставлено" значение</param>
        /// <param name="index">индекс значения которое будет "вырезано"</param>
        /// <returns></returns>
        static public void CopyAndDeleteArr (ref int[] MainArray, ref int[] SecondaryArray, int index)
        {
            //Увеличивает вместимость массива на 1 
            Array.Resize(ref SecondaryArray, SecondaryArray.Length+1);
            //Записываем во второй массив число
            SecondaryArray[newNumber] = MainArray[index];
            newNumber++;
            //Сортируем массив
            Array.Sort(SecondaryArray);


            //Удаляем наше число из основного массива
            MainArray[index] = 0;

            Array.Sort(MainArray);
            //Проверяем что бы число 0 оказалось в конце массива
            if (MainArray[0] < MainArray[1])
            {
                Array.Sort(MainArray);
                Array.Reverse(MainArray);
                //Удаляем последнее число ( число 0 ) из основного массива
                Array.Resize(ref MainArray, MainArray.Length - 1);
                if(MainArray.Length > 1)
                if (MainArray[0] > MainArray[1]) Array.Reverse(MainArray);
            }

            //Сортируем массив
            Array.Sort(MainArray);
        }

        /// <summary>
        /// выводит результат на экран консоли
        /// </summary>
        /// <param name="numbers">массив</param>
        static public void Display(int[][] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"Группа{i + 1}: ");
                for (int j = 0; j <= numbers[i].Length - 1; j++)
                {
                    Console.Write(numbers[i][j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine($"M = {numbers.Length}");
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


        static void Main(string[] args)
        {
            //Создаем массив на N элементов
            jaggedArray[0] = new int[50];

            //Поместим числа в основной массив
            PushNumb(jaggedArray[0]);

            //Пропускаем через метод наш массив
            hakaton(jaggedArray);

            //Выводим на экран
            Display(jaggedArray);
        }
    }
}
