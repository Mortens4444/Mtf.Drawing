using System.Drawing;

namespace Mtf.Drawing.Geometry;

public readonly record struct OrientedRectF(PointF Center, float Width, float Height, float RotationDegrees)
{
    public OrientedRectF Rotate(float angleDegrees) => this with
    {
        RotationDegrees = RotationDegrees + angleDegrees
    };

    /// <summary>
    /// Axis-aligned bounding box
    /// </summary>
    /// <returns></returns>
    public RectF GetAabb()
    {
        return new RectF(Center.X - Width / 2f, Center.Y - Height / 2f, Width, Height);
    }
}