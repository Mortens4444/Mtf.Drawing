using System.Drawing;

namespace Mtf.Drawing.Geometry;

public readonly record struct RectF(float X, float Y, float Width, float Height)
{
    public PointF Center => new(X + Width / 2f, Y + Height / 2f);

    public bool Contains(PointF p) => p.X >= X && p.X <= X + Width && p.Y >= Y && p.Y <= Y + Height;

    public RectF Move(float dx, float dy) => this with
    {
        X = X + dx,
        Y = Y + dy
    };

    public RectF Resize(float scale)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(scale);

        var center = Center;
        var newWidth = Width * scale;
        var newHeight = Height * scale;

        return new RectF(center.X - newWidth / 2f, center.Y - newHeight / 2f, newWidth, newHeight);
    }

    public RectF Inflate(float delta)
    {
        return new RectF(X - delta, Y - delta, Width + delta * 2, Height + delta * 2);
    }
}