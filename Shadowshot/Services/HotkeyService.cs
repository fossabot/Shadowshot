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
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using Newtonsoft.Json;
using Shadowshot.Models;
using Shadowshot.Properties;
using Shadowshot.Services.Win32;
using Splat;

namespace Shadowshot.Services
{
    internal class HotkeyService
    {
        private readonly string _hotkeysPath;
        private Dictionary<Operation, HotkeyModel> _hotkeys;

        internal HotkeyService()
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var appName = Assembly.GetEntryAssembly().GetName().Name;
            var configFolderPath = Path.Combine(appDataPath, appName);

            if (!Directory.Exists(configFolderPath))
                Directory.CreateDirectory(configFolderPath);

            _hotkeysPath = Path.Combine(configFolderPath, "Hotkeys.json");

            if (!File.Exists(_hotkeysPath))
            {
                _hotkeys = new Dictionary<Operation, HotkeyModel>
                {
                    {
                        Operation.EntireScreenToDesktop,
                        new HotkeyModel
                        {
                            ModifierKeys = ModifierKeys.Alt | ModifierKeys.Shift,
                            Key = Key.D3
                        }
                    },
                    {
                        Operation.ActiveWindowToDesktop,
                        new HotkeyModel
                        {
                            ModifierKeys = ModifierKeys.Alt | ModifierKeys.Shift,
                            Key = Key.D4
                        }
                    },
                    {
                        Operation.EntireScreenToClipboard,
                        new HotkeyModel
                        {
                            ModifierKeys = ModifierKeys.Control | ModifierKeys.Alt | ModifierKeys.Shift,
                            Key = Key.D3
                        }
                    },
                    {
                        Operation.ActiveWindowToClipboard,
                        new HotkeyModel
                        {
                            ModifierKeys = ModifierKeys.Control | ModifierKeys.Alt | ModifierKeys.Shift,
                            Key = Key.D4
                        }
                    }
                };
                File.WriteAllText(_hotkeysPath, JsonConvert.SerializeObject(_hotkeys));
                return;
            }

            _hotkeys =
                JsonConvert.DeserializeObject<Dictionary<Operation, HotkeyModel>>(File.ReadAllText(_hotkeysPath));
        }

        internal Dictionary<Operation, HotkeyModel> Hotkeys
        {
            get => _hotkeys;
            set
            {
                _hotkeys = value;
                File.WriteAllText(_hotkeysPath, JsonConvert.SerializeObject(_hotkeys));
            }
        }

        internal IntPtr Handle { private get; set; }

        internal void RegisterHotKey()
        {
            foreach (var hotkey in Hotkeys)
                NativeMethods.RegisterHotKey(Handle, (int) hotkey.Key,
                    hotkey.Value.ModifierKeys, KeyInterop.VirtualKeyFromKey(hotkey.Value.Key));
        }

        internal void UnregisterHotKey()
        {
            foreach (var hotkey in Hotkeys)
                NativeMethods.UnregisterHotKey(Handle, (int) hotkey.Key);
        }

        internal void HandleHotkey(Operation operation)
        {
            new Thread(() =>
            {
                Thread.Sleep(500);

                Bitmap bitmap;
                switch (operation)
                {
                    case Operation.EntireScreenToDesktop:
                    case Operation.EntireScreenToClipboard:
                        bitmap = Locator.CurrentMutable.GetService<ScreenshotService>().CaptureEntireScreen();
                        break;
                    case Operation.ActiveWindowToDesktop:
                    case Operation.ActiveWindowToClipboard:
                        bitmap = Locator.CurrentMutable.GetService<ScreenshotService>().CaptureActiveWindow();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(operation), operation, null);
                }

                bitmap = Locator.CurrentMutable.GetService<EffectService>().DropShadow(bitmap);

                switch (operation)
                {
                    case Operation.EntireScreenToDesktop:
                    case Operation.ActiveWindowToDesktop:
                        var dateTime = DateTime.Now;
                        var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        var filename = string.Format(Strings.FilenameFormat, dateTime);
                        bitmap.Save(Path.Combine(desktopPath, filename));
                        break;
                    case Operation.EntireScreenToClipboard:
                    case Operation.ActiveWindowToClipboard:
                        using (var bitmapWithBackground = new Bitmap(bitmap.Width, bitmap.Height))
                        {
                            using (var graphics = Graphics.FromImage(bitmapWithBackground))
                            {
                                graphics.Clear(Color.White);
                                graphics.DrawImage(bitmap, System.Drawing.Point.Empty);
                            }

                            var hBitmap = bitmapWithBackground.GetHbitmap();
                            var bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(
                                hBitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                            NativeMethods.DeleteObject(hBitmap);
                            Clipboard.SetImage(bitmapSource);
                        }

                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(operation), operation, null);
                }
            }).Start();
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
