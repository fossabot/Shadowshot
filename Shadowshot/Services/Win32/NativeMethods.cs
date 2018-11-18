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

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Shadowshot.Services.Win32
{
    internal static class NativeMethods
    {
        internal struct WindowInfo
        {
            private readonly uint cbSize;
            private readonly Rect rcWindow;
            private readonly Rect rcClient;
            private readonly uint dwStyle;
            private readonly uint dwExStyle;
            private readonly uint dwWindowStatus;
            internal readonly uint cxWindowBorders;
            internal readonly uint cyWindowBorders;
            private readonly ushort atomWindowType;
            private readonly ushort wCreatorVersion;
        }
        
        internal struct Rect
        {
            internal readonly int Left;
            internal readonly int Top;
            internal readonly int Right;
            internal readonly int Bottom;
        }

        internal const int SM_XVIRTUALSCREEN = 76;
        internal const int SM_YVIRTUALSCREEN = 77;
        internal const int SM_CXVIRTUALSCREEN = 78;
        internal const int SM_CYVIRTUALSCREEN = 79;

        internal const int WM_HOTKEY = 0x0312;

        internal const long APPMODEL_ERROR_NO_PACKAGE = 15700;

        internal enum DwmWindowAttribute
        {
            DWMWA_EXTENDED_FRAME_BOUNDS = 9
        }

        [DllImport("dwmapi.dll")]
        internal static extern int DwmGetWindowAttribute(IntPtr hwnd, DwmWindowAttribute dwAttribute, out Rect pvAttribute, int cbAttribute);

        [DllImport("kernel32.dll")]
        internal static extern int GetCurrentPackageFullName(ref int packageFullNameLength, StringBuilder packageFullName);

        [DllImport("user32.dll")]
        internal static extern int GetSystemMetrics(int nIndex);

        [DllImport("user32.dll")]
        internal static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        internal static extern bool GetWindowInfo(IntPtr hwnd, out WindowInfo pwi);

        [DllImport("user32.dll")]
        internal static extern bool IsZoomed(IntPtr hwnd);

        [DllImport("user32.dll")]
        internal static extern bool RegisterHotKey(IntPtr hwnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        internal static extern bool UnregisterHotKey(IntPtr hwnd, int id);
    }
}
