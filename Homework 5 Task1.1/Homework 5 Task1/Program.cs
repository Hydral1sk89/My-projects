using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_5_Task1
{
    // Задание 1.
    // Воспользовавшись решением задания 3 четвертого модуля
    // 1.1. Создать метод, принимающий число и матрицу, возвращающий матрицу умноженную на число
    // 1.2. Создать метод, принимающий две матрицу, возвращающий их сумму
    // 1.3. Создать метод, принимающий две матрицу, возвращающий их произведение

    //Комментарий преподавателя
    //Один метод должен отвечать за что-то одно.То, что методы возвращают матрицу - это верно. Но у Вас всё в одном методе.
    //Один метод должен инициализировать матрицы, второй - заполнять.Третий - делать действие, четвертый - выводить матрицу на экран.
    //откуда взялось столько выводов на экран? Зачем это? Это же копипаст, одинаковый код. ДОлжен быть единый метод вывода на экран всех матриц.

    class Program
    {
        /// <summary>
        /// Метод выводит матрицу на экран
        /// </summary>
        /// <param name="matrix">матрица</param>
        public static void DisplayMatrix(int[,] matrix)
        {
            //это количество строк в матрице
            int strInt = matrix.GetLength(0);

            //это количество столбцов в матрице
            int columnInt = matrix.GetLength(1);

            //Вывод на экран
            for (int i = 0; i < strInt; i++)
            {
                Console.Write("| ");
                for (int k = 0; k < columnInt; k++)
                {
                    Console.Write(String.Format("{0,3:0}", matrix[i, k]));
                    Console.Write("  ");
                }
                Console.Write("|");

                Console.WriteLine();
            }

            Console.WriteLine();
        }
        
        /// <summary>
        /// Метод умножает матрицу на число и возвращает умноженную матрицу
        /// </summary>
        /// <param name="number">число</param>
        /// <param name="matrix">матрица</param>
        /// <returns></returns>
        public static int[,] MultipleMatrixForNumber(int number, int[,] matrix)
        {
            //это количество строк в матрице
            int strInt = matrix.GetLength(0);

            //это количество столбцов в матрице
            int columnInt = matrix.GetLength(1);

            //Создаем двумерный массив в который будем записывать умноженную матрицу
            int[,] arrayB = new int[strInt, columnInt];

            //Умножаем матрицу на число и записываем результат в массив arrayB
            for (int i = 0; i < strInt; i++)
            {
                for (int j = 0; j < columnInt; j++)
                {
                    arrayB[i, j] = matrix[i, j] * number;
                }
            }

            return arrayB;
        }

        /// <summary>
        /// Метод заполняет матрицу случайными числами от и до указанных значений
        /// </summary>
        /// <param name="matrix">матрица</param>
        /// <param name="from">значение "от"</param>
        /// <param name="to">значение "до"</param>
        /// <returns></returns>
        public static int[,] FillMatrixRndNumber(int[,] matrix, int from, int to)
        {
            Random rnd = new Random();

            for (int i=0; i < matrix.GetLength(0); i++)
            {
                for(int j=0;j<matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rnd.Next(from, to);
                }
            }

            return matrix;
        }

        static void Main(string[] args)
        {
            //Создаем двумерный массив в который будет записана наша матрица
            int[,] MatrixArray = new int[5, 5];

            //Помещаем нашу матрицу в метод что бы вернуть заполненную матрицу
            //и эту заполненную матрицу помещаем в метод что бы вывести её на экран
            DisplayMatrix(FillMatrixRndNumber(MatrixArray, 0, 10));

            //Умножаем нашу матрицу на число и выводим её на экран
            DisplayMatrix(MultipleMatrixForNumber(5, MatrixArray));
        }
    }
}
