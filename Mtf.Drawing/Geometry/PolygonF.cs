using Mtf.Drawing.Interfaces;
using System.Drawing;

namespace Mtf.Drawing.Geometry;

public sealed class PolygonF : IShape
{
    public List<PointF> Points { get; } = [];

    public PolygonF()
    {
    }

    public PolygonF(IEnumerable<PointF> points)
    {
        Points.AddRange(points);
    }

    public PointF Center
    {
        get
        {
            if (Points.Count == 0)
            {
                return PointF.Empty;
            }

            float x = 0;
            float y = 0;

            foreach (var point in Points)
            {
                x += point.X;
                y += point.Y;
            }

            return new PointF(
                x / Points.Count,
                y / Points.Count);
        }
    }

    public bool Contains(PointF point)
    {
        var inside = false;

        for (int i = 0, j = Points.Count - 1; i < Points.Count; j = i++)
        {
            var pi = Points[i];
            var pj = Points[j];

            if (((pi.Y > point.Y) != (pj.Y > point.Y))
                && (point.X < (pj.X - pi.X) * (point.Y - pi.Y) / (pj.Y - pi.Y) + pi.X))
            {
                inside = !inside;
            }
        }

        return inside;
    }

    public PolygonF Move(float dx, float dy)
    {
        return new PolygonF(
            Points.Select(p => new PointF(
                p.X + dx,
                p.Y + dy)));
    }

    public PolygonF Resize(float scale)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(scale);

        var center = Center;

        return new PolygonF(
            Points.Select(p => new PointF(
                center.X + (p.X - center.X) * scale,
                center.Y + (p.Y - center.Y) * scale)));
    }

    public PolygonF Rotate(float angleDegrees)
    {
        return Rotate(angleDegrees, Center);
    }

    public PolygonF Rotate(float angleDegrees, PointF pivot)
    {
        return new PolygonF(
            Points.Select(p => GeometryMath.Rotate(
                p,
                pivot,
                angleDegrees)));
    }

    IShape IShape.Move(float dx, float dy)
    {
        return Move(dx, dy);
    }

    IShape IShape.Resize(float scale)
    {
        return Resize(scale);
    }

    IShape IShape.Rotate(float angle)
    {
        return Rotate(angle);
    }
}