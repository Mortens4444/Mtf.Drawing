using System.Drawing;

namespace Mtf.Drawing.Interfaces;

public interface IDrawingElement
{
    void DrawOnGraphics(Graphics graphics);

    void DrawOnGraphics(Graphics graphics, Color color);
}
