using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

/// Разработать ежедневник.
/// В ежедневнике реализовать возможность 
/// - создания
/// - удаления
/// - редактирования 
/// записей
/// 
/// В отдельной записи должно быть не менее пяти полей
/// 
/// Реализовать возможность 
/// - Загрузки данных из файла
/// - Выгрузки данных в файл
/// - Добавления данных в текущий ежедневник из выбранного файла
/// - Импорт записей по выбранному диапазону дат
/// - Упорядочивания записей ежедневника по выбранному полю

namespace Homework_7
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"data.csv";

            Repository rep = new Repository(path);

            //rep.Load(@"data.csv");

            rep.Add(new Note(1, "Это пробный текст записки", "здесь комментарий", DateTime.Now, DateTime.Now));

            //Если excel запущен то закрываем
            foreach (Process proc in Process.GetProcessesByName("Excel")) proc.Kill();

            Thread.Sleep(500);
            rep.Save(@"data2.csv");
            Thread.Sleep(500);
            Process.Start(@"data2.csv");
        }
    }
}
