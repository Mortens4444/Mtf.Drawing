using System.Drawing;

namespace Mtf.Drawing.Interfaces;

public interface IShape
{
    PointF Center { get; }

    IShape Move(float dx, float dy);

    IShape Rotate(float angle);

    IShape Resize(float scale);
}