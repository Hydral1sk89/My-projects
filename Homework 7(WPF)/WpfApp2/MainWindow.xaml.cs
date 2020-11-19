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

            try
            {
                Blist = _fileIOService.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }

            //добавляет заполненную строку на экран приложения
            dgTodoList.ItemsSource = Blist;

            //Подписываемся на событие
            Blist.ListChanged += _todoDataList_ListChanged;

            MessageBox.Show(Convert.ToString(Blist.Count));
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
                Blist = new BindingList<OnePageList>() {
                new OnePageList(DateTime.Now, false, "сделать домашку", DateTime.Now, "мне необходимо сдлать домашнюю работу"),
                new OnePageList(DateTime.Now, false, "сделать домашку", DateTime.Now, "мне необходимо сдлать домашнюю работу")
                
            };
                MessageBox.Show("change");
                dgTodoList.ItemsSource = Blist;
                MessageBox.Show(Convert.ToString(Blist.Count));
                //try
                //{
                //    _fileIOService.SaveData(sender);
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //    Close();
                //}
            }
        }

        #region Обработка кнопок меню
        //filedialog - это "проводник"

        void File_Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Filter = "CSV Files|*.csv";
            fileDialog.DefaultExt = ".csv";
            Nullable<bool> dialogOK = fileDialog.ShowDialog();

            if (dialogOK == true)
            {
                string sFileNames = "";

                foreach (string sFileName in fileDialog.FileNames)
                {
                    sFileNames += ";" + sFileName;
                }

                sFileNames = sFileNames.Substring(1);
            }
        }

        void File_Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "CSV Files|*.csv";
            fileDialog.DefaultExt = ".csv";
            Nullable<bool> dialogOK = fileDialog.ShowDialog();

            if (dialogOK == true)
            {
                string sFileNames = "";

                foreach (string sFileName in fileDialog.FileNames)
                {
                    sFileNames += ";" + sFileName;
                }

                sFileNames = sFileNames.Substring(1);
            }
        }

        void File_Import_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Filter = "CSV Files|*.csv";
            fileDialog.DefaultExt = ".csv";
            Nullable<bool> dialogOK = fileDialog.ShowDialog();

            if (dialogOK == true)
            {
                string sFileNames = "";

                foreach (string sFileName in fileDialog.FileNames)
                {
                    sFileNames += ";" + sFileName;
                }

                sFileNames = sFileNames.Substring(1);
            }
        }

        void File_Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }
        #endregion
    }
}
