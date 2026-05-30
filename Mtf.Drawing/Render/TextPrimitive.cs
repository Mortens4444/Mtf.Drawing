using Mtf.Drawing.Interfaces;
using System.Drawing;

namespace Mtf.Drawing.Render;

public class TextPrimitive : PrimitiveBase, IDrawingElement
{
    public float X { get; set; }
    public float Y { get; set; }

    public string Text { get; set; }

    public FontType FontType { get; set; }

    public TextPrimitive(PointPrimitive point, string text)
        : this(point.Point.X, point.Point.Y, text, FontType.Normal)
    {
    }

    public TextPrimitive(PointPrimitive point, string text, FontType fontType)
        : this(point.Point.X, point.Point.Y, text, fontType)
    {
    }

    public TextPrimitive(float x, float y, string text)
        : this(x, y, text, FontType.Normal)
    {
    }

    public TextPrimitive(float x, float y, string text, FontType fontType)
    {
        X = x;
        Y = y;
        Text = text;
        FontType = fontType;
    }

    public override void DrawOnGraphics(Graphics graphics, Color color)
    {
        if (graphics is null || string.IsNullOrEmpty(Text))
        {
            return;
        }

        var fontSize = (float)(Math.Pow(2, (int)FontType) * 5);

        using var font = new Font(FontFamily.GenericSerif, fontSize);
        using var brush = new SolidBrush(color);

        graphics.DrawString(Text, font, brush, X, Y);
    }
}