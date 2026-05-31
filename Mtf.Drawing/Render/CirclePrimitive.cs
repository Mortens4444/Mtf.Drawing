using Mtf.Drawing.Geometry;
using Mtf.Drawing.Interfaces;
using System.Drawing;

namespace Mtf.Drawing.Render;

public class CirclePrimitive : PrimitiveBase
{
    public CircleF Circle { get; set; }

    public override IShape Shape => Circle;

    public bool Fill { get; set; }

    public bool Contains(PointF point) => Circle.Contains(point);

    public void Move(float dx, float dy) => Circle = Circle.Move(dx, dy);

    public void Resize(float scale) => Circle = Circle.Resize(scale);

    public PointF Center
    {
        get
        {
            return Circle.Center;
        }
        set
        {
            Circle = Circle with { Center = value };
        }
    }

    public float Radius
    {
        get
        {
            return Circle.Radius;
        }
        set
        {
            Circle = Circle with { Radius = value };
        }
    }

    public bool IsColliding(CirclePrimitive other)
    {
        return Circle.Intersects(other.Circle);
    }

    public override void DrawOnGraphics(Graphics g, Color color)
    {   
        var d = Circle.Radius * 2;
        var x = Circle.Center.X - Circle.Radius;
        var y = Circle.Center.Y - Circle.Radius;

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
