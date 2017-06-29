using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApplication7
{
    class Transport
    {
        public void Save(StreamWriter sw)
        {
            foreach (var VARIABLE in pass)
            {
                VARIABLE.Save(sw);
            }

        }

        public void AddingPassenger(Passenger passenger)
        {
            passenger.InTransport = true;
            if (passenger is PassengerWithSingleTicket)
            {
                (passenger as PassengerWithSingleTicket).TripInTransport(TypeOfTransport);
            }
            pass.Add(passenger);
        }
        public int MaxPassengers;
        public string TypeOfTransport;
        public int InsideCount=0;
        public double x;
        public double y;
        public List<Passenger> pass=new List<Passenger>();
        DispatcherTimer StartPause = new DispatcherTimer();
        public static Transport operator ++(Transport tmp)
        {
            tmp.InsideCount++;
            return tmp;
        }
        public static Transport operator --(Transport tmp)
        {
            tmp.InsideCount--;
            return tmp;
        }
        private Storyboard animation;
        public void StartTrip()
        {
            animation.Begin();
            StartPause.Tick += new EventHandler(StartPause_Tick);
            StartPause.Interval = new TimeSpan(0, 0, 0, 2);
            StartPause.Start();
            animation.Pause();
        }

        public void Stop()
        {
            animation.Stop();
        }
        public void Pause()
        {
            animation.Pause();
        }
        public void Resume()
        {
            animation.Resume();
        }
        public Transport(int MaxPassengers=5, string TypeOfTransport= "Trolleybus", int x=100, int y=100,Storyboard animation=null)
        {
            this.MaxPassengers = MaxPassengers;
            this.TypeOfTransport = TypeOfTransport;
            this.x = x;
            this.y = y;
            this.animation = animation;
        }
        private void StartPause_Tick(object sender, EventArgs e)
        {
            animation.Resume();
            StartPause.Stop();
        }

        public void Draw()
        {
                if (TypeOfTransport == "Tram")
                {
                ((MainWindow)System.Windows.Application.Current.MainWindow).Transport11.Text = TypeOfTransport;
                ((MainWindow)System.Windows.Application.Current.MainWindow).Transport12.Text= Convert.ToString(InsideCount);
            }
            if (TypeOfTransport == "TrolleyBus")
            {
                ((MainWindow) System.Windows.Application.Current.MainWindow).Transport1.Text = TypeOfTransport;
                ((MainWindow) System.Windows.Application.Current.MainWindow).Transport122.Text =Convert.ToString(InsideCount);
            }
            x =Canvas.GetLeft(((MainWindow) System.Windows.Application.Current.MainWindow).rect);
            y = Canvas.GetTop(((MainWindow)System.Windows.Application.Current.MainWindow).rect);
        }
    }
      
        }