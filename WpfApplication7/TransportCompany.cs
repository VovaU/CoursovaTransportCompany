using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApplication7
{
    class TransportCompany
    {
        public delegate void TimerDef(object sender, EventArgs e);
        public delegate void AddInTransport(Passenger  p);
        public event TimerDef Added;
        public int CountOfTransport;
        public string Title;
        private bool WasPaused = false;
        public static double width;
        public static double height;
        public List<Passenger> passengers;
        public List<Transport> Transports;// 
        //red 
        #region PointOfStationForTransport 
        protected List<Point> GreenPointInBackward = new List<Point>(new Point[]
            {
                new Point(5650,945),  new Point(5070, 1529), new Point(4511, 2083), new Point(4000, 2620), new Point(2875, 2850),
                new Point(2028, 2847), new Point(1179, 2743), new Point(919, 2319),
                new Point(595, 1659), new Point(500, 1381), new Point(500, 847),
                new Point(500, 424),new Point(500,25)
            });
        protected List<Point> GreenPointInForward = new List<Point>(new Point[]
            {
                new Point(450, 25), new Point(450, 419), new Point(450, 829), new Point(450, 1358),
                new Point(584, 1767), new Point(862, 2307), new Point(1108, 2728),
                new Point(2002, 2892), new Point(2918, 2900), new Point(3983, 2647),
                new Point(4535, 2121), new Point(5108, 1561), new Point(5728, 875)
            });
        protected List<Point> RedPointInBackward = new List<Point>(new Point[]
            {
             new Point(2745,1254), new Point(3460,1272), new Point(3460,2175), new Point(2200,2245), new Point(2144,1086),
                new Point(1440,625),new Point(1011,268)
            });
        //
        protected List<Point> RedPointInForward = new List<Point>(new Point[]
        {
             new Point(987, 298), new Point(1409, 657),new Point(2145, 1145), new Point(2145, 2210),
            new Point(3500, 2276), new Point(3446, 1210), new Point(2800, 1210)
        });
        #endregion
        public List<Point> RedBufferArrayOfStations=new List<Point>();
        public List<Point> GreenBufferArrayOfStations = new List<Point>();
        #region Stations
        private List<Ellipse> GreenStation=new List<Ellipse>()
        {
           ((MainWindow)Application.Current.MainWindow).Green0,((MainWindow)Application.Current.MainWindow).Green1,((MainWindow)Application.Current.MainWindow).Green2,
           ((MainWindow)Application.Current.MainWindow).Green3,((MainWindow)Application.Current.MainWindow).Green4,((MainWindow)Application.Current.MainWindow).Green5,
           ((MainWindow)Application.Current.MainWindow).Green6,((MainWindow)Application.Current.MainWindow).Green7,((MainWindow)Application.Current.MainWindow).Green8
           ,((MainWindow)Application.Current.MainWindow).Green9,((MainWindow)Application.Current.MainWindow).Green10,((MainWindow)Application.Current.MainWindow).Green11,
           ((MainWindow)Application.Current.MainWindow).Green12
        };
        private List<Ellipse> RedStation=new List<Ellipse>()
        {
            ((MainWindow)Application.Current.MainWindow).Red0,((MainWindow)Application.Current.MainWindow).Red1,
            ((MainWindow)Application.Current.MainWindow).Red2,((MainWindow)Application.Current.MainWindow).Red3,
            ((MainWindow)Application.Current.MainWindow).Red4,((MainWindow)Application.Current.MainWindow).Red5,
            ((MainWindow)Application.Current.MainWindow).Red6
        };
        #endregion
        DispatcherTimer StationTimer = new DispatcherTimer();
        DispatcherTimer dispatcherTimer1 = new DispatcherTimer();
        DispatcherTimer dispatcherTimer2 = new DispatcherTimer();
        DispatcherTimer dispatcherTimer1RED = new DispatcherTimer();
        DispatcherTimer dispatcherTimer2RED = new DispatcherTimer();
        DispatcherTimer OnStation = new DispatcherTimer();
        public TransportCompany(List<Storyboard> storyboard)
        {

                Title = "Tram and others Company";
                Transports =new List<Transport>();
               Transports.Add(new Transport(4,"Tram",100,500, storyboard[0]));
                Transports.Add(new Transport(5, "TrolleyBus", 100,300, storyboard[1]));
            CountOfTransport = Transports.Count;
                GreenBufferArrayOfStations.AddRange(GreenPointInForward);
                GreenBufferArrayOfStations.AddRange(GreenPointInBackward);
                RedBufferArrayOfStations.AddRange(RedPointInForward);
                RedBufferArrayOfStations.AddRange(RedPointInBackward);
                passengers = new List<Passenger>();
                passengers.Add(new Passenger());
                passengers.Add(new PassengerWithSingleTicket());
                passengers.Add(new PreferentialPassenger());
            width = ((MainWindow) System.Windows.Application.Current.MainWindow).MainCanvas.Width;
            height = ((MainWindow)System.Windows.Application.Current.MainWindow).MainCanvas.Height;
            foreach (var VARIABLE in Transports)
                {
                    VARIABLE.Draw();
                    VARIABLE.StartTrip();
                }
                foreach (var VARIABLE in passengers)
                {
                    VARIABLE.Draw();
                }
            //      StationTimer.Tick += new EventHandler(StationTimer_Tick);
            //    StationTimer.Tick += new EventHandler(OnStation_Tick);
            Added += StationTimer_Tick;
            Added += OnStation_Tick;
            StationTimer.Tick += new EventHandler(Added);
            StationTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
                StationTimer.Start();

        }
        public void CheckIfONGreenStation()
        {
            if ((int)Canvas.GetLeft(((MainWindow)System.Windows.Application.Current.MainWindow).rect) >= (int)GreenBufferArrayOfStations[0].X - 50 &&
    (int)Canvas.GetLeft(((MainWindow)System.Windows.Application.Current.MainWindow).rect) <= (int)GreenBufferArrayOfStations[0].X + 50 &&
    (int)Canvas.GetTop(((MainWindow)System.Windows.Application.Current.MainWindow).rect) >= (int)GreenBufferArrayOfStations[0].Y - 50 &&
    (int)Canvas.GetTop(((MainWindow)System.Windows.Application.Current.MainWindow).rect) <= (int)GreenBufferArrayOfStations[0].Y + 50)
            {
                foreach (var VARIABLE in passengers.ToArray())
                {
         
                    if (VARIABLE.InTravel == true && (bool)VARIABLE.InTransport == false && VARIABLE.StationColor == Colors.Green)
                    {
                        if (GreenBufferArrayOfStations[0] == GreenPointInForward[(int)VARIABLE.CurrentStation])
                        {
                            AddInTransport bo = Transports[0].AddingPassenger;
                            IAsyncResult ar = bo.BeginInvoke(VARIABLE, null, null);
                            Transports[0]++;
                            passengers.Remove(VARIABLE);
                        }
                        List<Point> buffer = new List<Point>();
                        buffer.AddRange(GreenPointInBackward);
                        buffer.Reverse();
                       // if ((int)VARIABLE.NeedStation != 12 && (int)VARIABLE.NeedStation != 0)
                            if (GreenBufferArrayOfStations[0] == buffer[(int)VARIABLE.CurrentStation])
                        {
                            AddInTransport bo = Transports[0].AddingPassenger;
                            IAsyncResult ar = bo.BeginInvoke(VARIABLE, null, null);
                            Transports[0]++;

                            passengers.Remove(VARIABLE);
                        } 
                    }
                }
                if (Transports[0].pass.Count != 0)
                {
                    List<Point> buffer = new List<Point>();
                    buffer.AddRange( GreenPointInBackward);
                    buffer.Reverse();
                    foreach (var VARIABLE in Transports[0].pass.ToArray())
                    {
                        if (GreenBufferArrayOfStations[0] == GreenPointInForward[(int)VARIABLE.NeedStation])
                        {
                            VARIABLE.OutFromTransport();
                            Transports[0].pass.Remove(VARIABLE);
                            Transports[0]--;
                            passengers.Add(VARIABLE);
                            VARIABLE.x -= 200;
                            VARIABLE.y +=200;
                            VARIABLE.Draw();

                        }
                        else
                        {
                            //if ((int)VARIABLE.NeedStation != 12 && (int)VARIABLE.NeedStation != 0)
                                if (GreenBufferArrayOfStations[0] == buffer[(int)VARIABLE.NeedStation])
                            {
                                VARIABLE.OutFromTransport();
                                Transports[0].pass.Remove(VARIABLE);
                                Transports[0]--;
                                passengers.Add(VARIABLE);
                                VARIABLE.x -= 200;
                                VARIABLE.y += 200;
                                VARIABLE.Draw();

                            }
                        }

                    }
                }
                dispatcherTimer1.Tick += new EventHandler(dispatcherTimer1_Tick);
                dispatcherTimer1.Interval = new TimeSpan(0, 0, 0, 0, 1);
                dispatcherTimer1.Start();
                GreenBufferArrayOfStations.RemoveAt(0);
            }
            if (GreenBufferArrayOfStations.Count == 0)
            {
                GreenBufferArrayOfStations.AddRange(GreenPointInForward);
                GreenBufferArrayOfStations.AddRange(GreenPointInBackward);
            }
        }
        public void CheckIfONRedStation()
        {
            {
                if ((int)Canvas.GetLeft(((MainWindow)System.Windows.Application.Current.MainWindow).rect121) >= (int)RedBufferArrayOfStations[0].X - 50 &&
                (int)Canvas.GetLeft(((MainWindow)System.Windows.Application.Current.MainWindow).rect121) <= (int)RedBufferArrayOfStations[0].X + 50 &&
                (int)Canvas.GetTop(((MainWindow)System.Windows.Application.Current.MainWindow).rect121) >= (int)RedBufferArrayOfStations[0].Y - 50 &&
                (int)Canvas.GetTop(((MainWindow)System.Windows.Application.Current.MainWindow).rect121) <= (int)RedBufferArrayOfStations[0].Y + 50)
                {
                    foreach (var VARIABLE in passengers.ToArray())
                    {
                        if (VARIABLE.InTravel == true && (bool)VARIABLE.InTransport == false && VARIABLE.StationColor == Colors.Red)
                        {

                            if (RedBufferArrayOfStations[0] == RedPointInForward[(int)VARIABLE.CurrentStation])
                            {

                                AddInTransport bo = Transports[1].AddingPassenger;
                                IAsyncResult ar = bo.BeginInvoke(VARIABLE, null, null);
                                Transports[1]++;
                                passengers.Remove(VARIABLE);
                            }
                           List<Point> buffer = new List<Point>();
                            buffer.AddRange(RedPointInBackward);
                            buffer.Reverse();
                            //
                            //if ((int)VARIABLE.NeedStation != 6 && (int)VARIABLE.NeedStation != 0)
                                if (RedBufferArrayOfStations[0] == buffer[(int)VARIABLE.CurrentStation])
                            {
                                
                                AddInTransport bo = Transports[1].AddingPassenger;
                                IAsyncResult ar = bo.BeginInvoke(VARIABLE, null, null);
                                Transports[1]++;
                                passengers.Remove(VARIABLE);
                            }
                        }
                    }
                    if (Transports[1].pass.Count != 0)
                    {
                        List<Point> buffer = new List<Point>();
                        buffer.AddRange(RedPointInBackward);
                        buffer.Reverse();
                        foreach (var VARIABLE in Transports[1].pass.ToArray())
                        {
                            if (RedBufferArrayOfStations[0] == RedPointInForward[(int)VARIABLE.NeedStation])
                            {
                                VARIABLE.OutFromTransport();
                                Transports[1].pass.Remove(VARIABLE);
                                Transports[1]--;
                                passengers.Add(VARIABLE);
                                VARIABLE.x -= 200;
                                VARIABLE.y += 200;
                                VARIABLE.Draw();
                            }
                            else
                            {
                                //
                             //   if((int)VARIABLE.NeedStation!=6 && (int)VARIABLE.NeedStation != 0)
                                if (RedBufferArrayOfStations[0] == buffer[(int)VARIABLE.NeedStation])
                                {
                                    VARIABLE.OutFromTransport();
                                    Transports[1].pass.Remove(VARIABLE);
                                    Transports[1]--;
                                    passengers.Add(VARIABLE);
                                    VARIABLE.x -= 200;
                                    VARIABLE.y += 200;
                                    VARIABLE.Draw();
                                }
                            }
                        }
                    }
                    dispatcherTimer1RED.Tick += new EventHandler(dispatcherTimer1RED_Tick);
                    dispatcherTimer1RED.Interval = new TimeSpan(0, 0, 0, 0, 1);
                    dispatcherTimer1RED.Start();
                    RedBufferArrayOfStations.RemoveAt(0);

                }
                if (RedBufferArrayOfStations.Count == 0)
                {
                    RedBufferArrayOfStations.AddRange(RedPointInForward);
                    RedBufferArrayOfStations.AddRange(RedPointInBackward);
                }
            }
        }
        public void LeftButton()
        {
            WasPaused = true;
            foreach (var VARIABLE in Transports)
            {
                VARIABLE.Pause();
            }
            var windowPosition = Mouse.GetPosition(((MainWindow)Application.Current.MainWindow).MainCanvas);
            foreach (var pass in passengers)
            {
                pass.MouseClick(Convert.ToInt32(windowPosition.X), Convert.ToInt32(windowPosition.Y));
                pass.Draw();
            }
            foreach (var pass in passengers)
            {
                pass.SetPosition();
            }
            foreach (var VARIABLE in Transports)
            {
                VARIABLE.Resume();
            }
            WasPaused = false;
        }   
        public void KeyDown(KeyEventArgs e)
        {

            const int dx = 10;
            const int dy = 10;
            switch (e.Key)
            {

                case Key.W:
                    foreach (Passenger el in passengers)
                        if (el != null && el.InTravel==false) el.Move(0, -dy);
                    break;
                case Key.A:
                    foreach (Passenger el in passengers)
                        if (el != null && el.InTravel == false) el.Move(-dx, 0);
                    break;
                case Key.D:
                    foreach (Passenger el in passengers)
                        if (el != null && el.InTravel == false) el.Move(dx, 0);
                    break;
                case Key.S:
                    foreach (Passenger el in passengers)
                        if (el != null && el.InTravel == false) el.Move(0, dy);
                    break;
                case Key.Up:
                    foreach (Passenger el in passengers)
                        if (el != null && el.InTravel == false) el.Move(0, -dy);
                    break;
                case Key.Left:
                    foreach (Passenger el in passengers)
                        if (el != null && el.InTravel == false) el.Move(-dx, 0);
                    break;
                case Key.Right:
                    foreach (Passenger el in passengers)
                        if (el != null && el.InTravel == false) el.Move(dx, 0);
                    break;
                case Key.Down:
                    foreach (Passenger el in passengers)
                        if (el != null && el.InTravel == false) el.Move(0, dy);
                    break;
                case Key.C:
                    foreach (var VARIABLE in passengers.ToArray())
                    {
                        if (VARIABLE.isActive() == true && VARIABLE is PassengerWithSingleTicket == true)
                        {
                            PassengerWithSingleTicket k = new PassengerWithSingleTicket();
                            k = (PassengerWithSingleTicket)(VARIABLE as PassengerWithSingleTicket).Clone();
                            k.x += 20;
                            k.y += 20;
                            passengers.Add(k);
                        }
                    }
                    break;

                case Key.Delete:
                    for (int i = 0; i < passengers.Count; i++)
                    {
                        if (passengers[i].isActive())
                        {
                            passengers[i].Remove();
                            passengers.Remove(passengers[i]);
                            i--;
                        }
                    }
                    break;
                case Key.Insert:
                    {
                        foreach (var VARIABLE in Transports)
                        {
                            VARIABLE.Pause();
                        }
                        WasPaused = true;
                        CreateNewPassenger newPassenger = new CreateNewPassenger();
                        newPassenger.ShowDialog();
                        if (newPassenger.DialogResult == true)
                        {
                            if (newPassenger.TypeOfMicroObject == 1)
                            {
                                Passenger s = new Passenger(
                          newPassenger.MyName,
                          newPassenger.MyYears,
                           newPassenger.X,
                           newPassenger.Y,
                           newPassenger.Active
                       );
                                passengers.Add(s);
                            }
                            if (newPassenger.TypeOfMicroObject == 2)
                            {
                                PassengerWithSingleTicket s = new PassengerWithSingleTicket(
                          newPassenger.MyName,
                          newPassenger.MyYears,
                           newPassenger.X,
                           newPassenger.Y,
                           newPassenger.Active,
                           newPassenger.NumbersOfTrips,
                           newPassenger.Cash
                       );
                                passengers.Add(s);

                            }
                            if (newPassenger.TypeOfMicroObject == 3)
                            {
                                PreferentialPassenger s = new PreferentialPassenger(
                 newPassenger.MyName,
                 newPassenger.MyYears,
                 newPassenger.X,
                 newPassenger.Y,
                 newPassenger.Active,
                 newPassenger.Cash,
                 newPassenger.TypeOfPREFERNTIAL
                    );
                                passengers.Add(s);
                            }

                        }
                    }
                    foreach (var VARIABLE in Transports)
                    {
                        VARIABLE.Resume();
                    }
                    WasPaused = false;
                    break;
                case Key.Escape:
                    for (int i = 0; i < passengers.Count; i++)
                    {
                        if (passengers[i].isActive())
                        {
                            passengers[i].active = false;
                        }
                    }
                    break;
            }
            foreach (var pass in passengers)
            {
                pass.Draw();
            }
        }
        private void StationTimer_Tick(object sender, EventArgs e)
        {

            foreach (var VARIABLE in passengers)
            {
                if(VARIABLE.InTravel==true)
                VARIABLE.Draw();
            }
            foreach (var VARIABLE in Transports)
            {
                VARIABLE.Draw();
            }
            CheckIfONGreenStation();
            CheckIfONRedStation();

            {
                int index;
                List<Ellipse> bufferPoints = new List<Ellipse>();
                bufferPoints.AddRange(GreenStation);
                bufferPoints.AddRange(RedStation);
                foreach (var VARIABLE in passengers)
                {

                    int dx = 0, dy = 0;
                    if (VARIABLE.MotionStyle == 2)
                    {
                        int MinRad =
                            (int)
                            Math.Sqrt(Math.Pow(Canvas.GetLeft(bufferPoints[0]) - VARIABLE.x, 2) +
                                      Math.Pow(Canvas.GetTop(bufferPoints[0]) - VARIABLE.y, 2));
                        index = 0;
                        foreach (var VE in bufferPoints)
                        {
                            if (MinRad >
                                (int)
                                Math.Sqrt(Math.Pow(Canvas.GetLeft(VE) - VARIABLE.x, 2) +
                                          Math.Pow(Canvas.GetTop(VE) - VARIABLE.y, 2)))
                            {
                                MinRad =
                                    (int)
                                    Math.Sqrt(Math.Pow(Canvas.GetLeft(VE) - VARIABLE.x, 2) +
                                              Math.Pow(Canvas.GetTop(VE) - VARIABLE.y, 2));
                                index = bufferPoints.IndexOf(VE);
                            }
                        }
                        int dxx, dyx;
                        dxx = (int) Canvas.GetLeft(bufferPoints[bufferPoints.IndexOf(bufferPoints[index])]) - VARIABLE.x;
                        dyx = (int) Canvas.GetTop(bufferPoints[index]) - VARIABLE.y;
                        dxx = RandomizeStep(dxx);
                        dyx = RandomizeStep(dyx);

                        VARIABLE.Move(dxx / 20, dyx / 20);
                    }

                    if (VARIABLE.MotionStyle == 3)
                    {
                        int indexix = 0;
                        int MinRad;
                        if (passengers.Count > passengers.IndexOf(VARIABLE) + 1)
                        {
                            MinRad =
                                (int)
                                Math.Sqrt(
                                    Math.Pow(passengers[passengers.IndexOf(VARIABLE) + 1].x - VARIABLE.x, 2) +
                                    Math.Pow(passengers[passengers.IndexOf(VARIABLE) + 1].y - VARIABLE.y, 2));
                            indexix = passengers.IndexOf(VARIABLE) + 1;
                        }
                        else
                        {
                            MinRad = (int)
                                    Math.Sqrt(
                                        Math.Pow(passengers[passengers.IndexOf(VARIABLE) - 1].x - VARIABLE.x, 2) +
                                        Math.Pow(passengers[passengers.IndexOf(VARIABLE) - 1].y - VARIABLE.y, 2));
                            indexix = passengers.IndexOf(VARIABLE) - 1;

                        }
                        foreach (var VARIABL in passengers)
                        {
                            if (MinRad > (int)
                                Math.Sqrt(
                                    Math.Pow(VARIABL.x - VARIABLE.x, 2) +
                                    Math.Pow(VARIABL.y - VARIABLE.y, 2)) && VARIABL != VARIABLE)
                            {



                                MinRad = (int)
                                    Math.Sqrt(
                                        Math.Pow(VARIABL.x - VARIABLE.x, 2) +
                                        Math.Pow(VARIABL.y - VARIABLE.y, 2));
                                indexix = passengers.IndexOf(VARIABL);
                            }
                            // Rect rectangle1 = new Rect(VARIABL.x, VARIABL.y, Passenger.imagewx, Passenger.imagewy);
                            // Rect rectangle2 = new Rect(VARIABLE.x, VARIABLE.y, Passenger.imagewx, Passenger.imagewy);
                            //  if (rectangle1.IntersectsWith(rectangle2) && VARIABL.InTravel == false && VARIABLE.InTravel == false )
                            if(VARIABL/VARIABLE)
                            {
                                    if (VARIABL.active == false)
                                    {
                                        VARIABLE.active = false;
                                    }
                                    else
                                    {
                                        VARIABL.Move(-100, -100);
                                        VARIABLE.Move(100, 100);
                                    }
                                }

                                // MessageBox.Show("kek");
 
                            
                        }
                        int dxx, dyx;
                        dxx = passengers[indexix].x - VARIABLE.x;
                        dyx = passengers[indexix].y - VARIABLE.y;
                        dxx = RandomizeStep(dxx);
                        dyx = RandomizeStep(dyx);
                        VARIABLE.Move(dxx / 20, dyx / 20);
                    }
                    if (VARIABLE.MotionStyle == 1)
                    {
                        VARIABLE.Move(out dx, out dy);

                        VARIABLE.Move(dx, dy);
                    }


                }
                            foreach (var VARIBALE in passengers)
                            {
                                VARIBALE.Draw();
                            }
                        }
        }
        private void dispatcherTimer1_Tick(object sender, EventArgs e)
        {
            if (WasPaused == false)
            {
                Transports[0].Pause();
            }
            dispatcherTimer2.Tick += new EventHandler(dispatcherTimer2_Tick);
            dispatcherTimer2.Interval = new TimeSpan(0, 0, 0, 2);
            dispatcherTimer2.Start();
            dispatcherTimer1.Stop();

        }
        private void dispatcherTimer2_Tick(object sender, EventArgs e)
        {

            if (WasPaused == false)
                Transports[0].Resume();
            dispatcherTimer2.Stop();


        }
        private void dispatcherTimer1RED_Tick(object sender, EventArgs e)
        {
            if (WasPaused == false)
            {
                Transports[1].Pause();
            }
            dispatcherTimer2RED.Tick += new EventHandler(dispatcherTimer2RED_Tick);
            dispatcherTimer2RED.Interval = new TimeSpan(0, 0, 0, 2);
            dispatcherTimer2RED.Start();
            dispatcherTimer1RED.Stop();

        }
        private void dispatcherTimer2RED_Tick(object sender, EventArgs e)
        {
            if (WasPaused == false)
                Transports[1].Resume();
                 dispatcherTimer2RED.Stop();
        }
        private void OnStation_Tick(object sender, EventArgs e)
        {
            foreach (var VARIABLE in GreenStation)
            {
                foreach (var VAE in passengers)
                {
                    Rect rectangle1 = new Rect(VAE.x, VAE.y, (int)Passenger.imagewx, (int)Passenger.imagewy);
                    Rect rectangle2 = new Rect(Canvas.GetLeft(VARIABLE), Canvas.GetTop(VARIABLE), 25, 25);
                    if (rectangle1.IntersectsWith(rectangle2) && VAE.InTravel == false)
                    {
                        VAE.MotionStyle = 0;
                        WasPaused = true;
                        foreach (var V in Transports)
                        {
                         V.Pause();   
                        }
                        ChooseStation newPassenger = new ChooseStation();
                        newPassenger.ShowDialog();
                        if (newPassenger.DialogResult == true)
                        {
                            if (Convert.ToInt32(newPassenger.MyStation) < 0 ||
                                Convert.ToInt32(newPassenger.MyStation) > 12)
                            {
                            }
                            else
                            {
                                VAE.OnStation(GreenStation.IndexOf(VARIABLE), Convert.ToInt32(newPassenger.MyStation),
                                    Colors.Green);
                            }
                        }
                        foreach (var V in Transports)
                        {
                            V.Resume();
                        }
                        WasPaused = false;

                        foreach (var pass in passengers)
                        {
                            pass.Draw();
                        }
                    }
                }
            }
            foreach (var VARIABLE in RedStation)
            {
                foreach (var VAE in passengers)
                {
                    Rect rectangle1 = new Rect(VAE.x, VAE.y, Passenger.imagewx, Passenger.imagewy);
                    Rect rectangle2 = new Rect(Canvas.GetLeft(VARIABLE), Canvas.GetTop(VARIABLE), 25, 25);
                    if (rectangle1.IntersectsWith(rectangle2) && VAE.InTravel == false )
                    {
                        WasPaused = true;
                        VAE.MotionStyle = 0;
                        foreach (var V in Transports)
                        {
                            V.Pause();
                        }
                        ChooseStation newPassenger = new ChooseStation();
                        newPassenger.ShowDialog();
                        if (newPassenger.DialogResult == true)
                        {
                            if (Convert.ToInt32(newPassenger.MyStation) < 0 ||
                                Convert.ToInt32(newPassenger.MyStation) > 6)
                            {
                            }
                            else
                            {
                                VAE.OnStation(RedStation.IndexOf(VARIABLE), Convert.ToInt32(newPassenger.MyStation),
                                    Colors.Red);
                            }
                        }
                        foreach (var V in Transports)
                        {
                            V.Resume();
                        }
                        WasPaused = false;

                        foreach (var pass in passengers)
                        {
                            pass.Draw();
                        }
                    }
                }


            }
            if (Transports[0].pass.Count != 0)
            {
                foreach (var passenger in Transports[0].pass)
                {
                    passenger.x =
                        (int) Canvas.GetLeft(((MainWindow) System.Windows.Application.Current.MainWindow).rect);
                    passenger.y = (int) Canvas.GetTop(((MainWindow) System.Windows.Application.Current.MainWindow).rect);

                }
                foreach (var VARIABLE in Transports[0].pass)
                {
                    VARIABLE.Draw();
                }
            }
            if (Transports[1].pass.Count != 0)
            {
                foreach (var passenger in Transports[1].pass)
                {
                    passenger.x =
                        (int)Canvas.GetLeft(((MainWindow)System.Windows.Application.Current.MainWindow).rect121);
                    passenger.y = (int)Canvas.GetTop(((MainWindow)System.Windows.Application.Current.MainWindow).rect121);

                }
                foreach (var VARIABLE in Transports[1].pass)
                {
                    VARIABLE.Draw();
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

        public void PassangerSave(StreamWriter streamWriter)
        {;
            streamWriter.WriteLine("TransportCompany");
            streamWriter.WriteLine(WasPaused);
            streamWriter.WriteLine(passengers.Count);
            foreach (var VARIABLE in passengers)
            {
                VARIABLE.Save(streamWriter);
            }
        }
        public void TransportSave(StreamWriter streamWriter)
        {
              foreach (var VARIABLE in Transports)
               {
                   streamWriter.WriteLine(VARIABLE.pass.Count);
                   VARIABLE.Save(streamWriter);
                }
        }
        public void Load(StreamReader sr)
        {
            foreach (var VARIABLE in passengers.ToArray())
            {
                VARIABLE.Remove();
                passengers.Remove(VARIABLE);
            }
            string s = sr.ReadLine();
            s = sr.ReadLine();
            s = sr.ReadLine();
            int k = Convert.ToInt32(s);
        
            for (int i = 0; i < k; i++)
            {
                s = sr.ReadLine();
                if (s == "Passenger")
                {
                    passengers.Add(new Passenger());
                    passengers[passengers.Count-1].Load(sr);
                }
                if (s == "PassengerWithSingleTicket")
                {
                    passengers.Add(new PassengerWithSingleTicket());
                    passengers[passengers.Count - 1].Load(sr);
                }
                if (s == "PreferentialPassenger")
                {
                    passengers.Add(new PreferentialPassenger());
                    passengers[passengers.Count - 1].Load(sr);
                }
               
            }
            foreach (var VARIABLE in Transports)
            {
                foreach (var ARIABLE in VARIABLE.pass.ToArray())
                {
                    ARIABLE.Remove();
                    VARIABLE.pass.Remove(ARIABLE);
                }
            }
            k = Convert.ToInt32(sr.ReadLine());
            for (int i = 0; i < k; i++)
            {
                s = sr.ReadLine();
                if (s == "Passenger")
                {
                    Transports[0].pass.Add(new Passenger());
                    Transports[0].pass[Transports[0].pass.Count - 1].Load(sr);
                }
                if (s == "PassengerWithSingleTicket")
                {
                    Transports[0].pass.Add(new PassengerWithSingleTicket());
                    Transports[0].pass[Transports[0].pass.Count - 1].Load(sr);
                }
                if (s == "PreferentialPassenger")
                {
                    Transports[0].pass.Add(new PreferentialPassenger());
                    Transports[0].pass[Transports[0].pass.Count - 1].Load(sr);
                }
            }
            k = Convert.ToInt32(sr.ReadLine());
            for (int i = 0; i < k; i++)
            {
                s = sr.ReadLine();
                if (s == "Passenger")
                {
                    Transports[1].pass.Add(new Passenger());
                    Transports[1].pass[Transports[1].pass.Count - 1].Load(sr);
                }
                if (s == "PassengerWithSingleTicket")
                {
                    Transports[1].pass.Add(new PassengerWithSingleTicket());
                    Transports[1].pass[Transports[1].pass.Count - 1].Load(sr);
                }
                if (s == "PreferentialPassenger")
                {
                    Transports[1].pass.Add(new PreferentialPassenger());
                    Transports[1].pass[Transports[1].pass.Count - 1].Load(sr);
                }
            }
            foreach (var VARIABLE in passengers)
            {
                VARIABLE.Draw();
            }

        }

    }
}
