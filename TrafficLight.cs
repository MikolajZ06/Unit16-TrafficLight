using System;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Unit16_TrafficLight;

public enum Side { 
    Left,
    Right
}

public class TrafficLight
{
    public Side side;
    public int windowHeight;
    public int windowWidth;
    LightCycle lightCycle;

    public TrafficLight(Side side,int windowWidth, int windowHeight)
    {
        lightCycle = new LightCycle(side);
        this.side = side;
        this.windowHeight = windowHeight;
        this.windowWidth = windowWidth;
    }

    public void Draw(PaintEventArgs e)
    {
        Console.WriteLine(lightCycle.GetLightColor(1));
        DrawBox(e);
        DrawCircles(lightCycle, e);


    }

    public void OnCycle()
    {
        lightCycle.NextStage();
    }

    void DrawBox(PaintEventArgs e)
    {
        int rectHeight = 400;
        int rectWidth = 200;
        
        int rectX = 50;
        if (side == Side.Right)
            rectX = windowWidth - rectWidth - 50;

        int rectY = (windowHeight / 2) - rectHeight / 2;

        var rect = new Rectangle(rectX, rectY, rectWidth, rectHeight);

        var gp = new System.Drawing.Drawing2D.GraphicsPath();
        gp.AddRectangle(rect);

        e.Graphics.FillRegion(Brushes.Black, new Region(gp));
    }

    void DrawCircles(LightCycle cycle, PaintEventArgs e)
    {
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("redrawing the lights");

            var gp = new System.Drawing.Drawing2D.GraphicsPath();

            int circleWidth = 100;
            int circleX = 100;

            if (side == Side.Right)
                circleX = windowWidth - circleWidth - 100;
            gp.AddEllipse(circleX, 80 + (i * 120), circleWidth, 100);
            var region = new Region(gp);

            Graphics gr = e.Graphics;
            gr.FillRegion(cycle.GetLightColor(i), region);
        }
    }
}