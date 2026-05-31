using Mtf.Drawing.Geometry;

namespace Mtf.Drawing.Interfaces;

public interface IShapeRenderer
{
    void Draw(CircleF circle);

    void Draw(RectF rectangle);

    void Draw(LineF line);

    void Draw(PolylineF polyline);

    void Draw(TextLayout text);
}
