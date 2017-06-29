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
using System.Windows.Shapes;

namespace WpfApplication7
{
    /// <summary>
    /// Логика взаимодействия для ChooseStation.xaml
    /// </summary>
    public partial class ChooseStation : Window
    {
        public ChooseStation()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }
        public string MyStation
        {
            get
            {
                string str = textBox.Text;
                if (str.Length < 1) str = "0";
                return str;
            }
        }

    }
}
