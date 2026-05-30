using Mtf.Drawing.Interfaces;
using System.Drawing;

namespace Mtf.Drawing.Geometry;

public readonly record struct LineF(PointF A, PointF B) : IShape
{
    public float Length => MathF.Sqrt((A.X - B.X) * (A.X - B.X) + (A.Y - B.Y) * (A.Y - B.Y));

    public PointF Center => new((A.X + B.X) / 2f, (A.Y + B.Y) / 2f);

    public bool Contains(PointF p, float tolerance)
    {
        var l2 = (A.X - B.X) * (A.X - B.X) + (A.Y - B.Y) * (A.Y - B.Y);
        if (l2 == 0)
        {
            return Distance(p, A) <= tolerance;
        }

        var t = ((p.X - A.X) * (B.X - A.X) + (p.Y - A.Y) * (B.Y - A.Y)) / l2;
        t = Math.Clamp(t, 0, 1);

        var proj = new PointF(A.X + t * (B.X - A.X), A.Y + t * (B.Y - A.Y));
        return Distance(p, proj) <= tolerance;
    }

    public LineF Move(float dx, float dy)
    {
        return new LineF(new PointF(A.X + dx, A.Y + dy), new PointF(B.X + dx, B.Y + dy));
    }

    public LineF Resize(float scale)
    {
        if (scale <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(scale));
        }

        var center = Center;
        return new LineF(ScalePoint(A, center, scale), ScalePoint(B, center, scale));
    }

    public LineF Rotate(float angleDegrees, PointF pivot)
    {
        return new LineF(GeometryMath.Rotate(A, pivot, angleDegrees), GeometryMath.Rotate(B, pivot, angleDegrees));
    }

    public LineF Rotate(float angleDegrees)
    {
        var pivot = Center;
        return Rotate(angleDegrees, pivot);
    }

    private static PointF ScalePoint(PointF point, PointF center, float scale)
    {
        return new PointF(center.X + (point.X - center.X) * scale, center.Y + (point.Y - center.Y) * scale);
    }

    private static float Distance(PointF a, PointF b)
    {
        var dx = a.X - b.X;
        var dy = a.Y - b.Y;
        return MathF.Sqrt(dx * dx + dy * dy);
    }

    IShape IShape.Move(float dx, float dy)
    {
        return Move(dx, dy);
    }

    IShape IShape.Rotate(float angle)
    {
        return Rotate(angle);
    }

    IShape IShape.Resize(float scale)
    {
        return Resize(scale);
    }

    public bool Contains(PointF point)
    {
        return Contains(point, 0.005f);
    }
}