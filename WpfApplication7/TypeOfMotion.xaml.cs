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
    /// Логика взаимодействия для TypeOfMotion.xaml
    /// </summary>
    public partial class TypeOfMotion : Window
    {
        public TypeOfMotion()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
        public int TypeOf
        {
            get
            {
                if (radioButton.IsChecked == true)
                {
                    return 1;
                }
                if (radioButton1.IsChecked == true)
                {
                    return 2;
                }
                if (radioButton2.IsChecked == true)
                {
                    return 3;
                }
                else
                {
                    return 4;
                }
            }
        }
    }
}
