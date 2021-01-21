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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        

        private Border _srcPanel; 

        public Window1(Border srcPanel)
        {
            _srcPanel = srcPanel;

            InitializeComponent();
        }

        public Window1()
        {
            InitializeComponent();

            textpath.Text = 
        }
    }
}
