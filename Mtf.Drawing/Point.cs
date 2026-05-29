using System.Drawing;

namespace Mtf.Drawing;

public class Point(byte x, byte y) : IDrawingElement
{
    public byte X { get; set; } = x;

    public byte Y { get; set; } = y;

    public void DrawOnGraphics(Graphics graphics)
    {
        DrawOnGraphics(graphics, Color.Black);
    }

    public void DrawOnGraphics(Graphics graphics, Color color)
    {
        graphics.FillRectangle(new SolidBrush(color), X, Y, 1, 1);
    }

    public double GetDistance(Point eV3Point)
    {
        return Math.Sqrt(Math.Pow(X - eV3Point.X, 2) + Math.Pow(Y - eV3Point.Y, 2));
    }
}
