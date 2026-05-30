using Mtf.Drawing.Geometry;
using Mtf.Drawing.Interfaces;
using System.Drawing;

namespace Mtf.Drawing.Render;

public class RectanglePrimitive : PrimitiveBase, IDrawingElement
{
    public RectF Rect { get; set; }

    public bool Fill { get; set; }

    public float Thickness { get; set; } = 1f;

    public override void DrawOnGraphics(Graphics g, Color color)
    {
        if (Fill)
        {
            using var brush = new SolidBrush(color);
            g?.FillRectangle(brush, Rect.X, Rect.Y, Rect.Width, Rect.Height);
        }
        else
        {
            using var pen = new Pen(color, Thickness);
            g?.DrawRectangle(pen, Rect.X, Rect.Y, Rect.Width, Rect.Height);
        }
    }
}