using System;
using System.Diagnostics;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Unit16_TrafficLight
{
    public partial class Form1 : Form
    {

        TrafficLight leftlight;
        TrafficLight rightlight;
        public Form1()
        {
            InitializeComponent();
            leftlight = new TrafficLight(Side.Left, Size.Width, Size.Height);
            rightlight = new TrafficLight(Side.Right, Size.Width, Size.Height);
            var timer = new System.Timers.Timer();
            timer.Interval = 4000;

            timer.Elapsed += OnCycle;
            timer.AutoReset = true;
            timer.Enabled = true;

        }

        void OnCycle(object source, System.Timers.ElapsedEventArgs e)
        {
            leftlight.OnCycle();
            rightlight.OnCycle();
            this.Invalidate();
        }



        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            leftlight.Draw(e);
            rightlight.Draw(e);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start(Assembly.GetExecutingAssembly().Location);

            Environment.Exit(0);
        }
    }
}
