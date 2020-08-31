using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_5_Task1._3
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
        /// Метод умножает две матрицы и возвращает матрицу - результат
        /// </summary>
        /// <param name="matrixA">Матрица А</param>
        /// <param name="matrixB">Матрица Б</param>
        /// <returns></returns>
        public static int[,] MultiplyMatrix(int[,] matrixA, int[,] matrixB)
        {
            //Матрица А строка
            int strInt_matrix1 = matrixA.GetLength(0);

            //Матрица А стобец
            int columnInt_matrix1 = matrixA.GetLength(1);

            //Матрица Б строка
            int strInt_matrix2 = matrixB.GetLength(0);

            //Матрица Б столбец
            int columnInt_matrix2 = matrixB.GetLength(1);

            //Создаем двумерный массив где будет храниться матрица - результат
            int[,] matrix3 = new int[strInt_matrix1, columnInt_matrix2];

            //Перемножаем матрицы
            for (int i = 0; i < columnInt_matrix2; i++)
            {
                for (int j = 0; j < strInt_matrix1; j++)
                {
                    for (int q = 0; q < columnInt_matrix1; q++)
                    {
                        matrix3[j, i] += matrixA[j, q] * matrixB[q, i];
                    }
                }
            }

            return matrix3;
        }

        /// <summary>
        /// Метод принимает две матрицы и матрицу результат. Выводит все матрицы на экран.
        /// </summary>
        /// <param name="matrixA">Матрица А</param>
        /// <param name="matrixB">Матрица Б</param>
        /// <param name="matrixC">Матрица - результат</param>
        public static void DisplayAll(int[,] matrixA, int[,] matrixB, int[,] matrixC)
        {
            //Матрица А строка
            int strInt_matrix1 = matrixA.GetLength(0);

            //Матрица А стобец
            int columnInt_matrix1 = matrixA.GetLength(1);

            //Матрица Б строка
            int strInt_matrix2 = matrixB.GetLength(0);

            //Матрица Б столбец
            int columnInt_matrix2 = matrixB.GetLength(1);

            //Вывод на экран
            int height;

            if (strInt_matrix1 < strInt_matrix2) height = strInt_matrix2;
            else height = strInt_matrix1;
            int matrix1_height = matrixA.GetLength(0);
            int temp = height / 2 - matrix1_height / 2;
            int matrix2_height = matrixB.GetLength(0);
            int temp2 = height / 2 - matrix2_height / 2;
            int matrix3_height = matrixC.GetLength(0);
            int temp3 = height / 2 - matrix3_height / 2;

            for (int i = 0; i < height; i++)
            {
                //Вывод матрицы1 если количество её строк меньше чем количество строк матрицы2
                if (matrix1_height < height)
                {
                    if (i >= temp && matrix1_height > 0)
                    {
                        Console.Write("  |  ");

                        for (int k = 0; k < columnInt_matrix1; k++)
                        {
                            Console.Write(matrixA[i - temp, k]);
                            Console.Write("  ");
                        }
                        matrix1_height--;

                        if (i != height / 2) Console.Write("|   |  ");
                    }

                    else
                    {
                        Console.Write("     ");

                        for (int k = 0; k < columnInt_matrix1; k++)
                        {
                            Console.Write("   ");
                        }

                        if (i != height / 2) Console.Write("    |  ");
                    }

                    if (i == height / 2) Console.Write("| x |  ");
                }

                //Вывод матрицы1 если количество её строк такое же как количество строк матрицы2
                if (matrix1_height == height)
                {
                    Console.Write("  |  ");

                    for (int k = 0; k < columnInt_matrix1; k++)
                    {
                        Console.Write(matrixA[i, k]);
                        Console.Write("  ");
                    }

                    if (i == height / 2) Console.Write("| x |  ");
                    if (matrix1_height == matrix2_height && i != height / 2) Console.Write("|   |  ");
                    if (matrix1_height > matrix2_height && i != height / 2) Console.Write("|      ");

                }

                //Вывод матрицы2 если количество её строк меньше чем количество строк матрицы1
                if (matrix2_height < height)
                {
                    if (i >= temp2 && matrix2_height > 0)
                    {
                        for (int k = 0; k < columnInt_matrix2; k++)
                        {
                            Console.Write(matrixB[i - temp2, k]);
                            Console.Write("  ");
                        }
                        matrix2_height--;

                        if (i != height / 2) Console.Write("   ");
                    }

                    else
                    {
                        for (int k = 0; k < columnInt_matrix2; k++)
                        {
                            Console.Write("   ");
                        }

                        if (i != height / 2) Console.Write("   ");
                    }

                    if (i == height / 2) Console.Write("| =");
                }

                //Вывод матрицы2 если количество её строк такое же как количество строк матрицы2
                if (matrix2_height == height)
                {
                    for (int k = 0; k < columnInt_matrix2; k++)
                    {
                        Console.Write(matrixB[i, k]);
                        Console.Write("  ");
                    }

                    if (i == height / 2) Console.Write("| =");
                    else Console.Write("|  ");
                }

                //Вывод матрицы 3
                if (matrix3_height == height)
                {
                    Console.Write(" | ");
                    for (int k = 0; k < columnInt_matrix2; k++)
                    {
                        if (matrixC[i, k] > 0)
                        {
                            Console.Write(String.Format("{0,3:0}", matrixC[i, k]));
                            Console.Write("  ");
                        }
                        else Console.Write("   ");
                    }
                    Console.Write("|");
                }

                if (matrix3_height < height)
                {
                    if (i >= temp3 && matrix3_height > 0)
                    {
                        Console.Write(" | ");
                        for (int k = 0; k < columnInt_matrix2; k++)
                        {
                            {
                                Console.Write(matrixC[i - temp3, k]);

                                Console.Write(" ");
                            }
                        }
                        matrix3_height--;
                        Console.Write("|");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    

        static void Main(string[] args)
        {
            //Создаем два массива куда будем сохранять матрицы
            int[,] matrixA = new int[5, 5];
            int[,] matrixB = new int[5, 2];

            //Создаем массив - матрицу куда будем записывать результат
            int[,] matrixC = new int[5, 5];

            //Заполняем матрицы случайными числами
            FillMatrixRndNumber(matrixA, 0, 10);
            FillMatrixRndNumber(matrixB, 0, 10);

            //Умножаем матрицы и записываем результат в матрицу C
            matrixC = MultiplyMatrix(matrixA, matrixB);

            //Выводим все матрицы на экран
            DisplayAll(matrixA, matrixB, matrixC);
        }
    }
}
