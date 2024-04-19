using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
public enum Side { 
    Left,
    Right
}

public class TrafficLight
{
    public Side side;
    public PaintEventArgs paintArgs;
    public int windowHeight;
    public int windowWidth;

    public TrafficLight(Side side, PaintEventArgs e,int windowWidth, int windowHeight)
    {
        this.side = side;
        this.paintArgs = e;
        this.windowHeight = windowHeight;
        this.windowWidth = windowWidth;
    }

    public void Draw()
    {
        DrawBox();
        DrawCircles();
    }

    void DrawBox()
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

        paintArgs.Graphics.FillRegion(Brushes.Black, new Region(gp));
    }

    void DrawCircles()
    {
        for (int i = 0; i < 3; i++)
        {
            var gp = new System.Drawing.Drawing2D.GraphicsPath();

            int circleWidth = 100;
            int circleX = 100;

            if (side == Side.Right)
                circleX = windowWidth - circleWidth - 100;
            gp.AddEllipse(circleX, 80 + (i * 120), circleWidth, 100);
            var region = new System.Drawing.Region(gp);

            Graphics gr = paintArgs.Graphics;
            gr.FillRegion(Brushes.DarkGray, region);

            
            
        }
    }
}