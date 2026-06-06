using System.Drawing;
using Mtf.Drawing.Geometry;
using Mtf.Drawing.Interfaces;

namespace Mtf.Drawing.Render;

public class PolylinePrimitive : PrimitiveBase
{
    public PolylineF Polyline { get; set; } = new();

    public override IShape Shape => Polyline;

    public float Thickness { get; set; } = 1f;

    public override void DrawOnGraphics(Graphics g, Color color)
    {
        if (Polyline.Points.Count < 2 || g is null)
        {
            return;
        }

        using var pen = new Pen(color, Thickness);

        for (int i = 0; i < Polyline.Points.Count - 1; i++)
        {
            g.DrawLine(pen, Polyline.Points[i], Polyline.Points[i + 1]);
        }
    }
}