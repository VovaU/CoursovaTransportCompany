using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Microsoft.Win32;

namespace WpfApplication7
{
    public partial class MainWindow : Window
    {
        private TransportCompany transportCompany;
        public static Random rnd = new Random();
        DispatcherTimer MiniMapTimer = new DispatcherTimer();
        private void MiniMapTimer_Tick(object sender, EventArgs e)
        {
            miniMap.Children.Clear();
            MainCanvas.Children.Remove(rect);
            MainCanvas.Children.Remove(rect121);
            foreach (UIElement child in MainCanvas.Children)
            {
                var xaml = System.Windows.Markup.XamlWriter.Save(child);
                var deepCopy = System.Windows.Markup.XamlReader.Parse(xaml) as UIElement;
                miniMap.Children.Add(deepCopy);
            }
            MainCanvas.Children.Add(rect);
            MainCanvas.Children.Add(rect121);
            Image passengerImage = new Image();
            BitmapImage ActiveImage = new BitmapImage();
            ActiveImage.BeginInit();
            ActiveImage.UriSource = new Uri(@"/WpfApplication7;component/Resources/resizedTrall.png", UriKind.Relative);
            ActiveImage.EndInit();
            BitmapImage ActiveImage1 = new BitmapImage();
            ActiveImage1.BeginInit();
            ActiveImage1.UriSource = new Uri(@"/WpfApplication7;component/Resources/resizeTram.png", UriKind.Relative);
            ActiveImage1.EndInit();
            passengerImage.Source = ActiveImage;
            Canvas.SetLeft(passengerImage, Canvas.GetLeft(rect));
            Canvas.SetTop(passengerImage, Canvas.GetTop(rect));
            miniMap.Children.Add(passengerImage);
            {
                Image redImage = new Image();
                redImage.Source = ActiveImage1;
                Canvas.SetLeft(redImage, Canvas.GetLeft(rect121));
                Canvas.SetTop(redImage, Canvas.GetTop(rect121));
                miniMap.Children.Add(redImage);

            }
        }

        public MainWindow()
        {
           
            InitializeComponent();
            List<Storyboard> storyboards=new List<Storyboard>();
            storyboards.Add(TryFindResource("storyboard") as Storyboard);
            storyboards.Add(TryFindResource("storyboardRed") as Storyboard);
            transportCompany =new TransportCompany(storyboards);
            MiniMapTimer.Tick += new EventHandler(MiniMapTimer_Tick);
            MiniMapTimer.Interval = new TimeSpan(0,0,0,0,1);
            MiniMapTimer.Start();
            Application.Current.MainWindow.KeyDown += new KeyEventHandler(MainCanvas_KeyDown);
     
        }
        private void MainCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)//
        {
            transportCompany.LeftButton();
        }

        private void MainCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            transportCompany.KeyDown( e);
            if (e.Key == Key.K)
            {

            }
            if (e.Key == Key.L)
            {


            }
        }
        private void miniMap_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)//ETO NADO NEED!!!!!!!!
        {
            var windowPosition = Mouse.GetPosition(miniMap);
            ScrollViewer.ScrollToVerticalOffset(windowPosition.Y - 375);
            ScrollViewer.ScrollToHorizontalOffset(windowPosition.X - 750);
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void MainCanvas_KeyUp(object sender, KeyEventArgs e)
        {
            
        }
        private void ScrollViewer_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
        private void Viewbox_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog1 =
                new OpenFileDialog();

            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.RestoreDirectory = false;

            if (openFileDialog1.ShowDialog() == true)
            {
                string fileToRead = openFileDialog1.FileName;
                StreamReader myReader = new StreamReader(fileToRead);
                transportCompany.Load(myReader);
                myReader.Close();
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
                Save();
        }

        public void Save()
        {
            SaveFileDialog saveFileDialog1 =
new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.RestoreDirectory = false;

            if (saveFileDialog1.ShowDialog() == true)
            {
                string fileToWrite = saveFileDialog1.FileName;
                StreamWriter myWriter =
                    new StreamWriter(fileToWrite);
                transportCompany.PassangerSave(myWriter);
                transportCompany.TransportSave(myWriter);
                myWriter.Close();
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

}

 
