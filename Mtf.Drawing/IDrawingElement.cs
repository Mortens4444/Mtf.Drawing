using System.Drawing;

namespace Mtf.Drawing;

public interface IDrawingElement
{
    void DrawOnGraphics(Graphics graphics);

    void DrawOnGraphics(Graphics graphics, Color color);
}
