using Mtf.Drawing.Geometry;
using System.Drawing;

namespace Mtf.Drawing.Render;

public class CirclePrimitive : PrimitiveBase
{
    public CircleF Geometry { get; set; }

    public bool Fill { get; set; }

    public bool Contains(PointF point) => Geometry.Contains(point);

    public void Move(float dx, float dy) => Geometry = Geometry.Move(dx, dy);

    public void Resize(float scale) => Geometry = Geometry.Resize(scale);

    public PointF Center
    {
        get
        {
            return Geometry.Center;
        }
        set
        {
            Geometry = Geometry with { Center = value };
        }
    }

    public float Radius
    {
        get
        {
            return Geometry.Radius;
        }
        set
        {
            Geometry = Geometry with { Radius = value };
        }
    }

    public override void DrawOnGraphics(Graphics g, Color color)
    {   
        var d = Geometry.Radius * 2;
        var x = Geometry.Center.X - Geometry.Radius;
        var y = Geometry.Center.Y - Geometry.Radius;

        if (Fill)
        {
            using var brush = new SolidBrush(color);
            g?.FillEllipse(brush, x, y, d, d);
        }
        else
        {
            using var pen = new Pen(color);
            g?.DrawEllipse(pen, x, y, d, d);
        }
    }
}
