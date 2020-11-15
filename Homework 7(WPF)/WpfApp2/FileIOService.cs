using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    class FileIOService
    {
        MainWindow B = new MainWindow();

        private readonly string PATH;

        public FileIOService(string path)
        {
            PATH = path;
        }

        public BindingList<OnePageList> LoadData()
        {
            var fileExists = File.Exists(PATH);

            //Если файл не создан то создаем пустой файл
            if (!fileExists)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<OnePageList>();
            }
            
            string[] array;

            using (StreamReader sr = new StreamReader(PATH))
            {
                string line;

                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    array = line.Split(',').ToArray();

                    B.AddBlist(array);
                }

            }

            return new BindingList<OnePageList>();
        }

        public void SaveData(object todoDataList)
        {
            //using (StreamWriter writer = File.CreateText(PATH))
            //{
            //    string output = JsonConvert.SerializeObject(todoDataList);
            //    writer.Write(output);
            //}

        }
    }
}
