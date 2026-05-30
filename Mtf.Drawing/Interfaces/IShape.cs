using System.Drawing;

namespace Mtf.Drawing.Interfaces;

public interface IShape
{
    PointF Center { get; }

    bool Contains(PointF point);

    IShape Move(float dx, float dy);

    IShape Rotate(float angle);

    IShape Resize(float scale);
}