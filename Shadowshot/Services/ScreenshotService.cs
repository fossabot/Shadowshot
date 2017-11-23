using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;
using Shadowshot.Services.Win32;

namespace Shadowshot.Services
{
    internal class ScreenshotService
    {
        internal Bitmap CaptureEntireScreen()
        {
            return CaptureRect(new Rectangle(
                (int) SystemParameters.VirtualScreenLeft, (int) SystemParameters.VirtualScreenTop,
                (int) SystemParameters.VirtualScreenWidth, (int) SystemParameters.VirtualScreenHeight));
        }

        internal Bitmap CaptureActiveWindow()
        {
            var handle = NativeMethods.GetForegroundWindow();
            NativeMethods.DwmGetWindowAttribute(
                handle, NativeMethods.DwmWindowAttribute.DwmwaExtendedFrameBounds,
                out var rect, Marshal.SizeOf(typeof(NativeMethods.Rect)));
            NativeMethods.GetWindowInfo(handle, out var windowInfo);
            var rectangle = Rectangle.FromLTRB(rect.Left, rect.Top, rect.Right, rect.Bottom);
            if (NativeMethods.IsZoomed(handle) && rectangle.Left < 0 && rectangle.Top < 0)
                rectangle.Inflate((int) -windowInfo.cxWindowBorders, (int) -windowInfo.cyWindowBorders);
            return CaptureRect(rectangle);
        }

        private static Bitmap CaptureRect(Rectangle rect)
        {
            var screenshot = new Bitmap(rect.Width, rect.Height);
            using (var graphics = Graphics.FromImage(screenshot))
            {
                graphics.CopyFromScreen(rect.Left, rect.Top, 0, 0, rect.Size);
            }
            return screenshot;
        }
    }
}
