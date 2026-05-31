using Mtf.Drawing.Geometry;
using Mtf.Drawing.Interfaces;
using System.Drawing;

namespace Mtf.Drawing.Render;

public class TextPrimitive : PrimitiveBase
{
    public TextLayout Layout { get; set; }

    public override IShape Shape => Layout;

    public TextPrimitive(TextLayout layout)
    {
        Layout = layout;
    }

    public TextPrimitive(PointPrimitive point, string text)
        : this(point.ShapeData.Point.X, point.ShapeData.Point.Y, text, FontType.Normal)
    {
    }

    public TextPrimitive(PointPrimitive point, string text, FontType fontType)
        : this(point.ShapeData.Point.X, point.ShapeData.Point.Y, text, fontType)
    {
    }

    public TextPrimitive(float x, float y, string text)
        : this(x, y, text, FontType.Normal)
    {
    }

    public TextPrimitive(float x, float y, string text, FontType fontType)
    {
        Layout = new TextLayout(text, new PointF(x, y), (float)fontType);
    }

    public override void DrawOnGraphics(Graphics graphics, Color color)
    {
        if (graphics is null || String.IsNullOrEmpty(Layout.Text))
        {
            return;
        }

        using var font = new Font(FontFamily.GenericSerif, Layout.FontSize);
        using var brush = new SolidBrush(color);

        if (Layout.RotationDegrees != 0)
        {
            graphics.TranslateTransform(Layout.Position.X, Layout.Position.Y);
            graphics.RotateTransform(Layout.RotationDegrees);
            graphics.DrawString(Layout.Text, font, brush, 0, 0);
            graphics.ResetTransform();
        }
        else
        {
            graphics.DrawString(Layout.Text, font, brush, Layout.Position.X, Layout.Position.Y);
        }
    }
}