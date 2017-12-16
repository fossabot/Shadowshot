// Copyright 2017 Kagami Studio
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

using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows;
using Shadowshot.Services.Win32;

namespace Shadowshot.Services
{
    internal class ScreenshotService
    {
        internal Bitmap CaptureEntireScreen()
        {
            var dpiXProperty = typeof(SystemParameters).GetProperty("DpiX", BindingFlags.NonPublic | BindingFlags.Static);
            var dpiYProperty = typeof(SystemParameters).GetProperty("Dpi", BindingFlags.NonPublic | BindingFlags.Static);

            if (dpiXProperty == null || dpiYProperty == null)
                throw new NullReferenceException();

            var dpiX = (int) dpiXProperty.GetValue(null);
            var dpiY = (int) dpiYProperty.GetValue(null);

            return CaptureRect(new Rectangle(
                (int) SystemParameters.VirtualScreenLeft, (int) SystemParameters.VirtualScreenTop,
                (int) SystemParameters.VirtualScreenWidth * dpiX / 96, (int) SystemParameters.VirtualScreenHeight * dpiY / 96));
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
