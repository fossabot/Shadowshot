using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Shadowshot.Win32;

namespace Shadowshot.Controller
{
    internal static class ShadowshotController
    {
        internal static void Capture(Operation operation)
        {
            switch (operation)
            {
                case Operation.EntireScreenToFile:
                    using (var image = CaptureEntireScreen())
                    {
                        SaveToFile(image);
                    }
                    break;
                case Operation.ForegroundWindowToFile:
                    using (var image = CaptureForegroundWindow())
                    {
                        SaveToFile(image);
                    }
                    break;
                case Operation.EntireScreenToClipboard:
                    using (var image = CaptureEntireScreen())
                    {
                        SaveToClipboard(image);
                    }
                    break;
                case Operation.ForegroundWindowToClipboard:
                    using (var image = CaptureForegroundWindow())
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

        private static Image CaptureForegroundWindow()
        {
            NativeMethods.DwmGetWindowAttribute(NativeMethods.GetForegroundWindow(),
                NativeMethods.DwmWindowAttribute.DwmwaExtendedFrameBounds,
                out NativeMethods.Rect rect, Marshal.SizeOf(typeof(NativeMethods.Rect)));
            if (rect.Left < 0 && rect.Top < 0)
                return CaptureRectangle(new Rectangle(0, 0, rect.Right + rect.Left, rect.Bottom + rect.Top));
            return CaptureRectangle(new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top));
        }

        private static Image CaptureRectangle(Rectangle rectangle)
        {
            Image result;
            using (var screenshot = new Bitmap(rectangle.Width, rectangle.Height, PixelFormat.Format24bppRgb))
            using (var graphics = Graphics.FromImage(screenshot))
            {
                graphics.CopyFromScreen(rectangle.Left, rectangle.Top, 0, 0, rectangle.Size);
                result = EffectController.ApplyDropShadow(screenshot);
            }
            return result;
        }

        private static void SaveToFile(Image image)
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
            EntireScreenToFile = 1,
            ForegroundWindowToFile = 2,
            EntireScreenToClipboard = 3,
            ForegroundWindowToClipboard = 4
        }
    }
}
