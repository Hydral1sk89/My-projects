using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_7
{
    struct Repository
    {
        private Note[] note;

        private string path;

        int index;
        string[] titles;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Path"></param>
        public Repository(string Path)
        {
            this.path = Path;
            this.index = 0;
            this.titles = new string[5];
            this.note = new Note[2];
        }

        /// <summary>
        /// увеличить размер массива Note[]
        /// </summary>
        /// <param name="Flag"></param>
        private void Resize(bool Flag)
        {
            if (Flag)
            {
                Array.Resize(ref this.note, this.note.Length * 2);
            }
        }

        /// <summary>
        /// добавить запись
        /// </summary>
        /// <param name="ConcreteNote"></param>
        public void Add(Note ConcreteNote)
        {
            this.Resize(index >= this.note.Length);
            this.note[index] = ConcreteNote;
            this.index++;
        }

        /// <summary>
        /// Загрузить записи из файла
        /// </summary>
        /// <param name="path">путь к файлу</param>
        public void Load(string path)
        {          
            using (StreamReader sr = new StreamReader(path))
            {
                titles = sr.ReadLine().Split(',');

                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split(',');

                    Add(new Note(Convert.ToInt32(args[0]), args[1], args[2], Convert.ToDateTime(args[3]), Convert.ToDateTime(args[4])));
                }
            }
        }

        /// <summary>
        /// Сохранить результат в файл
        /// </summary>
        /// <param name="path">путь куда сохранить файл</param>
        public void Save(string path)
        {
            using (StreamWriter sw = new StreamWriter(path,true,Encoding.Unicode))
            {
                int i = 0;
                string[] str = new string[index];

                do
                {
                    str = this.note[i].arrNote();
                    if (str[0] == "0") break;

                    if(str[0] != null || str[0] != "0")sw.WriteLine($"{str[0]} \t {str[1]} \t {str[2]} \t {str[3]} \t {str[4]}");

                    i++;
                } while (true);
            }
        }

        /// <summary>
        /// Вывести все записи на экран консоли
        /// </summary>
        public void PrintDbToConsole()
        {
            Console.WriteLine($"{this.titles[0],15} {this.titles[1],15} {this.titles[4],15} {this.titles[2],15} {this.titles[3],10}");

            for (int i = 0; i < index; i++)
            {
                Console.WriteLine(this.note[i].Print());
            }

        }

        public void Test()
        {
            string[] s = Convert.ToString(note[0]).Split(' ');

            for (int i = 0; i < s.Length; i++)
            {
                Console.WriteLine(s[i]);
            }
        }
    }

}
