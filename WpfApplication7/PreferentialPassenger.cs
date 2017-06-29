using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfApplication7
{
    class PreferentialPassenger:PassengerWithSingleTicket//unlimited proezdnoy /i est type of льгота
    {
        public override void Save(StreamWriter sw)
        {
            sw.WriteLine(GetType().Name);
            sw.WriteLine(name);
            sw.WriteLine(years);
            sw.WriteLine(x);
            sw.WriteLine(y);
            sw.WriteLine(active);
            sw.WriteLine(InTravel);
            if (InTravel == true)
            {
                sw.WriteLine(InTransport);
                sw.WriteLine(CurrentStation);
                sw.WriteLine(NeedStation);
                if (StationColor == Colors.Green)
                {
                    sw.WriteLine(1);
                }
                if (StationColor == Colors.Red)
                {
                    sw.WriteLine(2);
                }
            }
            else
            {
                sw.WriteLine(MotionStyle);
            }
            sw.WriteLine(TripInfo.Count);
            foreach (var VARIABLE in TripInfo)
            {
                sw.Write("{0} {1} {2} {3}", VARIABLE.Item1, VARIABLE.Item2, VARIABLE.Item3, VARIABLE.Item4.ToString("HH:mm:ss"));
            }
            sw.WriteLine(cash);
            sw.WriteLine(TypeOfPreferential);
        }
        public override void Load(StreamReader sw)
        {
            name = sw.ReadLine();
            years = Convert.ToInt32(sw.ReadLine());
            x = Convert.ToInt32(sw.ReadLine());
            y = Convert.ToInt32(sw.ReadLine());
            active = Convert.ToBoolean(sw.ReadLine());
            InTravel = Convert.ToBoolean(sw.ReadLine());
            if (InTravel == true)
            {
                InTravel = Convert.ToBoolean(sw.ReadLine());
                InTransport = Convert.ToBoolean(sw.ReadLine());
                CurrentStation = Convert.ToInt32(sw.ReadLine());
                NeedStation = Convert.ToInt32(sw.ReadLine());
                int stStationColor = Convert.ToInt32(sw.ReadLine());
                if (stStationColor == 1)
                {
                    StationColor = Colors.Green;
                }
                if (stStationColor == 2)
                {
                    StationColor = Colors.Red;
                }
            }
            else
            {MotionStyle = Convert.ToInt32(sw.ReadLine());}
            int k = Convert.ToInt32(sw.ReadLine());
            for (int i = 0; i < k; i++)
            {
                String[] words = sw.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                TripInfo.Add(new Tuple<string, int, int, DateTime>(words[0], Convert.ToInt32(words[1]), Convert.ToInt32(words[2]), Convert.ToDateTime(words[3])));
            }
            cash = Convert.ToDouble(sw.ReadLine());
            TypeOfPreferential = sw.ReadLine();
            WriteStatistic2();
        }
        public PreferentialPassenger(string name = "Petro Sagajdachnyj", int years = 20, int x = 500, int y = 100,
        bool active = false,double cash = 100.0, string TypeOfPreferential = "School Boy") 
        {
            this.name = name;
            this.years = years;
            this.x = x;
            this.y = y;
            this.active = active;
            this.cash = cash;
            this.TypeOfPreferential = TypeOfPreferential;
            
        }

        public override object Clone()
        {
   
           PreferentialPassenger tmp = new PreferentialPassenger();
            //      tmp = (PassengerWithSingleTicket)this.MemberwiseClone();
            tmp.name = this.name;
            tmp.x = this.x;
            tmp.y = this.y;
            tmp.years = this.years;
            tmp.active = this.active;
            tmp.cash = this.cash;
            tmp.TypeOfPreferential = this.TypeOfPreferential;
            foreach (var VARIABLE in TripInfo)
            {
                    tmp.TripInfo.Add(new Tuple<string, int, int, DateTime>(VARIABLE.Item1, VARIABLE.Item2, VARIABLE.Item3, VARIABLE.Item4));
            }
            return tmp;
        
    }

        public string TypeOfPreferential;
        public override void Draw()
        {
            if (InTravel == false)
            {
                BitmapImage ActiveImage = new BitmapImage();
                ActiveImage.BeginInit();
                ActiveImage.UriSource = new Uri(@"/WpfApplication7;component/Resources/activeseason.png",
                    UriKind.Relative);
                ActiveImage.EndInit();
                BitmapImage PassiveImage = new BitmapImage();
                PassiveImage.BeginInit();
                PassiveImage.UriSource = new Uri(@"/WpfApplication7;component/Resources/passuveseason.png",
                    UriKind.Relative);
                PassiveImage.EndInit();
                passengerImage.Width = (int)Passenger.imagewx;
                passengerImage.Height = (int)Passenger.imagewy;
                Canvas.SetLeft(passengerImage, x);
                Canvas.SetTop(passengerImage, y);

                Canvas.SetLeft(NametextBlock, x + textx1);
                Canvas.SetTop(NametextBlock, y + texty1);
                NametextBlock.Text = name;

                Canvas.SetLeft(YearstextBlock, x + textx2);
                Canvas.SetTop(YearstextBlock, y + texty2);
                YearstextBlock.Text = TypeOfPreferential;
                if (active)
                {
                    passengerImage.Source = ActiveImage;
                    NametextBlock.Foreground = new SolidColorBrush(Colors.OrangeRed);
                    YearstextBlock.Foreground = new SolidColorBrush(Colors.Fuchsia);

                }
                if (active == false)
                {
                    passengerImage.Source = PassiveImage;
                    NametextBlock.Foreground = new SolidColorBrush(Colors.BlueViolet);
                    YearstextBlock.Foreground = new SolidColorBrush(Colors.RoyalBlue);

                }
                try
                {
                    ((MainWindow) System.Windows.Application.Current.MainWindow).MainCanvas.Children.Remove(
                        passengerImage);
                    ((MainWindow) System.Windows.Application.Current.MainWindow).MainCanvas.Children.Remove(
                        NametextBlock);
                    ((MainWindow) System.Windows.Application.Current.MainWindow).MainCanvas.Children.Remove(
                        YearstextBlock);
                }
                catch (Exception e)
                {

                }
                ((MainWindow) System.Windows.Application.Current.MainWindow).MainCanvas.Children.Add(passengerImage);
                ((MainWindow) System.Windows.Application.Current.MainWindow).MainCanvas.Children.Add(NametextBlock);
                ((MainWindow) System.Windows.Application.Current.MainWindow).MainCanvas.Children.Add(YearstextBlock);
            }
            if (InTravel == true)
            {
         
                Canvas.SetLeft(NametextBlock, x + textx1+50);
                Canvas.SetTop(NametextBlock, y + texty1);
                NametextBlock.Text = name;

                Canvas.SetLeft(YearstextBlock, x + textx2+50);
                Canvas.SetTop(YearstextBlock, y + texty2);
                YearstextBlock.Text = TypeOfPreferential;
                    NametextBlock.Foreground = new SolidColorBrush(Colors.OrangeRed);
                    YearstextBlock.Foreground = new SolidColorBrush(Colors.Fuchsia);

                try
                {
                    ((MainWindow)System.Windows.Application.Current.MainWindow).MainCanvas.Children.Remove(
                        passengerImage);
                    ((MainWindow)System.Windows.Application.Current.MainWindow).MainCanvas.Children.Remove(
                        NametextBlock);
                    ((MainWindow)System.Windows.Application.Current.MainWindow).MainCanvas.Children.Remove(
                        YearstextBlock);
                }
                catch (Exception e)
                {

                }
                ((MainWindow)System.Windows.Application.Current.MainWindow).MainCanvas.Children.Add(NametextBlock);
                ((MainWindow)System.Windows.Application.Current.MainWindow).MainCanvas.Children.Add(YearstextBlock);
            }
        }

    }
}
