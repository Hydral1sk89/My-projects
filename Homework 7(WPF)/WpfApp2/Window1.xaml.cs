using System;
using System.Collections.Generic;
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
using System.IO;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public string sFileNames;

        private Border _srcPanel;
        private readonly MainWindow _mainWindow;

        public Window1(Border srcPanel, MainWindow mainWindow)
        {
            _srcPanel = srcPanel;
            _mainWindow = mainWindow;
            InitializeComponent();
        }

        Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog();

        private void File_Explorer_Click(object sender, RoutedEventArgs e)
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

                    textpath.Text = sFileNames;
                    // /
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        bool creationDate;
        bool deadlineDate;

        private void CreationDate_Checked(object sender, RoutedEventArgs e)
        {
            creationDate = true;
            deadlineDate = false;

            //MessageBox.Show("CreationDate = " + creationDate);
            //MessageBox.Show("deadlineDate = " + deadlineDate);
        }

        private void DeadlineDate_Checked(object sender, RoutedEventArgs e)
        {
            creationDate = false;
            deadlineDate = true;

            //MessageBox.Show("CreationDate = " + creationDate);
            //MessageBox.Show("deadlineDate = " + deadlineDate);
        }
        private void Import_Button_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Import button was pressed");

            string _for = For.Text;
            string _to = To.Text;

            DateTime DateFor = new DateTime();
            DateTime DateTo = new DateTime();

            DateFor = Convert.ToDateTime(_for);
            DateTo = Convert.ToDateTime(_to);

            try
            { 
                string[] array;

                using (StreamReader sr = new StreamReader(sFileNames, Encoding.GetEncoding(1251)))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        array = line.Split(',').ToArray();

                        if (creationDate)
                        {
                            if (DateFor <= Convert.ToDateTime(array[0]) && DateTo >= Convert.ToDateTime(array[0]))
                            {
                                //MessageBox.Show("CreationDate Дата в нужном диапазоне");

                                _mainWindow.Blist.Add(new OnePageList(Convert.ToDateTime(array[0]), Convert.ToBoolean(array[1]),
                            array[2], Convert.ToDateTime(array[3]), array[4]));
                            }
                        }
                        else
                        {
                            if (DateFor <= Convert.ToDateTime(array[3]) && DateTo >= Convert.ToDateTime(array[3]))
                            {
                                //MessageBox.Show("Deadline Дата в нужном диапазоне");

                                _mainWindow.Blist.Add(new OnePageList(Convert.ToDateTime(array[0]), Convert.ToBoolean(array[1]),
                            array[2], Convert.ToDateTime(array[3]), array[4]));
                            }
                        }
                    }
                }
                _mainWindow.dgTodoList.ItemsSource = _mainWindow.Blist;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            MessageBox.Show("Blist.Count = " + Convert.ToString(_mainWindow.Blist.Count()));
            _mainWindow.dgTodoList.ItemsSource = _mainWindow.Blist;
        }

    }
    
}
