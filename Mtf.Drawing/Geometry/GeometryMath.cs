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
}
