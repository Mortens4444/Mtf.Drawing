using System.Drawing;

namespace Mtf.Drawing;

public class String : IDrawingElement
{
    public byte X { get; }

    public byte Y { get; }

    public string Text { get; }

    public FontType FontType { get; }

    public String(Point point, string text)
        : this(point.X, point.Y, text, FontType.Normal)
    { }

    public String(Point point, string text, FontType fontType)
        : this(point.X, point.Y, text, fontType)
    { }

    public String(byte x, byte y, string text)
        : this(x, y, text, FontType.Normal)
    { }

    public String(byte x, byte y, string text, FontType fontType)
    {
        X = x;
        Y = y;
        Text = text;
        FontType = fontType;
    }

    public void DrawOnGraphics(Graphics graphics)
    {
        DrawOnGraphics(graphics, Color.Black);
    }

    public void DrawOnGraphics(Graphics graphics, Color color)
    {
        var fontSize = (float)(Math.Pow(2, (int)FontType) * 5);
        graphics.DrawString(Text, new Font(FontFamily.GenericSerif, fontSize), new SolidBrush(color), X, Y);
    }
}
