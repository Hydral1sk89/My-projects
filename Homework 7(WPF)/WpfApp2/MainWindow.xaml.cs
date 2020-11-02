using System;
using System.Collections.Generic;
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

        List<OnePageList> OnePageList;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            File.CreateText(@"1.csv").Dispose();
            new List<OnePageList>();
            dgTodoList.ItemsSource = OnePageList;
        }

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
    }
}
