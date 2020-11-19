using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp2
{
    class FileIOService
    {
        MainWindow B = new MainWindow();

        string PATH;

        public FileIOService(string path)
        {
            PATH = path;
        }

        public BindingList<OnePageList> LoadData()
        {
            try
            {
                var fileExists = File.Exists(PATH);
                //Если файл не создан то создаем пустой файл
                if (!fileExists)
                {
                    File.CreateText(PATH).Dispose();
                    return new BindingList<OnePageList>() { };
                }

                string[] array;

                using (StreamReader sr = new StreamReader(PATH, Encoding.GetEncoding(1)))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        array = line.Split(',').ToArray();
                        B.Blist.Add(new OnePageList (Convert.ToDateTime(array[0]), Convert.ToBoolean(array[1]),
                    array[2], Convert.ToDateTime(array[3]), array[4]));
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return B.Blist;
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
