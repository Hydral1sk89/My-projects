using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_5_Task1
{
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
        public static int[,] MultiplyMatrixForNumber(int number, int[,] matrix)
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

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rnd.Next(from, to);
                }
            }

            return matrix;
        }

        /// <summary>
        /// Этот метод принимает матрицу и число на которое будет умножена матрица и отбражает на консоль число, матрицу и матрицу - результат.
        /// </summary>
        /// <param name="matrix">матрица</param>
        /// <param name="number">число на которое будет умножена матрица</param>
        public static void DisplayAll(int[,] matrixA, int[,] matrixResult, int number)
        {
            //это количество строк в матрице
            int strInt = matrixA.GetLength(0);

            //это количество столбцов в матрице
            int columnInt = matrixA.GetLength(1);

            //Вывод на экран
            for (int i = 0; i < strInt; i++)
            {
                if (i == strInt / 2 && number < 10) Console.Write($"  {number} х |  ");
                if (i == strInt / 2 && number > 9) Console.Write($" {number} х |  ");
                if (i != strInt / 2) Console.Write("      |  ");

                for (int k = 0; k < columnInt; k++)
                {
                    Console.Write(matrixA[i, k]);
                    Console.Write("  ");
                }

                if (i == strInt / 2) Console.Write("| = |  ");
                else Console.Write("|   |  ");

                for (int k = 0; k < columnInt; k++)
                {
                    Console.Write(String.Format("{0,3:0}", matrixResult[i, k]));
                    Console.Write("  ");
                }
                Console.Write("|");

                Console.WriteLine();
            }
        }
            
        static void Main(string[] args)
        {
            //Создаем двумерный массив в который будет записана наша матрица
            int[,] MatrixArray = new int[5, 5];

            //Создаем двумерный массив в который будет записана матрица - результат
            int[,] MatrixArrayResult = new int[5, 5];

            //Заполняем массив - матрицу случайными числами
            FillMatrixRndNumber(MatrixArray, 0, 10);

            //Помещаем матрицу в метод и записываем результат в массив - матрицу результат
            MatrixArrayResult = MultiplyMatrixForNumber(5, MatrixArray);

            //Выводим все матрицу и число на консоль
            DisplayAll(MatrixArray, MatrixArrayResult, 5);

            Console.ReadLine();
        }
    }
}
