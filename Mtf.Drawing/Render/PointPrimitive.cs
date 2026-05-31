using Mtf.Drawing.Geometry;
using Mtf.Drawing.Interfaces;
using System.Drawing;

namespace Mtf.Drawing.Render;

public class PointPrimitive(byte x, byte y) : PrimitiveBase
{
    public PointShape ShapeData { get; set; } = new PointShape(new PointF(x, y));

    public override IShape Shape => ShapeData;

    public override void DrawOnGraphics(Graphics g, Color color)
    {
        if (g == null)
        {
            return;
        }

        using var brush = new SolidBrush(color);
        g?.FillRectangle(brush, ShapeData.Point.X, ShapeData.Point.Y, 1, 1);
    }

    public double GetDistance(PointPrimitive p)
    {
        var dx = ShapeData.Point.X - p.ShapeData.Point.X;
        var dy = ShapeData.Point.Y - p.ShapeData.Point.Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }
}