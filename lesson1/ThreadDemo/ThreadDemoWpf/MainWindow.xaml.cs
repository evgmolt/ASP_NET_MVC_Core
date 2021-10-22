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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ThreadDemoWpf
{
    public partial class MainWindow : Window
    {
        Thread fibonacciThread;
        int Number = 0;
        int MaxNumber = 20;
        long currentFibonacci;
        int interval = 1000;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void GetFibonacci()
        {
            while (Number < MaxNumber)
            {
                Number++;
                currentFibonacci = FIbonacci.GetRecurs(Number);
               
                Application.Current.Dispatcher.BeginInvoke(
                        new Action(() =>
                        {
                            textBoxFibonacci.Text = Number.ToString() + ": " + currentFibonacci.ToString();
                            interval = (int)(sliderInterval.Value * 1000);
                        }));
               
                Thread.Sleep(interval);
            }
        }

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            Number = 0;
            fibonacciThread = new Thread(new ThreadStart(GetFibonacci));
            fibonacciThread.Start();
        }

        private void sliderInterval_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            labelInterval.Content = "Interval : " + sliderInterval.Value.ToString() + " s";
        }
    }
}
