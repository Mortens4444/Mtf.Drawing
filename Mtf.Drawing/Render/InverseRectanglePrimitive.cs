using Mtf.Drawing.Geometry;
using Mtf.Drawing.Interfaces;
using System.Drawing;

namespace Mtf.Drawing.Render;

public class InverseRectanglePrimitive : IDrawingElement
{
    private readonly Win32ScreenSampler sampler = new();

    public RectF Rect { get; set; }

    public IntPtr ParentHandle { get; set; }

    public void DrawOnGraphics(Graphics g)
    {
        if (g is null)
        {
            return;
        }

        for (int x = (int)Rect.X; x < Rect.X + Rect.Width; x++)
        {
            for (int y = (int)Rect.Y; y < Rect.Y + Rect.Height; y++)
            {
                var pixel = sampler.Sample(ParentHandle, x, y);

                var inverted = Color.FromArgb(
                    255 - pixel.R,
                    255 - pixel.G,
                    255 - pixel.B);

                using var brush = new SolidBrush(inverted);
                g.FillRectangle(brush, x, y, 1, 1);
            }
        }
    }

    public void DrawOnGraphics(Graphics g, Color color)
    {
        throw new NotImplementedException();
    }
}