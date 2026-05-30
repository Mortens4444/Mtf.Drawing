using Mtf.Drawing.Geometry;
using Mtf.Drawing.Interfaces;
using System.Drawing;

namespace Mtf.Drawing.Render;

public class LinePrimitive : PrimitiveBase, IDrawingElement
{
    public LineF Line { get; set; }

    public float Thickness { get; set; } = 1f;

    public override void DrawOnGraphics(Graphics g, Color color)
    {
        using var pen = new Pen(color, Thickness);
        g?.DrawLine(pen, Line.A, Line.B);
    }
}