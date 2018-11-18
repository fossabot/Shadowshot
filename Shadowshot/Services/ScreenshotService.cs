// Copyright 2017-2018 Kagami Studio
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Shadowshot.Services.Win32;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Shadowshot.Services
{
    internal static class ScreenshotService
    {
        internal static Bitmap CaptureEntireScreen()
        {
            int x = NativeMethods.GetSystemMetrics(NativeMethods.SM_XVIRTUALSCREEN);
            int y = NativeMethods.GetSystemMetrics(NativeMethods.SM_YVIRTUALSCREEN);
            int cx = NativeMethods.GetSystemMetrics(NativeMethods.SM_CXVIRTUALSCREEN);
            int cy = NativeMethods.GetSystemMetrics(NativeMethods.SM_CYVIRTUALSCREEN);

            return CaptureRect(new Rectangle(x, y, cx, cy));
        }

        internal static Bitmap CaptureActiveWindow()
        {
            var handle = NativeMethods.GetForegroundWindow();
            NativeMethods.DwmGetWindowAttribute(
                handle, NativeMethods.DwmWindowAttribute.DWMWA_EXTENDED_FRAME_BOUNDS, out var rect, Marshal.SizeOf(typeof(NativeMethods.Rect)));
            NativeMethods.GetWindowInfo(handle, out var windowInfo);
            var rectangle = Rectangle.FromLTRB(rect.Left, rect.Top, rect.Right, rect.Bottom);
            if (NativeMethods.IsZoomed(handle) && rectangle.Left < 0 && rectangle.Top < 0)
            {
                rectangle.Inflate((int)-windowInfo.cxWindowBorders, (int)-windowInfo.cyWindowBorders);
            }
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
