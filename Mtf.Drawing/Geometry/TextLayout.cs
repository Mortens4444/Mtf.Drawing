using Mtf.Drawing.Interfaces;
using System.Drawing;

namespace Mtf.Drawing.Geometry;

public readonly record struct TextLayout(string Text, PointF Position, float FontSize, float RotationDegrees = 0) : IShape
{
    public PointF Center => Position;

    public bool Contains(PointF point)
    {
        if (String.IsNullOrEmpty(Text))
        {
            return false;
        }

        var width = Text.Length * (FontSize * 0.6f);
        var height = FontSize;

        var bounds = new RectF(
            Position.X,
            Position.Y - (height * 0.8f),
            width,
            height * 1.2f);

        return bounds.Contains(point);
    }

    public RectF Bounds
    {
        get
        {
            var width = Text.Length * (FontSize * 0.6f);
            var height = FontSize;

            return new RectF(
                Position.X,
                Position.Y - (height * 0.8f),
                width,
                height * 1.2f);
        }
    }

    public TextLayout Move(float dx, float dy)
    {
        return this with
        {
            Position = new PointF(
                Position.X + dx,
                Position.Y + dy)
        };
    }

    public TextLayout Resize(float scale)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(scale);

        return this with
        {
            FontSize = Math.Clamp(FontSize * scale, 8f, 200f)
        };
    }

    public TextLayout Rotate(float angleDegrees) => this with
    {
        RotationDegrees = RotationDegrees + angleDegrees
    };

    public TextLayout Rotate(float angleDegrees, PointF pivot)
    {
        return this with
        {
            Position = GeometryMath.Rotate(Position, pivot, angleDegrees)
        };
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
}