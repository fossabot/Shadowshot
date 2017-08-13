using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Shadowshot.Win32
{
    internal static class NativeMethods
    {
        internal const uint ModAlt = 0x0001;
        internal const uint ModControl = 0x0002;
        internal const uint ModShift = 0x0004;
        internal const uint WmHotkey = 0x0312;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern bool RegisterHotKey(IntPtr hwnd, int id, uint fsModifiers, Keys vk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern bool UnregisterHotKey(IntPtr hwnd, int id);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern bool IsZoomed(IntPtr hwnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern bool GetWindowInfo(IntPtr hwnd, out WindowInfo pwi);

        [DllImport("dwmapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern int DwmGetWindowAttribute(
            IntPtr hwnd, DwmWindowAttribute dwAttribute, out Rect pvAttribute, int cbAttribute);

        [StructLayout(LayoutKind.Sequential)]
        internal struct Rect
        {
            internal readonly int Left;
            internal readonly int Top;
            internal readonly int Right;
            internal readonly int Bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
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

        internal enum DwmWindowAttribute
        {
            DwmwaExtendedFrameBounds = 9
        }
    }
}
