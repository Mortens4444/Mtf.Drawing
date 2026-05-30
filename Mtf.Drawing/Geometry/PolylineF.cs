using Mtf.Drawing.Interfaces;
using System.Drawing;

namespace Mtf.Drawing.Geometry;

public sealed class PolylineF : IShape
{
    public PolylineF() { }

    public PolylineF(IEnumerable<PointF> points)
    {
        Points.AddRange(points);
    }

    public List<PointF> Points { get; } = [];

    public PointF Center
    {
        get
        {
            if (Points.Count < 2)
            {
                return Points.FirstOrDefault();
            }

            float totalLength = 0f;
            float cx = 0f;
            float cy = 0f;

            for (int i = 0; i < Points.Count - 1; i++)
            {
                var a = Points[i];
                var b = Points[i + 1];

                var dx = b.X - a.X;
                var dy = b.Y - a.Y;

                var len = MathF.Sqrt(dx * dx + dy * dy);
                if (len == 0) continue;

                var midX = (a.X + b.X) / 2f;
                var midY = (a.Y + b.Y) / 2f;

                cx += midX * len;
                cy += midY * len;
                totalLength += len;
            }

            if (totalLength == 0)
            {
                return Points[0];
            }

            return new PointF(cx / totalLength, cy / totalLength);
        }
    }

    public bool Contains(PointF point, float tolerance)
    {
        for (var i = 0; i < Points.Count - 1; i++)
        {
            if (new LineF(Points[i], Points[i + 1]).Contains(point, tolerance))
            {
                return true;
            }
        }

        return false;
    }

    public PointF GetCenter()
    {
        if (Points.Count == 0)
        {
            return PointF.Empty;
        }

        var minX = Points.Min(p => p.X);
        var maxX = Points.Max(p => p.X);
        var minY = Points.Min(p => p.Y);
        var maxY = Points.Max(p => p.Y);

        return new PointF(
            minX + (maxX - minX) / 2f,
            minY + (maxY - minY) / 2f);
    }

    public void Move(float dx, float dy)
    {
        for (var i = 0; i < Points.Count; i++)
        {
            Points[i] = new PointF(Points[i].X + dx, Points[i].Y + dy);
        }
    }

    public void Resize(float scale)
    {
        if (scale <= 0 || Points.Count == 0)
        {
            return;
        }

        var center = GetCenter();

        for (var i = 0; i < Points.Count; i++)
        {
            var dx = Points[i].X - center.X;
            var dy = Points[i].Y - center.Y;

            Points[i] = new PointF(center.X + dx * scale, center.Y + dy * scale);
        }
    }

    public void Rotate(float angleDegrees, PointF pivot)
    {
        for (var i = 0; i < Points.Count; i++)
        {
            Points[i] = GeometryMath.Rotate(Points[i], pivot, angleDegrees);
        }
    }

    public void Rotate(float angleDegrees)
    {
        var pivot = GetCenter();
        Rotate(angleDegrees, pivot);
    }

    IShape IShape.Move(float dx, float dy)
    {
        var copy = new PolylineF(Points);
        copy.Move(dx, dy);
        return copy;
    }

    IShape IShape.Rotate(float angle)
    {
        var copy = new PolylineF(Points);
        copy.Rotate(angle);
        return copy;
    }

    IShape IShape.Resize(float scale)
    {
        var copy = new PolylineF(Points);
        copy.Resize(scale);
        return copy;
    }

    public bool Contains(PointF point)
    {
        var copy = new PolylineF(Points);
        return copy.Contains(point);
    }
}