// Copyright 2017-2018 Victorique Ko
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
using System.ComponentModel;
using System.Reactive;
using System.Windows.Input;
using ReactiveUI;
using Shadowshot.Models;
using Shadowshot.Services;
using Splat;

namespace Shadowshot.ViewModels
{
    internal class SettingsViewModel : ReactiveObject
    {
        private readonly AutoStartService _autoStartService = Locator.CurrentMutable.GetService<AutoStartService>();

        private readonly Dictionary<HotkeyService.Operation, HotkeyModel> _hotkeys;
        private readonly HotkeyService _hotkeyService = Locator.CurrentMutable.GetService<HotkeyService>();

        internal SettingsViewModel()
        {
            _hotkeyService.UnregisterHotKey();

            IsAutoStart = _autoStartService.IsEnabled;
            IsAutoStartEnabled = !_autoStartService.IsDisabledByUser;

            _hotkeys = _hotkeyService.Hotkeys;

            OkCommand = ReactiveCommand.Create(() =>
            {
                _autoStartService.IsEnabled = IsAutoStart;

                _hotkeyService.Hotkeys = _hotkeys;

                RequestClose?.Invoke();
            });

            CancelCommand = ReactiveCommand.Create(() => RequestClose?.Invoke());
        }

        public bool IsAutoStart { get; set; }

        public bool IsAutoStartEnabled { get; }

        public string EntireScreenToDesktopHotkeyText
        {
            get => HotkeyToString(_hotkeys[HotkeyService.Operation.EntireScreenToDesktop]);
            set => _hotkeys[HotkeyService.Operation.EntireScreenToDesktop] = StringToHotkey(value);
        }

        public string ActiveWindowToDesktopHotkeyText
        {
            get => HotkeyToString(_hotkeys[HotkeyService.Operation.ActiveWindowToDesktop]);
            set => _hotkeys[HotkeyService.Operation.ActiveWindowToDesktop] = StringToHotkey(value);
        }

        public string EntireScreenToClipboardHotkeyText
        {
            get => HotkeyToString(_hotkeys[HotkeyService.Operation.EntireScreenToClipboard]);
            set => _hotkeys[HotkeyService.Operation.EntireScreenToClipboard] = StringToHotkey(value);
        }

        public string ActiveWindowToClipboardHotkeyText
        {
            get => HotkeyToString(_hotkeys[HotkeyService.Operation.ActiveWindowToClipboard]);
            set => _hotkeys[HotkeyService.Operation.ActiveWindowToClipboard] = StringToHotkey(value);
        }

        public ReactiveCommand<Unit, Unit> OkCommand { get; }

        public ReactiveCommand<Unit, Unit> CancelCommand { get; }

        internal event Action RequestClose;

        internal void OnViewClosing(object sender, CancelEventArgs e)
        {
            _hotkeyService.RegisterHotKey();
        }

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
            var modifierKeys = (ModifierKeys) modifierKeysConverter.ConvertFromString(modifierKeysText);

            var keyConverter = TypeDescriptor.GetConverter(typeof(Key));
            var key = (Key) keyConverter.ConvertFromString(keyText);

            return new HotkeyModel
            {
                ModifierKeys = modifierKeys,
                Key = key
            };
        }
    }
}
