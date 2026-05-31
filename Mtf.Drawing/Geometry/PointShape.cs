using Mtf.Drawing.Interfaces;
using System.Drawing;

namespace Mtf.Drawing.Geometry;

public readonly record struct PointShape(PointF Point) : IShape
{
    public PointF Center => Point;

    public PointShape Move(float dx, float dy)
    {
        return new PointShape(
            new PointF(Point.X + dx, Point.Y + dy));
    }

    public PointShape Rotate(float angle)
    {
        return this;
    }

    public PointShape Resize(float scale)
    {
        return this;
    }

    IShape IShape.Move(float dx, float dy) => Move(dx, dy);
    IShape IShape.Rotate(float angle) => Rotate(angle);
    IShape IShape.Resize(float scale) => Resize(scale);

    public bool Contains(PointF point)
    {
        return Point.X == point.X && Point.Y == point.Y;
    }
}