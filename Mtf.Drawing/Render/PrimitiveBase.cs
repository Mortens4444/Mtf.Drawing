using Mtf.Drawing.Interfaces;
using System.Drawing;

namespace Mtf.Drawing.Render
{
    public abstract class PrimitiveBase : IPrimitive
    {
        public void DrawOnGraphics(Graphics g)
        {
            DrawOnGraphics(g, Color.Black);
        }

        public abstract void DrawOnGraphics(Graphics g, Color color);
    }
}
