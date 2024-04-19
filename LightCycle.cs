using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Unit16_TrafficLight
{
    public class LightCycle
    {
        Brush[,] lightCycle = {
            { Brushes.Red, Brushes.DarkGray, Brushes.DarkGray },
            { Brushes.Red, Brushes.DarkGray, Brushes.DarkGray },
            { Brushes.Red, Brushes.DarkGray, Brushes.DarkGray },
            { Brushes.Red, Brushes.Yellow, Brushes.DarkGray },
            { Brushes.DarkGray, Brushes.DarkGray, Brushes.Green },
            { Brushes.DarkGray, Brushes.Yellow, Brushes.DarkGray}
        };

        int cycleStage = 0;

        public LightCycle(Side side)
        {
            if (side == Side.Right)
                cycleStage = 3;
        }

        public Brush GetLightColor(int lightIndex) {
            Console.WriteLine("{0}: {1}",cycleStage, lightIndex);
            return lightCycle[cycleStage, lightIndex];
        }

        public void NextStage()
        {
            if (cycleStage + 1 >= 6)
            {
                cycleStage = 0;
                return;
            }

            cycleStage++;
        }
    }
}
