using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CrossRoad
{

    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer TIMER = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            Traffic.Focus();
        }
        Double XValue
        {
            get
            {
                bool IsNan = Double.IsNaN(Canvas.GetLeft(two));
                return IsNan ? 0 : Canvas.GetLeft(two);
            }
        }
        Double YValue
        {
            get
            {
                bool y = Double.IsNaN(Canvas.GetLeft(three));
                return y ? 0 : Canvas.GetLeft(three);
            }
        }
        Double DValue
        {
            get
            {
                bool x = Double.IsNaN(Canvas.GetTop(one));
                return x ? 0 : Canvas.GetTop(one);
            }
        }
        Double RValue
        {
            get
            {
                bool r = Double.IsNaN(Canvas.GetTop(four));
                return r ? 0 : Canvas.GetTop(four);
            }
        }
        private void startbtn_Click(object sender, RoutedEventArgs e)
        {
            bool test = true;
                if (test == true)
                {

                    TIMER.Stop();
                    timer.Stop();                
                }
                if (Canvas.GetLeft(two) > Application.Current.MainWindow.Width)
                {
                    test = false;
                }

                if ((string)startbtn.Content == "Start")
                {
                    GreenLight.Fill = Brushes.PaleGreen;
                    startbtn.Content = "Stop";
                    RedLight.Fill = Brushes.Gray;
                    timer.Stop();
                    TIMER.Stop();
                }
                else if (Canvas.GetTop(four) > Application.Current.MainWindow.Height)
                {

                    Canvas.SetLeft(two, 110);
                    Canvas.SetLeft(three, 560);
                    GreenLight.Fill = Brushes.PaleGreen;
                    RedLight.Fill = Brushes.Gray;
                    GreenLight1.Fill = Brushes.Gray;
                }

                else
                {
                    RedLight.Fill = Brushes.Red;
                    startbtn.Content = "Start";
                    GreenLight.Fill = Brushes.Gray;
                    timer.Stop();
                    TIMER.Stop();
                }
                if (Canvas.GetLeft(one) < Application.Current.MainWindow.Width)
                {
                    Canvas.SetLeft(four, 380);
                    Canvas.SetTop(four, 110);
                    Canvas.SetLeft(one, 490);
                    Canvas.SetTop(one, 550);
                    
                }
            
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += new EventHandler(jaEventHandler);
            timer.Start();
            TIMER = new DispatcherTimer();
            TIMER.Interval = TimeSpan.FromMilliseconds(1);
            TIMER.Tick += new EventHandler(neEventHandler);
            TIMER.Start();
        }
        private void jaEventHandler(object sender, EventArgs args)
        {
                Canvas.SetLeft(two, XValue + 4);
                Canvas.SetLeft(three, YValue - 4);
                if (XValue != 1 && YValue != 1 && (string)startbtn.Content == "Start")
                {
                    timer.Stop();
                }
        }
        private void neEventHandler(object sender, EventArgs args)
        {
            RedLight1.Fill = Brushes.Red;
            if (Canvas.GetLeft(two) > Application.Current.MainWindow.Width)
            {
                Canvas.SetTop(one, DValue - 4);
                Canvas.SetTop(four, RValue + 4);
                GreenLight.Fill = Brushes.Gray;
                RedLight.Fill = Brushes.Red;
                RedLight1.Fill = Brushes.Gray;
                GreenLight1.Fill = Brushes.PaleGreen;
            }
            if (RValue != 1 && DValue != 1 && (string)startbtn.Content == "Start")
            {
                TIMER.Stop();
            }

        }

    }
}