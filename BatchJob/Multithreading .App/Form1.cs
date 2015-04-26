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

namespace Multithreading.App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTime_Click(object sender, EventArgs e)
        {
            //btnPrintNumber.Enabled = false;
            //btnTime.Enabled = false;

            //DoTimeComsumingWork();

            Thread t = new Thread(DoTimeComsumingWork);
            t.Start();

            //btnPrintNumber.Enabled = true;
            //btnTime.Enabled = true;

        }

        private void DoTimeComsumingWork()
        {
            Thread.Sleep(5000);
        }

        private void btnPrintNumber_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                lstNumbers.Items.Add(i);
            }
        }
    }
}
