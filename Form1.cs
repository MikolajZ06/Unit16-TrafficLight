using System;
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
    enum LightColor
    {
        Green,
        Yellow,
        Red,
        Off
    }

    class LightCycle
    {
        public LightColor[,] lightCycle = { { LightColor.Green, LightColor.Off, LightColor.Off },
            { LightColor.Red, LightColor.Off, LightColor.Off } };

        int cycleStage = 0;
        LightColor currentStage = lightCycle[0];

        public LightCycle(Side side)
        {
            if (side == Side.Right)
                cycleStage = 1;
        }

        void NextStage()
        {
            if (currentStage + 1 == lightCycle.Length())
            {
                currentStage = lightCycle[0];
                return;
            }

            currentStage = lightCycle[++cycleStage];
        }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }



        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var leftLight = new TrafficLight(Side.Left, e, Size.Width, Size.Height);
            var rightLight = new TrafficLight(Side.Right, e, Size.Width, Size.Height);

            leftLight.Draw(leftCycle.currentStage);
            rightLight.Draw(rightCycle.currentStage);

            LightCycle leftCycle = new LightCycle();
            LightCycle rightCycle = new LightCycle();

            leftCycle.NextStage();
            rightCycle.NextStage();

        }
    }
}
