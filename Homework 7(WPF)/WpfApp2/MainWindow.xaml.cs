using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        //объявляем переменную Blist типа BindingList. BindingList нужен потому что в дальнейшем будем использовать метод .ListChanged
        public BindingList<OnePageList> Blist = new BindingList<OnePageList>();
        string PATH = $"{Environment.CurrentDirectory}\\Data.csv";
        FileIOService _fileIOService;


        /// <summary>
        /// код выполняется при запуске приложения
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _fileIOService = new FileIOService(PATH);

            if (Blist.Count < 1)
            {
                Blist.Add(new OnePageList(DateTime.Now, false, "", DateTime.Now, ""));
            }

            //try
            //{
            //    Blist = _fileIOService.LoadData();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    Close();
            //}

            //добавляет заполненную строку на экран приложения
            dgTodoList.ItemsSource = Blist;

            //Подписываемся на событие
            Blist.ListChanged += _todoDataList_ListChanged;

            //MessageBox.Show(Convert.ToString(Blist.Count));
        }

        public BindingList<OnePageList> AddBlist(string[] arr)
        {
            string[] array = arr;

            return new BindingList<OnePageList>() {new OnePageList ( Convert.ToDateTime(array[0]), Convert.ToBoolean(array[1]),
                    array[2], Convert.ToDateTime(array[3]), array[4] )};
        }

        /// <summary>
        /// добавляем ещё одну строку
        /// </summary>
        private void _todoDataList_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged)
            {
                if (Blist.Count < 1)
                {
                    Blist.Add(new OnePageList(DateTime.Now, false,"", DateTime.Now, ""));
                }
                //if((Blist[Blist.Count-1].Description != "") && (Blist[Blist.Count-1].Todo != ""))
                //{
                //    Blist.Add(new OnePageList(DateTime.Now, false, "", DateTime.Now, ""));
                //}

                //    //    Blist = new BindingList<OnePageList>() {
                //    //    new OnePageList(DateTime.Now, false, "сделать домашку", DateTime.Now, "мне необходимо сдлать домашнюю работу"),
                //    //    new OnePageList(DateTime.Now, false, "сделать домашку", DateTime.Now, "мне необходимо сдлать домашнюю работу")

                    //    //};
                    //    //MessageBox.Show("change");
                    //    //dgTodoList.ItemsSource = Blist;
                    //    //MessageBox.Show(Convert.ToString(Blist.Count));
                    //    try
                    //    {
                    //        _fileIOService.SaveData(sender);
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        MessageBox.Show(ex.Message);
                    //        Close();
                    //    }
            }
        }

        #region Обработка кнопок меню
        //filedialog - это "проводник"
        OpenFileDialog fileDialog = new OpenFileDialog();

        void File_Open_Click(object sender, RoutedEventArgs e)
        {


            fileDialog.Multiselect = false;
            fileDialog.Filter = "CSV Files|*.csv";
            fileDialog.DefaultExt = ".csv";

            Nullable<bool> dialogOK = fileDialog.ShowDialog();

            if (dialogOK == true)
            {

                //Очистить Blist
                Blist.Clear();
                
                try
                {
                    //Найти путь к файлу который открыли
                    string sFileNames = "";

                    foreach (string sFileName in fileDialog.FileNames)
                    {
                        sFileNames += ";" + sFileName;
                    }

                    sFileNames = sFileNames.Substring(1);
                    // /

                    string[] array;

                    using (StreamReader sr = new StreamReader(sFileNames, Encoding.GetEncoding(1251)))
                    {
                        string line;

                        while ((line = sr.ReadLine()) != null)
                        {
                            array = line.Split(',').ToArray();
                            Blist.Add(new OnePageList(Convert.ToDateTime(array[0]), Convert.ToBoolean(array[1]),
                        array[2], Convert.ToDateTime(array[3]), array[4]));
                        }
                    }
                    dgTodoList.ItemsSource = Blist;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                //MessageBox.Show("test");

            }
        }

        void File_Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "CSV Files|*.csv";
            saveFileDialog.DefaultExt = ".csv";
            Nullable<bool> sdialogOK = saveFileDialog.ShowDialog();

            if (sdialogOK == true)
            {
                //Перезаписываем файл
                _fileIOService.SaveData(sender, saveFileDialog.FileName);
            }
        }

        //необходимо доделать диапазон импорта (https://www.youtube.com/watch?v=b5K9LXBXUjI&ab_channel=IAmTimCorey)
        void File_Import_Click(object sender, RoutedEventArgs e)
        {
            fileDialog.Multiselect = false;
            fileDialog.Filter = "CSV Files|*.csv";
            fileDialog.DefaultExt = ".csv";

            Nullable<bool> dialogOK = fileDialog.ShowDialog();

            if (dialogOK == true)
            {
                try
                {
                    //Найти путь к файлу который открыли
                    string sFileNames = "";

                    foreach (string sFileName in fileDialog.FileNames)
                    {
                        sFileNames += ";" + sFileName;
                    }

                    sFileNames = sFileNames.Substring(1);
                    // /

                    string[] array;

                    using (StreamReader sr = new StreamReader(sFileNames, Encoding.GetEncoding(1251)))
                    {
                        string line;

                        while ((line = sr.ReadLine()) != null)
                        {
                            array = line.Split(',').ToArray();
                            Blist.Add(new OnePageList(Convert.ToDateTime(array[0]), Convert.ToBoolean(array[1]),
                        array[2], Convert.ToDateTime(array[3]), array[4]));
                        }
                    }
                    dgTodoList.ItemsSource = Blist;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        
        void File_Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }

        void Add_Event_Click(object sender, RoutedEventArgs e)
        {
            Blist.Add(new OnePageList(DateTime.Now, false, "", DateTime.Now, ""));
        }

        void File_New_Click(object sender, RoutedEventArgs e)
        {
            Blist.Clear();
            Blist.Add(new OnePageList(DateTime.Now, false, "", DateTime.Now, ""));
        }

        public string sFileNames = "";

        void File_explorer_Click(object sender, RoutedEventArgs e)
        {
            fileDialog.Multiselect = false;
            fileDialog.Filter = "CSV Files|*.csv";
            fileDialog.DefaultExt = ".csv";

            Nullable<bool> dialogOK = fileDialog.ShowDialog();

            if (dialogOK == true)
            {
                try
                {
                    //Найти путь к файлу который открыли

                    foreach (string sFileName in fileDialog.FileNames)
                    {
                        sFileNames += ";" + sFileName;
                    }

                    sFileNames = sFileNames.Substring(1);
                    // /
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            
        }

        void File_Import_range_Click(object sender, RoutedEventArgs e)
        {
            //Вызываем окно диапазон импорта
            Border panel = sender as Border;
            Window1 popup = new Window1(panel, this);
            popup.ShowDialog();

            //DateTime forDate = new DateTime();
            //DateTime toDate = new DateTime();

            
        }
                #endregion
    }
}
