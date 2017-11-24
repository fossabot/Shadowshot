// Copyright 2017 Victorique Ko
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
