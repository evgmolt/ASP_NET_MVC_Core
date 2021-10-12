using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThreadDemoWpf;

namespace ThreadDemoWinForms
{
    public partial class FormMain : Form
    {
        Thread fibonacciThread;
        int Number = 0;
        int MaxNumber = 20;
        long currentFibonacci;
        int interval;
        bool doCount = true;
        public FormMain()
        {
            InitializeComponent();
        }
        private void GetFibonacci()
        {
            while (doCount && Number < MaxNumber)
            {
                Number++;
                currentFibonacci = FIbonacci.GetRecurs(Number);
                interval = (int)(numericUpDownInterval.Value * 1000);

                BeginInvoke(
                        new Action(() =>
                        {
                            textBoxFibonacci.Text = Number.ToString() + ": " + currentFibonacci.ToString();
                        }));
                Thread.Sleep(interval);
            }
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {
            Number = 0;
            fibonacciThread = new Thread(new ThreadStart(GetFibonacci));
            fibonacciThread.Start();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            doCount = false;
        }
    }

}
