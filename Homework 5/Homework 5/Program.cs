using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region описание домашнего задания
// Требуется написать несколько методов
//
// Задание 1.
// Воспользовавшись решением задания 3 четвертого модуля
// 1.1. Создать метод, принимающий число и матрицу, возвращающий матрицу умноженную на число
// 1.2. Создать метод, принимающий две матрицу, возвращающий их сумму
// 1.3. Создать метод, принимающий две матрицу, возвращающий их произведение
//
// Задание 2.
// 1. Создать метод, принимающий  текст и возвращающий слово, содержащее минимальное количество букв
// 2.* Создать метод, принимающий  текст и возвращающий слово(слова) с максимальным количеством букв
// Примечание: слова в тексте могут быть разделены символами (пробелом, точкой, запятой)
// Пример: Текст: "A ББ ВВВ ГГГГ ДДДД  ДД ЕЕ ЖЖ ЗЗЗ"
// 1. Ответ: А
// 2. ГГГГ, ДДДД
//
// Задание 3. Создать метод, принимающий текст.
// Результатом работы метода должен быть новый текст, в котором
// удалены все кратные рядом стоящие символы, оставив по одному
// Пример: ПППОООГГГООООДДДААА >>> ПОГОДА
// Пример: Ххххоооорррооошшшиий деееннннь >>> хороший день
//
// Задание 4. Написать метод принимающий некоторое количесво чисел, выяснить
// является заданная последовательность элементами арифметической или геометрической прогрессии
//
// Примечание
//             http://ru.wikipedia.org/wiki/Арифметическая_прогрессия
//             http://ru.wikipedia.org/wiki/Геометрическая_прогрессия
//
// *Задание 5
// Вычислить, используя рекурсию, функцию Аккермана:
// A(2, 5), A(1, 2)
// A(n, m) = m + 1, если n = 0,
//         = A(n - 1, 1), если n <> 0, m = 0,
//         = A(n - 1, A(n, m - 1)), если n> 0, m > 0.
//
// Весь код должен быть откоммментирован
#endregion

namespace Example_005
{

    class Program
    {
        #region Задание_1.1
        /// <summary>
        /// Метод возвращает матрицу умноженную на число
        /// </summary>
        /// <param name="number">число на которое будет умножена матрица</param>
        /// <param name="matrix">матрица на которую будет умножено число</param>
        /// <returns></returns>
        public static int[,] Task1_1(int number, int[,] matrix)
        {
            string strNumb;

            bool isNumb = false;

            string str;

            //это количество строк в матрице
            int strInt = matrix.GetLength(0);

            bool isNum = false;

            string column;

            //это количество столбцов в матрице
            int columnInt = matrix.GetLength(1);

            bool isNumColumn = false;

            int[,] arrayA = new int[strInt, columnInt];
            int[,] arrayB = new int[strInt, columnInt];

            //Умножаем матрицу на число и записываем результат в массив arrayB
            for (int i = 0; i < strInt; i++)
            {
                for (int j = 0; j < columnInt; j++)
                {
                    arrayB[i, j] = matrix[i, j] * number;
                }
            }

            //Вывод на экран
            for (int i = 0; i < strInt; i++)
            {
                if (i == strInt / 2 && number < 10) Console.Write($"  {number} х |  ");
                if (i == strInt / 2 && number > 9) Console.Write($" {number} х |  ");
                if (i != strInt / 2) Console.Write("      |  ");

                for (int k = 0; k < columnInt; k++)
                {
                    Console.Write(matrix[i, k]);
                    Console.Write("  ");
                }

                if (i == strInt / 2) Console.Write("| = |  ");
                else Console.Write("|   |  ");

                for (int k = 0; k < columnInt; k++)
                {
                    Console.Write(String.Format("{0,3:0}", arrayB[i, k]));
                    Console.Write("  ");
                }
                Console.Write("|");

                Console.WriteLine();
            }

            Console.ReadLine();

            return arrayB;
        }
        #endregion

        #region Задание_1.2
        /// <summary>
        /// Метод принимает две матрицы и в зависимости от знака складывает или вычитает матрицы
        /// </summary>
        /// <param name="matrixA">матрица А</param>
        /// <param name="matrixB">матрица Б</param>
        /// <param name="sign">знак сложения или вычитания (+ или -)</param>
        /// <returns></returns>
        public static int[,] Task1_2(int[,] matrixA, int[,] matrixB, char sign)
        {
            string str;

            //Это количество строк в матрице
            int strInt = matrixA.GetLength(0);

            bool isNum = false;

            string column;

            //Это количество столбцов в матрице
            int columnInt = matrixA.GetLength(1);

            bool isNumColumn = false;

            bool MinusOrPlus = false;
            bool Plus = false;

            if (sign == '+') Plus = true;
            if (sign == '+' || sign == '-') MinusOrPlus = true;

            int[,] matrixC = new int[strInt, columnInt];

            //Складываем или вычитаем массивы и сохраняем результат в массив matrixC
            for (int i = 0; i < strInt; i++)
            {
                for (int j = 0; j < columnInt; j++)
                {


                    if (Plus) matrixC[i, j] = matrixA[i, j] + matrixB[i, j];
                    else matrixC[i, j] = matrixA[i, j] - matrixB[i, j];
                }
            }

            Console.Clear();

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

            return matrixC;
        }
        #endregion

        #region Задание_1.3
        /// <summary>
        /// Метод принимает две матрицы и возвращает их произведение
        /// </summary>
        /// <param name="matrixA">матрица А</param>
        /// <param name="matrixB">матрица Б</param>
        /// <returns></returns>
        public static int[,] Task1_3(int[,] matrixA, int[,] matrixB)
        {
            //матрица1 строка
            string str_matrix1;
            int strInt_matrix1 = matrixA.GetLength(0);

            //матрица1 столбцы
            string column_matrix1;
            int columnInt_matrix1 = matrixA.GetLength(1);

            //матрица2 строка
            string str_matrix2;
            int strInt_matrix2 = matrixB.GetLength(0);

            //матрица2 столбцы
            string column_matrix2;
            int columnInt_matrix2 = matrixB.GetLength(1);

            if (columnInt_matrix1 != strInt_matrix2)
            {
                Console.WriteLine("Количество столбцов первой матрицы не равно количеству строк второй матрицы.\nТакие матрицы умножать нельзя!");
                Console.ReadLine();
            }

            //Создаем массивы где будут храниться матрицы
            int[,] matrix3 = new int[strInt_matrix1, columnInt_matrix2];

            Console.Clear();

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

            //Вывод на экран
            int height;

            if (strInt_matrix1 < strInt_matrix2) height = strInt_matrix2;
            else height = strInt_matrix1;
            int matrix1_height = matrixA.GetLength(0);
            int temp = height / 2 - matrix1_height / 2;
            int matrix2_height = matrixB.GetLength(0);
            int temp2 = height / 2 - matrix2_height / 2;
            int matrix3_height = matrix3.GetLength(0);
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
                        //Console.Write("     ");

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
                        if (matrix3[i, k] > 0)
                        {
                            Console.Write(String.Format("{0,3:0}", matrix3[i, k]));
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
                                Console.Write(matrix3[i - temp3, k]);
                                 
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


            return matrix3;
        }
    
        #endregion

        #region Задание_2
        /// <summary>
        /// Метод выводит на консоль самое длинное и самое короткое слово в тексте
        /// </summary>
        /// <param name="text">текст на проверку</param>
        /// <returns></returns>
        public static string LongShortText(string text)
        {
            StringBuilder sb = new StringBuilder();

            int min=0;
            int max=0;
            int difference=0;
            int counter = 0;

            string[] strArray = new string[text.Length];


            for (int i = 0; i < text.Length; i++)
            {
                if (i == 0) min = i;
                //if (i == text.Length - 1) max = i;                    
                if (text[i] == ' ' || text[i] == '.' || text[i] == ',' || i == text.Length-1)
                {
                    max = i;
                    if (i == text.Length - 1) max = i + 1;
                    difference = max - min;
                    char[] word = new char[difference];

                    for (int k = 0; k <difference; k++)
                    {
                        word[k] = text[min];
                        min++;
                    }

                    foreach (char ch in word)
                        sb.Append(ch);
                    strArray[counter] = sb.ToString();
                    counter++;
                    min = max+1;
                    sb.Clear();
                }
            }

            string minStr=strArray[0];
            string maxStr=strArray[0];
            int StrLength;

            for (int i = 0; i < text.Length; i++)
            {
                if (strArray[i] == null) break;
                if (minStr.Length > strArray[i].Length) minStr = strArray[i];
                if (maxStr.Length < strArray[i].Length) maxStr = strArray[i];
            }

            StrLength = maxStr.Length;

            for (int k = 0; k < text.Length; k++)
            {
                if (strArray[k] == null) break;
                if (StrLength == strArray[k].Length && maxStr != strArray[k])
                {
                    maxStr += " " + strArray[k];
                }
            }

            Console.WriteLine($"Слово с максимальным количеством букв: {maxStr}");
            Console.WriteLine($"Слово с минимальным количеством букв: {minStr}");

            return ""; 
        }
        #endregion

        #region Задание_3
        /// <summary>
        /// Метод проверяет текст на наличие повторяющихся символов и возвращает текст без повторно идущих друг за друга символов
        /// </summary>
        /// <param name="text">текст на проверку</param>
        /// <returns></returns>
        public static string Word(string text)
        {
            char[] ChText = new char[text.Length];

            //указатель
            int pointer = 0;

            for(int i = 0; i < text.Length - 1; i++)
            {
                if (i == 0)
                {
                    ChText[pointer] = text[i];
                    pointer++;
                }
                if (char.ToUpper(text[i]) != char.ToUpper(text[i + 1]))
                {
                    ChText[pointer] = text[i + 1];
                    pointer++;
                }
            }

            //преобразуем массив char в строку text
            StringBuilder sb = new StringBuilder();

            foreach (char ch in ChText)
            sb.Append(ch);
            text = sb.ToString();

            return text;
        }
        #endregion

        #region Задание_4
        /// <summary>
        /// Метод проверяет является ли заданная последовательность чисел элементами арифметической или геометрической прогрессии
        /// </summary>
        /// <param name="numbers">последовательность чисел</param>
        /// <returns></returns>

        public static string CheckNumb(params double[] numbers)
        {
            // d - Это шаг или разность ( + или - )
            double d;

            // q - Это знаменатель прогрессии
            double q;

            bool Arithmetic_Progression = false;
            bool Geometric_Progression = false;

            string result = "1";

            //Является ли заданная последовательность чисел элементами арифметической прогрессии?
            d = numbers[0] - numbers[1];

            //Проверка на разность ( - минус)
            for (int i = 0; i < numbers.Length-1; i++)
            {
                if (d != numbers[i] - numbers[i + 1])
                {
                    Arithmetic_Progression = false;
                    break;
                }
                else
                {
                    Arithmetic_Progression = true;
                }
            }

            //Проверка на шаг (+ плюс)
            d = numbers[1] - numbers[0];

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (d != numbers[i+1] - numbers[i])
                {
                    Arithmetic_Progression = false;
                    break;
                }
                else
                {
                    Arithmetic_Progression = true;
                }
            }

            //Является ли заданная последовательность чисел элементами геометрической прогрессии?

            q = numbers[1] / numbers[0];
            for(int i = 0; i < numbers.Length - 1; i++)
            {
                if(q != numbers[i+1] / numbers[i])
                {
                    Geometric_Progression = false;
                    break;
                }
                else
                {
                    Geometric_Progression = true;
                }
            }

            //Выводим результат
            string DecInc;
            if (d < 0) DecInc = "убывающая";
            else DecInc = "возрастающая";

            if (Arithmetic_Progression == false) result = "Это не арифметическая прогрессия";
            else result = $"Это {DecInc} арифметическая прогрессия с шагом {d}";
            if (Arithmetic_Progression == false && Geometric_Progression == false) result = "Это не арифметическая и не геометрическая прогрессия";
            if (Arithmetic_Progression && Geometric_Progression && d == 0 && q==1) result = $"Это стационарная арифметическая прогрессия с разностью {d} \nи стационарная геометрическая прогрессия с знаменателем {q}";
            if (Geometric_Progression == true && q < 0) result = $"Это знакочередующаяся геометрическая прогрессия \nзнаменатель = {q}";
            if (Geometric_Progression == true && Arithmetic_Progression == false) result = $"Это геометрическая прогрессия \nзнаменатель = {q}";

            return result;
        }
        #endregion

        #region Задание_5
        /// <summary>
        /// Метод вычисляет функцию Аккермана
        /// </summary>
        /// <param name="m">значение m</param>
        /// <param name="n">значение n</param>
        /// <returns></returns>
        public static int Akkerman(int m, int n)
        {
            if (m == 0) return n + 1;
            if (m > 0 && n == 0) return Akkerman(m - 1, 1);
            if (m > 0 && n > 0) return Akkerman(m - 1, Akkerman(m, n - 1));

            return Akkerman(m, n);
        }
        #endregion


        static void Main(string[] args)
        {
            //Задание 5
            //Console.WriteLine(Akkerman(3,4));

            ////Задание 1_2 и 1_3
            //Random rnd = new Random();

            //int[,] m = new int[5, 5];


            //for (int i = 0; i < m.GetLength(0); i++)
            //{
            //    for (int k = 0; k < m.GetLength(1); k++)
            //    {
            //        m[i, k] = rnd.Next(0, 10);
            //    }
            //}

            //int[,] n = new int[5, 5];


            //for (int i = 0; i < m.GetLength(0); i++)
            //{
            //    for (int k = 0; k < m.GetLength(1); k++)
            //    {
            //        n[i, k] = rnd.Next(0, 5);
            //    }
            //}

            //Task1_3(m, n);

            //Задание 1_1
            Random rnd = new Random();

            int[,] m = new int[5, 5];


            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int k = 0; k < m.GetLength(1); k++)
                {
                    m[i, k] = rnd.Next(0, 5);
                }
            }

            Task1_1(5, m);


            //Задание 2
            //LongShortText("1 22 333 4444 55555 77777 88888 33333 11111 00000 CCCCC");

            //Console.WriteLine(LongShortText("А ББ ВВВ ГГГГ ДДДДД ЕЕЕЕЕЕ ЁЁЁЁЁЁЁ ЖЖЖЖЖЖЖ"));

            //#region Задание_4
            //double[] Chisla = new double[5];

            //Chisla[0] = 25;
            //Chisla[1] = 50;
            //Chisla[2] = 100;
            //Chisla[3] = 200;
            //Chisla[4] = 400;

            //Console.WriteLine("Введены числа: ");

            //for (int i=0; i < Chisla.Length; i++)
            //{
            //    Console.Write(Chisla[i] + " ");
            //}

            //Console.Write("\n");
            //Console.WriteLine(CheckNumb(Chisla));
            //Console.ReadLine();
            //#endregion
        }
    }
}
