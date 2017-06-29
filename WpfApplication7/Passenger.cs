using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApplication7
{
    class Passenger:IsMicroObjectInMacro
    {
        public virtual void Save(StreamWriter sw)
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
           else { sw.WriteLine(MotionStyle);}
        }
        public virtual void Load(StreamReader sw)
        {
            this.name = sw.ReadLine();
            years = Convert.ToInt32(sw.ReadLine());
            x = Convert.ToInt32(sw.ReadLine());
            y= Convert.ToInt32(sw.ReadLine());
            active=Convert.ToBoolean(sw.ReadLine());
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
        }
        public int? CurrentStation = null;
        public int? NeedStation=null;
        public Color? StationColor=null;
        public bool InTravel = false;
        public object InTransport = false;//object (unboxing v transport company
        public string name;
        public int years;
        public int x, y;
        public bool active = true; 
        public static int imagex = 0;
        public static int imagey = 30;
        public static int imagewx = 40;
        public static int imagewy = 70;
        protected static double textx1 = 20.2;
        protected static double texty1 = -25.4;
        protected static double textx2 = 20.2;
        protected static double texty2 = -10.4;
        public int MotionStyle=0;
        public Passenger(string name = "Vasya Rabbit", int years = 20, int x = 200, int y = 300, bool active = false)
        {
            this.name = name;
            this.years = years;
            this.x = x;
            this.y = y;
            this.active = active;
        }

        public Image passengerImage = new Image();
       public TextBlock NametextBlock = new TextBlock();
        public TextBlock YearstextBlock = new TextBlock();

        public static bool operator /(Passenger obj1, Passenger obj2)
        {
            if (obj1.name != obj2.name)
            {
                Rect rectangle1 = new Rect(obj1.x, obj1.y, Passenger.imagewx, Passenger.imagewy);
                Rect rectangle2 = new Rect(obj2.x, obj2.y, Passenger.imagewx, Passenger.imagewy);
                if (rectangle1.IntersectsWith(rectangle2) && obj1.InTravel == false && obj2.InTravel == false)
                {
                    return true;
                }
            }
            return false;
        }

        public virtual void Draw()
        {
            if (InTravel == false)
            {
                BitmapImage ActiveImage = new BitmapImage();
                ActiveImage.BeginInit();
                ActiveImage.UriSource = new Uri(@"/WpfApplication7;component/Resources/active.png", UriKind.Relative);
                ActiveImage.EndInit();
                BitmapImage PassiveImage = new BitmapImage();
                PassiveImage.BeginInit();
                PassiveImage.UriSource = new Uri(@"/WpfApplication7;component/Resources/passive.png", UriKind.Relative);
                PassiveImage.EndInit();
                passengerImage.Width = Passenger.imagewx;
                passengerImage.Height = Passenger.imagewy;
                Canvas.SetLeft(passengerImage, x);
                Canvas.SetTop(passengerImage, y);

                Canvas.SetLeft(NametextBlock, x + textx1);
                Canvas.SetTop(NametextBlock, y + texty1);
                NametextBlock.Text = name;

                Canvas.SetLeft(YearstextBlock, x + textx2);
                Canvas.SetTop(YearstextBlock, y + texty2);
                YearstextBlock.Text = "Without ticket";
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
                YearstextBlock.Text = "Without ticket";
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
        public void MouseClick(int mx, int my)
        {
    

            if ((mx < x) || (mx > (x + imagewx)) ||
                (my < y) || (my > (y + imagewy)))
            {
                return;
            }
            MotionStyle = 0;
            active = !active;
            if (active == true)
            {
                TypeOfMotion newTypeOfMotion = new TypeOfMotion();
                newTypeOfMotion.ShowDialog();
                if (newTypeOfMotion.DialogResult == true)
                {
                    MotionStyle = newTypeOfMotion.TypeOf;
                }
                }
            
        }
        public int RandomizeStep(int dd)
        {
            if (dd > 1)
                return MainWindow.rnd.Next(1, dd);
            if (dd < -1)
                return -1 * (MainWindow.rnd.Next(1, -dd));

            return dd;
        }
        public void Move(out int dx, out int dy) 
        {
            dx = 0;
            dy = 0;
            if (MotionStyle == 1)
            {
                int rn = MainWindow.rnd.Next(0, 3);
                if (rn == 2)
                {
                    dx = MainWindow.rnd.Next(-14, 14);
                    dy = 2 * dx;
                }
                else if (rn == 1)
                {
                    dx = MainWindow.rnd.Next(-14, 14);
                    dy = Convert.ToInt32(2 / Math.Sqrt(x));
                }
            }
        }
        public void Move(int dx, int dy)
        {
            {
                if (active)
                {
                    x += dx;
                    y += dy;
                    
                      if (x > 10 && x + imagewx <TransportCompany.width && y > 10 && y + imagewy < TransportCompany.height)
                        {
                       }
                       else
                       {
                            x -= dx;
                           y -= dy;
                    }
                    
                }
                else
                {
                    MotionStyle = 0;
                }
            }
        }
        public bool isActive()
        {
            if (active == true) return true;
            else return false;
        }

        public void Remove()
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).MainCanvas.Children.Remove(passengerImage);
            ((MainWindow)System.Windows.Application.Current.MainWindow).MainCanvas.Children.Remove(NametextBlock);
            ((MainWindow)System.Windows.Application.Current.MainWindow).MainCanvas.Children.Remove(YearstextBlock);
        }

        public void SetPosition()
        {
            Canvas.SetLeft(passengerImage, x);
            Canvas.SetTop(passengerImage, y);
        }

        public virtual void OnStation(int Station,int NeededStation,Color colorOfStation)
        {
            InTravel = true;
            CurrentStation = Station;
            NeedStation = NeededStation;
            StationColor = colorOfStation;
            
        }

        public void OutFromTransport()
        {
            x += 50;
            y += 50;
            InTravel = false;
            CurrentStation = null;
            NeedStation = null;
            StationColor = null;
            InTransport = false;
        }
    }

    public interface IsMicroObjectInMacro
    {
        void OutFromTransport();
    }
}



 
