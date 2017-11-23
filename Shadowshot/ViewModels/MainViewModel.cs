using System;
using System.Windows.Interop;
using ReactiveUI;
using Shadowshot.Services;
using Shadowshot.Services.Win32;
using Splat;

namespace Shadowshot.ViewModels
{
    internal class MainViewModel : ReactiveObject
    {
        private readonly HotkeyService _hotkeyService = Locator.CurrentMutable.GetService<HotkeyService>();

        internal void RegisterHotkey(IntPtr handle)
        {
            var source = HwndSource.FromHwnd(handle);
            source?.AddHook(WndProc);
            _hotkeyService.Handle = handle;
            _hotkeyService.RegisterHotKey();
        }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == NativeMethods.WmHotkey)
            {
                _hotkeyService.HandleHotkey((HotkeyService.Operation) wParam.ToInt32());
                handled = true;
            }

            return IntPtr.Zero;
        }
    }
}
