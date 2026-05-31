using Mtf.Drawing.Geometry;
using System.Drawing;

namespace Mtf.Drawing.Render;

public class RectanglePrimitive : PrimitiveBase
{
    public RectF Shape { get; set; }

    public bool Fill { get; set; }

    public float Thickness { get; set; } = 1f;

    public override void DrawOnGraphics(Graphics g, Color color)
    {
        if (Fill)
        {
            using var brush = new SolidBrush(color);
            g?.FillRectangle(brush, Shape.X, Shape.Y, Shape.Width, Shape.Height);
        }
        else
        {
            using var pen = new Pen(color, Thickness);
            g?.DrawRectangle(pen, Shape.X, Shape.Y, Shape.Width, Shape.Height);
        }
    }
}