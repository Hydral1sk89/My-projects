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
        // 

        static public int[] hakaton(params int[] numbers)
        {
            ////Кол-во групп по умолчанию
            //int group = 0;

            //Массив - одна группа для результата
            int[] result =new int[1];

            //индекс массива - результата
            int count = 0;

            ////массив строк в котором будут сохраняться группы с числами
            //string[] result = new string[50];

            //int i = numbers.Length - 1;
            int tempCount;

            for (int i = numbers.Length - 1; i > 0; i--)
            {
                for (int j = numbers.Length - 1; j > 0; j--)
                {
                    if (count == 0)
                    {
                        result[count] = numbers[j];
                        tempCount = numbers[j];
                        count++;
                    }
                    //Проверяем не закончился ли наш массив
                    if ((i - (i - 1)) >= 0)
                    {

                        if (numbers[i] % numbers[j] == 0) continue;
                        if (numbers[i] <= numbers[j]) continue;
                        if (numbers[j] == -1) continue;

                        // Пробуем делить число на число из списка
                        if (numbers[i] % numbers[j] != 0)
                        {
                            if (!(Array.Exists<int>(result,element => element == numbers[j])))
                            Array.Resize(ref result, result.Length + 1);
                            result[count] = numbers[j];
                            numbers[j] = -1;
                            count++;
                        }
                    }
                }

                //Проверка не добавили ли лишнее число в массив и удаляем лишнее если оно есть 
                if (result[result.Length - 1] == 0) Array.Resize(ref result, result.Length - 1);
                //group++;

                Array.Resize(ref numbers, result.Length);
                numbers = result;

                Array.Reverse(numbers);

                i = numbers.Length - 1;
            }
            for (int j = result.Length-1; j >= 0; j--)
            {
                Console.Write(result[j] + " ");
            }
            //for(int i = 0; i < numbers.Length - 1; i++)
            //{
            //    Console.Write(numbers[i] + " ");
            //}



            //вернуть результат
            return result;
        }


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
            int[] numb = new int[10];

            PushNumb(numb);

            hakaton(numb);
        }
    }
}
