using System.Drawing;

namespace Mtf.Drawing.Render;

public class PointPrimitive(byte x, byte y) : PrimitiveBase
{
    public PointF Point { get; set; } = new PointF(x, y);

    public override void DrawOnGraphics(Graphics g, Color color)
    {
        using var brush = new SolidBrush(color);
        g?.FillRectangle(brush, Point.X, Point.Y, 1, 1);
    }

    public double GetDistance(PointPrimitive p)
    {
        var dx = Point.X - p.Point.X;
        var dy = Point.Y - p.Point.Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }
}