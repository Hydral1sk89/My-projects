using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_5_Task_1._2
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
        /// Метод складывает или вычитает матрицы в зависимости от знака
        /// </summary>
        /// <param name="matrixA">матрица А</param>
        /// <param name="matrixB">матрица Б</param>
        /// <param name="sign">знак "+" или "-"</param>
        /// <returns></returns>
        public static int[,] AdditionSubtractionMatrix(int[,] matrixA, int[,] matrixB, char sign)
        {
            //Это количество строк в матрице
            int strInt = matrixA.GetLength(0);

            //Это количество столбцов в матрице
            int columnInt = matrixA.GetLength(1);

            //Это двумерный массив в который будем сохранят результат сложения или вычетания матриц 
            int[,] matrixC = new int[strInt, columnInt];

            bool Plus = false;

            if (sign == '+') Plus = true;
            if (sign == '-') Plus = false;

            //Складываем или вычитаем массивы и сохраняем результат в массив matrixC
            for (int i = 0; i < strInt; i++)
            {
                for (int j = 0; j < columnInt; j++)
                {
                    if (Plus) matrixC[i, j] = matrixA[i, j] + matrixB[i, j];
                    else matrixC[i, j] = matrixA[i, j] - matrixB[i, j];
                }
            }

            return matrixC;
        }

        /// <summary>
        /// Метод выводит на экран две матрицы участвующие в сложении или вычетании и матрицу - результат.
        /// </summary>
        /// <param name="matrixA">матрица А</param>
        /// <param name="matrixB">матрица Б</param>
        /// <param name="matrixC">матрица - результат</param>
        /// <param name="sign">знак "+" или "-"</param>
        public static void DisplayAll(int[,] matrixA, int [,] matrixB, int [,] matrixC, char sign)
        {
            //Это количество строк в матрице
            int strInt = matrixA.GetLength(0);

            //Это количество столбцов в матрице
            int columnInt = matrixA.GetLength(1);

            //Вывод на экран
            for (int i = 0; i < strInt; i++)
            {
                Console.Write("  |  ");

                for (int k = 0; k < columnInt; k++)
                {
                    Console.Write(matrixA[i, k]);
                    Console.Write("  ");
                }

                if (i == strInt / 2) Console.Write($"| {sign} |  ");
                else Console.Write("|   |  ");

                for (int k = 0; k < columnInt; k++)
                {
                    Console.Write(matrixB[i, k]);
                    Console.Write("  ");
                }
                if (i == strInt / 2) Console.Write("| = |  ");
                else Console.Write("|   |  ");

                for (int k = 0; k < columnInt; k++)
                {
                    Console.Write(String.Format("{0,2:0}", matrixC[i, k]));
                    Console.Write("  ");
                }
                Console.Write("|");

                Console.WriteLine();
            }
        }


        static void Main(string[] args)
        {
            //Создаем два массива куда будем сохранять матрицы
            int[,] matrixA = new int[5, 5];
            int[,] matrixB = new int[5, 5];

            //Создаем массив - матрицу куда будем записывать результат
            int[,] matrixC = new int[5, 5];

            //Заполняем матрицы случайными числами
            FillMatrixRndNumber(matrixA, 0, 10);
            FillMatrixRndNumber(matrixB, 0, 10);

            //Складываем матрицы
            matrixC = (AdditionSubtractionMatrix(matrixA, matrixB, '+'));

            //Выводим общий результат на экран
            DisplayAll(matrixA, matrixB, matrixC, '+');

            //Пробел между матрицами
            Console.WriteLine();

            //Вычитаем матрицы
            matrixC = (AdditionSubtractionMatrix(matrixA, matrixB, '-'));

            //Выводим общий результат на экран
            DisplayAll(matrixA, matrixB, matrixC, '-');

            Console.ReadLine();

        }
    }
}
