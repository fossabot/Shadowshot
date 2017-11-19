using ReactiveUI;
using Shadowshot.Services;
using Shadowshot.Services.Win32;
using Splat;
using System;
using System.Windows.Interop;

namespace Shadowshot.ViewModels
{
    internal class MainViewModel : ReactiveObject
    {
        private readonly HotkeyService _hotkeyService = Locator.CurrentMutable.GetService<HotkeyService>();

        internal MainViewModel()
        {
        }

        internal void RegisterHotkey(IntPtr handle)
        {
            var source = HwndSource.FromHwnd(handle);
            if (source == null)
                return;
            source.AddHook(WndProc);
            _hotkeyService.Handle = handle;
            _hotkeyService.RegisterHotKey();
        }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == NativeMethods.WmHotkey)
            {
                _hotkeyService.HandleHotkey((HotkeyService.Operation)wParam.ToInt32());
                handled = true;
            }
            
            return IntPtr.Zero;
        }
    }
}
