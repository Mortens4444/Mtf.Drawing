using Mtf.Drawing.Interfaces;
using System.Drawing;

namespace Mtf.Drawing.Geometry;

public readonly record struct EllipseF(PointF Center, float RadiusX, float RadiusY, float RotationDegrees = 0) : IShape
{
    public EllipseF(float x, float y, float radiusX, float radiusY)
        : this(new PointF(x, y), radiusX, radiusY)
    {
    }

    public bool Contains(PointF point)
    {
        var dx = point.X - Center.X;
        var dy = point.Y - Center.Y;

        return (dx * dx) / (RadiusX * RadiusX) + (dy * dy) / (RadiusY * RadiusY) <= 1f;
    }

    public EllipseF Move(float dx, float dy)
    {
        return this with
        {
            Center = new PointF(Center.X + dx, Center.Y + dy)
        };
    }

    public EllipseF Resize(float scale)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(scale);

        return this with
        {
            RadiusX = RadiusX * scale,
            RadiusY = RadiusY * scale
        };
    }

    public EllipseF Resize(float scaleX, float scaleY)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(scaleX);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(scaleY);

        return this with
        {
            RadiusX = RadiusX * scaleX,
            RadiusY = RadiusY * scaleY
        };
    }

    public EllipseF Rotate(float angleDegrees)
    {
        return this with
        {
            RotationDegrees = RotationDegrees + angleDegrees
        };
    }

    public EllipseF Rotate(float angleDegrees, PointF pivot)
    {
        return this with
        {
            Center = GeometryMath.Rotate(Center, pivot, angleDegrees)
        };
    }

    public RectangleF BoundingRectangle =>
        new(
            Center.X - RadiusX,
            Center.Y - RadiusY,
            RadiusX * 2,
            RadiusY * 2);

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