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

using Shadowshot.Properties;
using Shadowshot.Services.Win32;
using System;
using System.Windows.Forms;

namespace Shadowshot.Services
{
    internal static class HotkeyService
    {
        internal static void Register(IntPtr hwnd)
        {
            NativeMethods.RegisterHotKey(
                hwnd, (int)MainService.Operation.EntireScreenToDesktop,
                (uint)(Settings.Default.entireScreenToDesktopKeyData & Keys.Modifiers) >> 16,
                (uint)(Settings.Default.entireScreenToDesktopKeyData & Keys.KeyCode));
            NativeMethods.RegisterHotKey(
                hwnd, (int)MainService.Operation.ActiveWindowToDesktop,
                (uint)(Settings.Default.activeWindowToDesktopKeyData & Keys.Modifiers) >> 16,
                (uint)(Settings.Default.activeWindowToDesktopKeyData & Keys.KeyCode));
            NativeMethods.RegisterHotKey(
                hwnd, (int)MainService.Operation.EntireScreenToClipboard,
                (uint)(Settings.Default.entireScreenToClipboardKeyData & Keys.Modifiers) >> 16,
                (uint)(Settings.Default.entireScreenToClipboardKeyData & Keys.KeyCode));
            NativeMethods.RegisterHotKey(
                hwnd, (int)MainService.Operation.ActiveWindowToClipboard,
                (uint)(Settings.Default.activeWindowToClipboardKeyData & Keys.Modifiers) >> 16,
                (uint)(Settings.Default.activeWindowToClipboardKeyData & Keys.KeyCode));
        }

        internal static void Unregister(IntPtr hwnd)
        {
            NativeMethods.UnregisterHotKey(hwnd, (int)MainService.Operation.EntireScreenToDesktop);
            NativeMethods.UnregisterHotKey(hwnd, (int)MainService.Operation.ActiveWindowToDesktop);
            NativeMethods.UnregisterHotKey(hwnd, (int)MainService.Operation.EntireScreenToClipboard);
            NativeMethods.UnregisterHotKey(hwnd, (int)MainService.Operation.ActiveWindowToClipboard);
        }
    }
}
