using Newtonsoft.Json;
using Shadowshot.Models;
using Shadowshot.Services.Win32;
using Splat;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using static System.Windows.Input.Key;
using static System.Windows.Input.ModifierKeys;
using static Shadowshot.Services.HotkeyService.Operation;

namespace Shadowshot.Services
{
    internal class HotkeyService
    {
        private Dictionary<Operation, HotkeyModel> _hotkeys;

        private readonly string _hotkeysPath;

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
                        EntireScreenToDesktop,
                        new HotkeyModel
                        {
                            ModifierKeys = Alt | Shift,
                            Key = D3
                        }
                    },
                    {
                        ActiveWindowToDesktop,
                        new HotkeyModel
                        {
                            ModifierKeys = Alt | Shift,
                            Key = D4
                        }
                    },
                    {
                        EntireScreenToClipboard,
                        new HotkeyModel
                        {
                            ModifierKeys = Control | Alt | Shift,
                            Key = D3
                        }
                    },
                    {
                        ActiveWindowToClipboard,
                        new HotkeyModel
                        {
                            ModifierKeys = Control | Alt | Shift,
                            Key = D4
                        }
                    }
                };
                File.WriteAllText(_hotkeysPath, JsonConvert.SerializeObject(_hotkeys));
                return;
            }

            _hotkeys = JsonConvert.DeserializeObject<Dictionary<Operation, HotkeyModel>>(File.ReadAllText(_hotkeysPath));
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

        internal IntPtr Handle { get; set; }

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
            Bitmap bitmap;
            switch (operation)
            {
                case EntireScreenToDesktop:
                case EntireScreenToClipboard:
                    bitmap = Locator.CurrentMutable.GetService<ScreenshotService>().CaptureEntireScreen();
                    break;
                case ActiveWindowToDesktop:
                case ActiveWindowToClipboard:
                    bitmap = Locator.CurrentMutable.GetService<ScreenshotService>().CaptureActiveWindow();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(operation), operation, null);
            }

            bitmap = Locator.CurrentMutable.GetService<EffectService>().DropShadow(bitmap);

            switch (operation)
            {
                case EntireScreenToDesktop:
                case ActiveWindowToDesktop:
                    var dateTime = DateTime.Now;
                    bitmap.Save(
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                            $"Screen Shot {dateTime:yyyy-MM-dd} at {dateTime:h.mm.ss tt}.png"));
                    break;
                case EntireScreenToClipboard:
                case ActiveWindowToClipboard:
                    var hBitmap = bitmap.GetHbitmap();
                    var bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(hBitmap,
                        IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    NativeMethods.DeleteObject(hBitmap);
                    Clipboard.SetImage(bitmapSource);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(operation), operation, null);
            }
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
