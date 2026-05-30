using System.Drawing;

namespace Mtf.Drawing.Interfaces;

public interface IPrimitive
{
    void DrawOnGraphics(Graphics graphics);

    void DrawOnGraphics(Graphics graphics, Color color);
}
