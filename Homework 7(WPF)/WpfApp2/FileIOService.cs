using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Reflection;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Text.RegularExpressions;


namespace WpfApp2
{
    class FileIOService
    {
        string PATH;
        private readonly MainWindow _mainWindow;

        public FileIOService(string path, MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
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

                using (StreamReader sr = new StreamReader(PATH, Encoding.GetEncoding(1251)))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        array = line.Split(',').ToArray();
                       _mainWindow.Blist.Add(new OnePageList(Convert.ToDateTime(array[0]), Convert.ToBoolean(array[1]),
                    array[2], Convert.ToDateTime(array[3]), array[4]));
                    }

                    if (line == null)
                    {
                        _mainWindow.Blist.Add(new OnePageList(DateTime.Now, false,
                        "text", DateTime.Now, "text"));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return _mainWindow.Blist;
        }
        
        public void SaveData(object todoDataList, string PATH)
        {
            //using (StreamWriter writer = File.CreateText(PATH))
            using (StreamWriter writer = new StreamWriter(PATH, false, Encoding.GetEncoding(1251)))
            {
                string[] array = new string[5];

                for (int i = 0; i < _mainWindow.Blist.Count; i++)
                {
                    array[0] = Convert.ToString(_mainWindow.Blist[i].CreationDate);
                    array[1] = Convert.ToString(_mainWindow.Blist[i].IsDone);
                    array[2] = _mainWindow.Blist[i].Todo;
                    array[3] = Convert.ToString(_mainWindow.Blist[i].Deadline);
                    array[4] = _mainWindow.Blist[i].Description;

                    writer.WriteLine(array[0] + "," + array[1] + "," + array[2] + "," + array[3] + "," + array[4]);
                }
            }

        }
    }
}
