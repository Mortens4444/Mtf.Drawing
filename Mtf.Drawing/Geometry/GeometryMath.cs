using System.Drawing;

namespace Mtf.Drawing.Geometry;

public static class GeometryMath
{
    public static PointF Rotate(PointF p, PointF center, float angleDegrees)
    {
        var angle = MathF.PI * angleDegrees / 180f;

        var cos = MathF.Cos(angle);
        var sin = MathF.Sin(angle);

        var dx = p.X - center.X;
        var dy = p.Y - center.Y;

        return new PointF(center.X + dx * cos - dy * sin, center.Y + dx * sin + dy * cos);
    }

    public static float Distance(PointF a, PointF b)
    {
        var dx = a.X - b.X;
        var dy = a.Y - b.Y;

        return MathF.Sqrt(dx * dx + dy * dy);
    }

    public static PointF MidPoint(PointF a, PointF b)
    {
        return new PointF(
            (a.X + b.X) / 2f,
            (a.Y + b.Y) / 2f);
    }

    public static RectF BoundingBox(IEnumerable<PointF> points)
    {
        ArgumentNullException.ThrowIfNull(points);

        var list = points.ToList();

        if (list.Count == 0)
        {
            return default;
        }

        var minX = list.Min(p => p.X);
        var maxX = list.Max(p => p.X);
        var minY = list.Min(p => p.Y);
        var maxY = list.Max(p => p.Y);

        return new RectF(
            minX,
            minY,
            maxX - minX,
            maxY - minY);
    }

    public static float DegToRad(float degrees)
    {
        return degrees * MathF.PI / 180f;
    }

    public static float RadToDeg(float radians)
    {
        return radians * 180f / MathF.PI;
    }
}
