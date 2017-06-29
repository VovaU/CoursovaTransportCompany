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
    /// Логика взаимодействия для CreateNewPassenger.xaml
    /// </summary>
    public partial class CreateNewPassenger : Window
    {
        public CreateNewPassenger()
        {
            InitializeComponent();
        }



        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }

        public string MyName
        {
            get
            {
                string str = textBox.Text;
                if (str.Length < 1) str = "Anonimous";
                return str;
            }
        }
        public int TypeOfMicroObject
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
                else
                {
                    return 3;
                }
            }
        }
        public int MyYears
        {
            get
            {
                int d;
                try
                {
                    d = Convert.ToInt32(textBox1.Text);
                }
                catch (Exception e)
                {
                    d = 20;
                }
                return d;

            }
        }
        public int? NumbersOfTrips
        {
            get
            {
                int? d;
                if (radioButton2.IsChecked == true)
                {
                    return null;
                }
                try
                {
                    d = Convert.ToInt32(textBox7_Copy.Text);
                }
                catch (Exception e)
                {
                    d = 10;
                }
                return d;

            }
        }


        public double Cash
        {
            get
            {
                double d;
                try
                {
                    d = Convert.ToDouble(textBox2.Text);
                }
                catch (Exception e)
                {
                    d = 100.0;
                }
                return d;
            }
        }


        public int X
        {
            get
            {
                int _x;
                try
                {
                    _x = Convert.ToInt32(textBox3.Text);
                }
                catch (Exception e)
                {
                    _x = MainWindow.rnd.Next(100,500);
                }
                return _x;
            }
        }

        public int Y
        {
            get
            {
                int _y;
                try
                {
                    _y = Convert.ToInt32(textBox4.Text);
                }
                catch (Exception e)
                {
                    _y = MainWindow.rnd.Next(100, 500);
                }
                return _y;
            }
        }

        public bool Active
        {
            get
            {
                if (checkBox.IsChecked == true)
                    return true;
                else return false;
            }
        }
        public string TypeOfPREFERNTIAL
        {
            get
            {
                if (listBox.SelectedValue != null)
                {
                    return ((ListBoxItem)listBox.SelectedItem).Content.ToString();
                }
                else return "School Boy";
            }
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void radioButton_Checked(object sender, RoutedEventArgs e)
        {
            label6.Visibility = Visibility.Hidden;
            textBox7_Copy.Visibility = Visibility.Hidden;
            label1.Visibility = Visibility.Hidden;
            textBox2.Visibility = Visibility.Hidden;
            try
            {
                label1_Copy1.Visibility = Visibility.Hidden;
                listBox.Visibility = Visibility.Hidden;
            }
            catch (Exception exception)
            {
               // //Console.WriteLine(exception);
               // throw;
            }
         
        }
        private void radioButton1_Checked(object sender, RoutedEventArgs e)
        {
            label6.Visibility = Visibility.Visible;
            textBox7_Copy.Visibility = Visibility.Visible;
            label1.Visibility = Visibility.Visible;
            textBox2.Visibility = Visibility.Visible;
            label1_Copy1.Visibility = Visibility.Hidden;
            listBox.Visibility = Visibility.Hidden;

        }

        private void radioButton2_Checked(object sender, RoutedEventArgs e)
        {
            label6.Visibility = Visibility.Hidden;
            textBox7_Copy.Visibility = Visibility.Hidden;
            label1.Visibility = Visibility.Visible;
            textBox2.Visibility = Visibility.Visible;
            label1_Copy1.Visibility = Visibility.Visible;
            listBox.Visibility = Visibility.Visible;
        }

        private void textBox7_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
    /*public class ButtonHelper
    {
        // Boilerplate code to register attached property "bool? DialogResult"
        public static bool? GetDialogResult(DependencyObject obj) { return (bool?)obj.GetValue(DialogResultProperty); }
        public static void SetDialogResult(DependencyObject obj, bool? value) { obj.SetValue(DialogResultProperty, value); }
        public static readonly DependencyProperty DialogResultProperty = DependencyProperty.RegisterAttached("DialogResult", typeof(bool?), typeof(ButtonHelper), new UIPropertyMetadata
        {
            PropertyChangedCallback = (obj, e) =>
            {
                // Implementation of DialogResult functionality
                Button button = obj as Button;
                if (button == null)
                    throw new InvalidOperationException(
                      "Can only use ButtonHelper.DialogResult on a Button control");
                button.Click += (sender, e2) =>
                {
                    Window.GetWindow(button).DialogResult = GetDialogResult(button);
                };
            }
        });
    }*/
}
