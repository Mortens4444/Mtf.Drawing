using System.Drawing;
using System.Runtime.InteropServices;

namespace Mtf.Drawing;

internal sealed class Win32ScreenSampler
{
    [DllImport("user32.dll")]
    private static extern IntPtr GetDC(IntPtr hwnd);

    [DllImport("user32.dll")]
    private static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);

    [DllImport("gdi32.dll")]
    private static extern uint GetPixel(IntPtr hdc, int x, int y);

    public Color Sample(IntPtr hwnd, int x, int y)
    {
        var hdc = GetDC(hwnd);
        try
        {
            var pixel = GetPixel(hdc, x, y);

            return Color.FromArgb(
                (int)(pixel & 0x000000FF),
                (int)((pixel & 0x0000FF00) >> 8),
                (int)((pixel & 0x00FF0000) >> 16));
        }
        finally
        {
            ReleaseDC(hwnd, hdc);
        }
    }
}