using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reactive;
using System.Windows.Input;
using ReactiveUI;
using Shadowshot.Models;
using Shadowshot.Services;
using Splat;
using static Shadowshot.Services.HotkeyService.Operation;

namespace Shadowshot.ViewModels
{
    internal class SettingsViewModel : ReactiveObject
    {
        private readonly AutoStartService _autoStartService = Locator.CurrentMutable.GetService<AutoStartService>();
        private readonly HotkeyService _hotkeyService = Locator.CurrentMutable.GetService<HotkeyService>();

        private readonly Dictionary<HotkeyService.Operation, HotkeyModel> _hotkeys;

        internal SettingsViewModel()
        {
            _hotkeyService.UnregisterHotKey();

            IsAutoStart = _autoStartService.IsEnabled;

            _hotkeys = _hotkeyService.Hotkeys;

            OkCommand = ReactiveCommand.Create(() =>
            {
                _autoStartService.IsEnabled = IsAutoStart;

                _hotkeyService.Hotkeys = _hotkeys;
                _hotkeyService.RegisterHotKey();

                RequestClose?.Invoke();
            });

            CancelCommand = ReactiveCommand.Create(() => RequestClose?.Invoke());
        }

        public bool IsAutoStart { get; set; }

        public string EntireScreenToDesktopHotkeyText
        {
            get => HotkeyToString(_hotkeys[EntireScreenToDesktop]);
            set => _hotkeys[EntireScreenToDesktop] = StringToHotkey(value);
        }

        public string ActiveWindowToDesktopHotkeyText
        {
            get => HotkeyToString(_hotkeys[ActiveWindowToDesktop]);
            set => _hotkeys[ActiveWindowToDesktop] = StringToHotkey(value);
        }

        public string EntireScreenToClipboardHotkeyText
        {
            get => HotkeyToString(_hotkeys[EntireScreenToClipboard]);
            set => _hotkeys[EntireScreenToClipboard] = StringToHotkey(value);
        }

        public string ActiveWindowToClipboardHotkeyText
        {
            get => HotkeyToString(_hotkeys[ActiveWindowToClipboard]);
            set => _hotkeys[ActiveWindowToClipboard] = StringToHotkey(value);
        }

        public ReactiveCommand<Unit, Unit> OkCommand { get; }

        public ReactiveCommand<Unit, Unit> CancelCommand { get; }

        internal event Action RequestClose;

        private static string HotkeyToString(HotkeyModel value)
        {
            var modifierKeysConverter = TypeDescriptor.GetConverter(typeof(ModifierKeys));
            var modifierKeysText = modifierKeysConverter.ConvertToString(value.ModifierKeys);

            var keyConverter = TypeDescriptor.GetConverter(typeof(Key));
            var keyText = keyConverter.ConvertToString(value.Key);

            return $"{modifierKeysText}+{keyText}";
        }

        private static HotkeyModel StringToHotkey(string text)
        {
            var index = text.LastIndexOf('+');
            var modifierKeysText = text.Substring(0, index);
            var keyText = text.Substring(index + 1);
            
            var modifierKeysConverter = TypeDescriptor.GetConverter(typeof(ModifierKeys));
            var modifierKeys = (ModifierKeys)modifierKeysConverter.ConvertFromString(modifierKeysText);

            var keyConverter = TypeDescriptor.GetConverter(typeof(Key));
            var key = (Key)keyConverter.ConvertFromString(keyText);

            return new HotkeyModel
            {
                ModifierKeys = modifierKeys,
                Key = key
            };
        }
    }
}
