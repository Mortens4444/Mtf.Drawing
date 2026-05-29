using System.Drawing;

namespace Mtf.Drawing;

public class Rectangle : IDrawingElement
{
    public Point TopLeftCorner { get; }

    public byte Width { get; }

    public byte Height { get; }

    public bool Fill { get; }

    public Rectangle(Point point, byte width, byte height, bool fill)
        : this(point.X, point.Y, width, height, fill)
    { }

    public Rectangle(byte x, byte y, byte width, byte height, bool fill)
    {
        TopLeftCorner = new Point(x, y);
        Width = width;
        Height = height;
        Fill = fill;
    }

    public void DrawOnGraphics(Graphics graphics)
    {
        DrawOnGraphics(graphics, Color.Black);
    }

    public void DrawOnGraphics(Graphics graphics, Color color)
    {
        if (Fill)
        {
            graphics.FillRectangle(new SolidBrush(color), TopLeftCorner.X, TopLeftCorner.Y, Width, Height);
        }
        else
        {
            graphics.DrawRectangle(new Pen(color), TopLeftCorner.X, TopLeftCorner.Y, Width, Height);
        }
    }
}
