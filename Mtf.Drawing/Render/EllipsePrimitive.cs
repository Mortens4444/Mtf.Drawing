using Mtf.Drawing.Geometry;
using Mtf.Drawing.Interfaces;
using System.Drawing;

namespace Mtf.Drawing.Render;

public class EllipsePrimitive : PrimitiveBase
{
    public EllipseF Ellipse { get; set; }

    public bool Fill { get; set; }

    public override IShape Shape => Ellipse;

    public override void DrawOnGraphics(Graphics g, Color color)
    {
        var x = Ellipse.Center.X - Ellipse.RadiusX;
        var y = Ellipse.Center.Y - Ellipse.RadiusY;
        var width = Ellipse.RadiusX * 2;
        var height = Ellipse.RadiusY * 2;

        if (Fill)
        {
            using var brush = new SolidBrush(color);
            g.FillEllipse(brush, x, y, width, height);
        }
        else
        {
            using var pen = new Pen(color);
            g.DrawEllipse(pen, x, y, width, height);
        }
    }
}