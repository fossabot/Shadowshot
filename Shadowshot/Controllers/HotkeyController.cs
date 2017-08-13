using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;
using Shadowshot.Win32;

namespace Shadowshot.Controllers
{
    internal static class HotkeyController
    {
        private static Dictionary<ShadowshotController.Operation, Tuple<uint, Keys>> _hotkeys;

        private static readonly string HotkeysPath =
            Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) ?? string.Empty, "Hotkeys.json");

        static HotkeyController()
        {
            if (File.Exists(HotkeysPath))
            {
                _hotkeys = JsonConvert.DeserializeObject<Dictionary<ShadowshotController.Operation, Tuple<uint, Keys>>>(
                    File.ReadAllText(HotkeysPath));
            }
            else
            {
                _hotkeys = new Dictionary<ShadowshotController.Operation, Tuple<uint, Keys>>
                {
                    {
                        ShadowshotController.Operation.EntireScreenToDesktop,
                        new Tuple<uint, Keys>(
                            NativeMethods.ModAlt | NativeMethods.ModShift, Keys.D3)
                    },
                    {
                        ShadowshotController.Operation.ActiveWindowToDesktop,
                        new Tuple<uint, Keys>(
                            NativeMethods.ModAlt | NativeMethods.ModShift, Keys.D4)
                    },
                    {
                        ShadowshotController.Operation.EntireScreenToClipboard,
                        new Tuple<uint, Keys>(
                            NativeMethods.ModControl | NativeMethods.ModAlt | NativeMethods.ModShift, Keys.D3)
                    },
                    {
                        ShadowshotController.Operation.ActiveWindowToClipboard,
                        new Tuple<uint, Keys>(
                            NativeMethods.ModControl | NativeMethods.ModAlt | NativeMethods.ModShift, Keys.D4)
                    }
                };
                File.WriteAllText(HotkeysPath, JsonConvert.SerializeObject(_hotkeys));
            }
        }

        internal static Dictionary<ShadowshotController.Operation, Tuple<uint, Keys>> Hotkeys
        {
            get => _hotkeys;
            set
            {
                _hotkeys = value;
                File.WriteAllText(HotkeysPath, JsonConvert.SerializeObject(_hotkeys));
            }
        }

        internal static void RegisterHotKey(IntPtr handle)
        {
            foreach (var hotkey in Hotkeys)
                NativeMethods.RegisterHotKey(handle, (int) hotkey.Key, hotkey.Value.Item1, hotkey.Value.Item2);
        }

        internal static void UnregisterHotKey(IntPtr handle)
        {
            foreach (var hotkey in Hotkeys)
                NativeMethods.UnregisterHotKey(handle, (int) hotkey.Key);
        }

        internal static void HandleHotkey(ShadowshotController.Operation operation)
        {
            var thread = new Thread(() => ShadowshotController.Capture(operation));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
    }
}
