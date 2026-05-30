using Mtf.Drawing.Interfaces;
using System.Drawing;

namespace Mtf.Drawing.Geometry;

public readonly record struct CircleF(PointF Center, float Radius) : IShape
{
    public bool Contains(PointF p)
    {
        var dx = p.X - Center.X;
        var dy = p.Y - Center.Y;
        return dx * dx + dy * dy <= Radius * Radius;
    }

    public CircleF Move(float dx, float dy)
    {
        return this with
        {
            Center = new PointF(Center.X + dx, Center.Y + dy)
        };
    }

    public CircleF Resize(float scale)
    {
        if (scale <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(scale));
        }

        return this with
        {
            Radius = Radius * scale
        };
    }

    public CircleF Rotate(float angleDegrees)
    {
        return this; // there is no reason to do anything here, since a circle looks the same after rotation
    }

    public CircleF Rotate(float angleDegrees, PointF pivot)
    {
        return this with
        {
            Center = GeometryMath.Rotate(Center, pivot, angleDegrees)
        };
    }

    public float DistanceTo(PointF p)
    {
        var dx = p.X - Center.X;
        var dy = p.Y - Center.Y;
        return MathF.Sqrt(dx * dx + dy * dy);
    }

    public bool Intersects(CircleF other)
    {
        var dx = other.Center.X - Center.X;
        var dy = other.Center.Y - Center.Y;

        var distanceSquared = dx * dx + dy * dy;
        var radiusSum = Radius + other.Radius;

        return distanceSquared < radiusSum * radiusSum;
    }

    public CircleF? GetFirstIntersecting(IEnumerable<CircleF> circles)
    {
        foreach (var circle in circles ?? [])
        {
            if (!Equals(circle) && Intersects(circle))
            {
                return circle;
            }
        }

        return null;
    }

    public CircleF Inflate(float delta) => this with { Radius = Radius + delta };

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
}