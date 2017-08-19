using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Shadowshot.Win32;

namespace Shadowshot.Controllers
{
    internal static class ShadowshotController
    {
        internal static void Capture(Operation operation)
        {
            switch (operation)
            {
                case Operation.EntireScreenToDesktop:
                    using (var image = CaptureEntireScreen())
                    {
                        SaveToDesktop(image);
                    }
                    break;
                case Operation.ActiveWindowToDesktop:
                    using (var image = CaptureActiveWindow())
                    {
                        SaveToDesktop(image);
                    }
                    break;
                case Operation.EntireScreenToClipboard:
                    using (var image = CaptureEntireScreen())
                    {
                        SaveToClipboard(image);
                    }
                    break;
                case Operation.ActiveWindowToClipboard:
                    using (var image = CaptureActiveWindow())
                    {
                        SaveToClipboard(image);
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(operation), operation, null);
            }
        }

        private static Image CaptureEntireScreen()
        {
            return CaptureRectangle(
                Screen.AllScreens.Aggregate(Rectangle.Empty,
                    (current, screen) => Rectangle.Union(current, screen.Bounds)));
        }

        private static Image CaptureActiveWindow()
        {
            var handle = NativeMethods.GetForegroundWindow();
            NativeMethods.DwmGetWindowAttribute(handle, NativeMethods.DwmWindowAttribute.DwmwaExtendedFrameBounds,
                out NativeMethods.Rect rect, Marshal.SizeOf(typeof(NativeMethods.Rect)));
            NativeMethods.GetWindowInfo(handle, out NativeMethods.WindowInfo windowInfo);
            var rectangle = Rectangle.FromLTRB(rect.Left, rect.Top, rect.Right, rect.Bottom);
            if (NativeMethods.IsZoomed(handle) && rectangle.Left < 0 && rectangle.Top < 0)
                rectangle.Inflate((int) -windowInfo.cxWindowBorders, (int) -windowInfo.cyWindowBorders);
            return CaptureRectangle(rectangle);
        }

        private static Image CaptureRectangle(Rectangle rectangle)
        {
            Image result;
            using (var screenshot = new Bitmap(rectangle.Width, rectangle.Height, PixelFormat.Format24bppRgb))
            using (var graphics = Graphics.FromImage(screenshot))
            {
                graphics.CopyFromScreen(rectangle.Left, rectangle.Top, 0, 0, rectangle.Size);
                result = EffectsController.Shadow(screenshot);
            }
            return result;
        }

        private static void SaveToDesktop(Image image)
        {
            var dateTime = DateTime.Now;
            image.Save(
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    $"Screen Shot {dateTime:yyyy-MM-dd} at {dateTime:h.mm.ss tt}.png"), ImageFormat.Png);
        }

        private static void SaveToClipboard(Image image)
        {
            using (var imageWithBackground = new Bitmap(image.Width, image.Height, PixelFormat.Format24bppRgb))
            using (var graphics = Graphics.FromImage(imageWithBackground))
            {
                graphics.Clear(Color.White);
                graphics.DrawImage(image, Point.Empty);
                Clipboard.SetImage(imageWithBackground);
            }
        }

        internal enum Operation
        {
            EntireScreenToDesktop,
            ActiveWindowToDesktop,
            EntireScreenToClipboard,
            ActiveWindowToClipboard
        }
    }
}
