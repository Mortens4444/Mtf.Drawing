using Mtf.Drawing.Geometry;
using System.Drawing;

namespace Mtf.Drawing.Render;

public class CirclePrimitive : PrimitiveBase
{
    public CircleF Shape { get; set; }

    public bool Fill { get; set; }

    public bool Contains(PointF point) => Shape.Contains(point);

    public void Move(float dx, float dy) => Shape = Shape.Move(dx, dy);

    public void Resize(float scale) => Shape = Shape.Resize(scale);

    public PointF Center
    {
        get
        {
            return Shape.Center;
        }
        set
        {
            Shape = Shape with { Center = value };
        }
    }

    public float Radius
    {
        get
        {
            return Shape.Radius;
        }
        set
        {
            Shape = Shape with { Radius = value };
        }
    }

    public bool IsColliding(CirclePrimitive other)
    {
        return Shape.Intersects(other.Shape);
    }

    public override void DrawOnGraphics(Graphics g, Color color)
    {   
        var d = Shape.Radius * 2;
        var x = Shape.Center.X - Shape.Radius;
        var y = Shape.Center.Y - Shape.Radius;

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
