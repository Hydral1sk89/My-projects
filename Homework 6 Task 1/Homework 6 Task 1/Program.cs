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
        //свойства делимости 
        // 1. А == А/1; 

        // 2. Если целое число a отлично от нуля и делится на целое число b, 
        //то модуль числа a не меньше модуля числа b. То есть, если a≠0 и a%b==0, то модуль а >= модулю b
        //Это свойство делимости непосредственно вытекает из предыдущего.

        // 3. Свойство транзитивности.
        // a == m * a1, m==b*m1, a==m*a1==(b*m1)*a1 == b*(m1*a1).
        // m1*a1 == q; a==b*q;

        // 4. Свойство антисимметричности.

        //Основной массив
        public static int[] numb = new int[10];

        // Массив в который будем сохранять числа которые делят наше число без остатка
        public static int[] SecondaryArray = new int[1];
        // Индекс нового числа
        public static int newNumber = 0;

        public static int[] GroupTwoArray = new int[10];

        static public int[] hakaton(params int[] numbers)
        {
            //Массив - одна группа для результата
            int[] result =new int[1];
            int countIndex = 0;

            //индекс массива - результата
            int count = 0;

            int tempCount=-1;

            for (int i = numbers.Length - 1; i > 0; i--)
            {
                //переменная служит для выхода из цикла
                if (tempCount == -1) tempCount = i;
                if (tempCount == 0) break;

                for (int j = numbers.Length - 1; j >= 0; j--)
                {
                    if (i > result.Length || i > numbers.Length) i = numbers.Length-1;

                    if (count == 0)
                    {
                        result[count] = numbers[j];
                        count++;
                    }
                    //Проверяем не закончился ли наш массив
                    if ((i - (i - 1)) >= 0)
                    {
                        if (result.Length >= i)
                        {
                            if (result[i] == numbers[i] && numbers[i] % numbers[j] == 0 && j != i)
                            {
                                if (numbers[j] != -1)
                                {
                                    GroupTwoArray[countIndex] = numbers[j];
                                    countIndex++;
                                }
                                result[j] = -1;
                                numbers[j] = -1;
                                
                            }
                        }
                        if (numbers[i] % numbers[j] == 0) continue;
                        if (numbers[i] <= numbers[j]) continue;
                        if (numbers[j] == -1) continue;

                        // Пробуем делить число на число из списка
                        if (numbers[i] % numbers[j] != 0)
                        {
                            //Проверяем есть ли это число в массиве - результате
                            if (!(Array.Exists<int>(result, element => element == numbers[j])))
                            {
                                Array.Resize(ref result, result.Length + 1);
                                result[count] = numbers[j];

                                if (numbers[j] != -1)
                                {
                                    GroupTwoArray[countIndex] = numbers[j];
                                    countIndex++;
                                }

                                numbers[j] = -1;
                                count++;
                            }
                        }
                    }
                }

                //Проверка не добавили ли лишнее число в массив и удаляем лишнее если оно есть 
                if (result[result.Length - 1] == 0) Array.Resize(ref result, result.Length - 1);
                //group++;

                //Делаем массив numbers того же размера что и массив - результат
                Array.Resize(ref numbers, result.Length);

                //Копируем цифры в массив numbers из массива - результата
                numbers = result;

                //Сортируем массив
                if(numbers[0] > numbers[1])Array.Reverse(numbers);
 
                tempCount--;
                if (tempCount == 0) return result;
            }
           
            //Убрать лишнее с массива
            int[] our_result = RemoveExcess(result);

            //вернуть результат
            return our_result;
        }

        /// <summary>
        /// Метод удаляет из основного массива значение под определенным индексом и делает массив короче. 
        /// Значение под этим индексом попадает во второй массив, второй массив сортируется. 
        /// </summary>
        /// <param name="MainArray">массив из которого будет "вырезано" значение</param>
        /// <param name="index">индекс значения которое будет "вырезано"</param>
        /// <returns></returns>
        static public void CopyAndDeleteArr (int[] MainArray,int index)
        {
            //Записываем во второй массив число
            SecondaryArray[newNumber] = MainArray[index];
            //Увеличивает вместимость массива на 1 
            Array.Resize(ref SecondaryArray, SecondaryArray.Length + 1);
            //Сортируем массив
            Array.Sort(SecondaryArray);


            //Удаляем наше число из основного массива
            MainArray[index] = 0;

            //Проверяем что бы число 0 оказалось в конце массива
            if (MainArray[0] < MainArray[1])
            {
                Array.Sort(MainArray);
                Array.Reverse(MainArray);
                //Удаляем последнее число ( число 0 ) из основного массива
                Array.Resize(ref MainArray, MainArray.Length - 1);
                if (MainArray[0] > MainArray[1]) Array.Reverse(MainArray);
                Array.Sort(MainArray);
            }

            //Сортируем массив
            Array.Sort(MainArray);
        }


        /// <summary>
        /// Удаляет из массива те индексами под которыми хранится значение -1
        /// </summary>
        /// <param name="Arr">массив</param>
        /// <returns></returns>
        static public int[] RemoveExcess (int[] Arr)
        {
            if (Arr[0] == -1) Array.Reverse(Arr);

            while (Arr[Arr.Length - 1] == -1)
            {
                Array.Resize(ref Arr, Arr.Length - 1);
            }

            if (Arr[0] > Arr[1]) Array.Reverse(Arr);

            return Arr;
        }

        /// <summary>
        /// выводит массив на экран консоли
        /// </summary>
        /// <param name="numbers"></param>
        static public void Display(int[] numbers)
        {
            for (int j = 0; j <= numbers.Length-1; j++)
            {
                Console.Write(numbers[j] + " ");
            }
            Console.WriteLine();
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

            PushNumb(numb);

            Display(numb);
            Display(SecondaryArray);

            CopyAndDeleteArr(numb, 4);
            Display(numb);
            Display(SecondaryArray);

            //Display(hakaton(numb));
            //Display(GroupTwoArray);
        }
    }
}
