using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace WpfApplication7
{
    class PassengerWithSingleTicket:Passenger,ICloneable
    {
        //
       
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
            {            sw.WriteLine(MotionStyle);}
            sw.WriteLine(TripInfo.Count);
            foreach (var VARIABLE in TripInfo)
            {
                sw.WriteLine("{0} {1} {2} {3}",VARIABLE.Item1,VARIABLE.Item2,VARIABLE.Item3,VARIABLE.Item4.ToString("HH:mm:ss"));
            }
            sw.WriteLine(NumbersOfTripsLeft);
            sw.WriteLine(NumbersOfTripsUsed);
        sw.WriteLine(cash);
        }
        public override void Load(StreamReader sw)
{
    this.name = sw.ReadLine();
    years = Convert.ToInt32(sw.ReadLine());
    x = Convert.ToInt32(sw.ReadLine());
    y = Convert.ToInt32(sw.ReadLine());
    active = Convert.ToBoolean(sw.ReadLine());
    InTravel = Convert.ToBoolean(sw.ReadLine());
    if (InTravel == true)
    {
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
    {
        MotionStyle = Convert.ToInt32(sw.ReadLine());
    }
    int k = Convert.ToInt32(sw.ReadLine());
    for (int i = 0; i < k; i++)
    {
              String[] words = sw.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
              TripInfo.Add(new Tuple<string, int, int, DateTime>(words[0],Convert.ToInt32(words[1]), Convert.ToInt32(words[2]), Convert.ToDateTime(words[3])));
     }
    NumbersOfTripsLeft = Convert.ToInt32(sw.ReadLine());
    NumbersOfTripsUsed = Convert.ToInt32(sw.ReadLine());
    cash = Convert.ToDouble(sw.ReadLine());
    WriteStatistic2();
}
public override void OnStation(int Station, int NeededStation, Color colorOfStation)
        {
            InTravel = true;
            CurrentStation = Station;
            NeedStation = NeededStation;
            StationColor = colorOfStation;
            if (StationColor == Colors.Green)
            {
                TripInfo.Add(new Tuple<string, int, int, DateTime>("TrolleyBus", Station, NeededStation, DateTime.Now));
            }
            if (StationColor == Colors.Red)
            {
                TripInfo.Add(new Tuple<string, int, int, DateTime>("Tram", Station, NeededStation, DateTime.Now));
            }
            WriteStatistic();
        }
        public void WriteStatistic()
        {
       
            if(TripInfo.Count>2)
                TripInfo.RemoveAt(TripInfo.Count-2);
            ((MainWindow) System.Windows.Application.Current.MainWindow).textBox.Text = " ";
            foreach (var VARIABLE in TripInfo)
            {
                ((MainWindow) System.Windows.Application.Current.MainWindow).textBox.Text += VARIABLE.Item1+" ";
                ((MainWindow)System.Windows.Application.Current.MainWindow).textBox.Text += VARIABLE.Item2 + " ";
                ((MainWindow)System.Windows.Application.Current.MainWindow).textBox.Text += VARIABLE.Item3 + " ";

                ((MainWindow)System.Windows.Application.Current.MainWindow).textBox.Text += VARIABLE.Item4.ToString("HH:mm:ss") + "\n";
            }
            
        }

        public void WriteStatistic2()
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).textBox.Text = " ";
            foreach (var VARIABLE in TripInfo)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).textBox.Text += VARIABLE.Item1 + " ";
                ((MainWindow)System.Windows.Application.Current.MainWindow).textBox.Text += VARIABLE.Item2 + " ";
                ((MainWindow)System.Windows.Application.Current.MainWindow).textBox.Text += VARIABLE.Item3 + " ";

                ((MainWindow)System.Windows.Application.Current.MainWindow).textBox.Text += VARIABLE.Item4.ToString("HH:mm:ss") + "\n";
            }
        }
        public PassengerWithSingleTicket(string name = "Oscar Willson", int years = 20, int x = 400, int y = 500,
            bool active = false,
             int? NumbersOfTripsLeft = 10, double cash = 100.0) : base(name, years, x, y, active)
        { 
            this.NumbersOfTripsLeft = NumbersOfTripsLeft;
            this.cash = cash;
        }
        protected int? NumbersOfTripsLeft;
        protected int NumbersOfTripsUsed = 0;
        public object cash;
     public   List<Tuple<string,int,int,DateTime>> TripInfo=new List<Tuple<string,int,int,DateTime>>();

        public void TripInTransport(string typeOfTransport)
        {
            NumbersOfTripsLeft--;
            NumbersOfTripsUsed++;

        }

        public static bool operator ==(PassengerWithSingleTicket obj1, PassengerWithSingleTicket obj2)
        {
            if (obj1.name == obj2.name && obj1.cash==obj2.cash && obj1.NumbersOfTripsLeft==obj2.NumbersOfTripsLeft) return true;

            return false;
        }
        public static bool operator !=(PassengerWithSingleTicket obj1, PassengerWithSingleTicket obj2)
        {
            if (obj1.name != obj2.name || obj1.cash != obj2.cash || obj1.NumbersOfTripsLeft == obj2.NumbersOfTripsLeft) return true;

            return false;
        }
        public virtual object Clone()
        {
            PassengerWithSingleTicket tmp = new PassengerWithSingleTicket();
            tmp.name = this.name;
            tmp.x = this.x;
            tmp.y = this.y;
            tmp.NumbersOfTripsLeft = this.NumbersOfTripsLeft;
            tmp.years = this.years;
            tmp.active = this.active;
            tmp.cash = this.cash;
            tmp.NumbersOfTripsUsed = this.NumbersOfTripsUsed;
            foreach (var VARIABLE in TripInfo)
            {
                tmp.TripInfo.Add(new Tuple<string, int, int, DateTime>(VARIABLE.Item1, VARIABLE.Item2, VARIABLE.Item3, VARIABLE.Item4));
            }
            return tmp;
        }

        public override void Draw()
        {
            if (InTravel == false)
            {
                BitmapImage ActiveImage = new BitmapImage();
                ActiveImage.BeginInit();
                ActiveImage.UriSource = new Uri(@"/WpfApplication7;component/Resources/SingleTicketActive.png",
                    UriKind.Relative);
                ActiveImage.EndInit();
                BitmapImage PassiveImage = new BitmapImage();
                PassiveImage.BeginInit();
                PassiveImage.UriSource = new Uri(@"/WpfApplication7;component/Resources/SingleTicketPassive.png",
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
                YearstextBlock.Text = NumbersOfTripsLeft + " tickets left";
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
                YearstextBlock.Text = NumbersOfTripsLeft + " tickets left";
                    NametextBlock.Foreground = new SolidColorBrush(Colors.OrangeRed);
                    YearstextBlock.Foreground = new SolidColorBrush(Colors.Fuchsia);

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
                ((MainWindow)System.Windows.Application.Current.MainWindow).MainCanvas.Children.Add(NametextBlock);
                ((MainWindow)System.Windows.Application.Current.MainWindow).MainCanvas.Children.Add(YearstextBlock);
            }
        }
    }
}
