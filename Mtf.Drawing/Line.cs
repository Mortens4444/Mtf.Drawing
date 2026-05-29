using System.Drawing;

namespace Mtf.Drawing;

public class Line(byte x1, byte y1, byte x2, byte y2) : IDrawingElement
{
    public byte X1 { get; } = x1;

    public byte Y1 { get; } = y1;

    public byte X2 { get; } = x2;

    public byte Y2 { get; } = y2;

    public void DrawOnGraphics(Graphics graphics)
    {
        DrawOnGraphics(graphics, Color.Black);
    }

    public void DrawOnGraphics(Graphics graphics, Color color)
    {
        graphics.DrawLine(new Pen(color), X1, Y1, X2, Y2);
    }
}
