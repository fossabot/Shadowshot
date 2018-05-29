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

using System.Reactive;
using System.Windows;
using ReactiveUI;
using Shadowshot.Services;
using Shadowshot.Views;
using Splat;

namespace Shadowshot.ViewModels
{
    internal class NotifyIconViewModel : ReactiveObject
    {
        private readonly HotkeyService _hotkeyService = Locator.CurrentMutable.GetService<HotkeyService>();

        internal NotifyIconViewModel()
        {
            EntireScreenToDesktopCommand = ReactiveCommand.Create(() =>
            {
                _hotkeyService.HandleHotkey(HotkeyService.Operation.EntireScreenToDesktop);
            });

            ActiveWindowToDesktopCommand = ReactiveCommand.Create(() =>
            {
                _hotkeyService.HandleHotkey(HotkeyService.Operation.ActiveWindowToDesktop);
            });

            EntireScreenToClipboardCommand = ReactiveCommand.Create(() =>
            {
                _hotkeyService.HandleHotkey(HotkeyService.Operation.EntireScreenToClipboard);
            });

            ActiveWindowToClipboardCommand = ReactiveCommand.Create(() =>
            {
                _hotkeyService.HandleHotkey(HotkeyService.Operation.ActiveWindowToClipboard);
            });

            SettingsCommand = ReactiveCommand.Create(() =>
            {
                var view = new SettingsView();
                view.ShowDialog();
            });

            AboutCommand = ReactiveCommand.Create(() =>
            {
                var view = new AboutView();
                view.ShowDialog();
            });

            ExitCommand = ReactiveCommand.Create(() => Application.Current.Shutdown());
        }

        public ReactiveCommand<Unit, Unit> EntireScreenToDesktopCommand { get; }

        public ReactiveCommand<Unit, Unit> ActiveWindowToDesktopCommand { get; }

        public ReactiveCommand<Unit, Unit> EntireScreenToClipboardCommand { get; }

        public ReactiveCommand<Unit, Unit> ActiveWindowToClipboardCommand { get; }

        public ReactiveCommand<Unit, Unit> SettingsCommand { get; }

        public ReactiveCommand<Unit, Unit> AboutCommand { get; }

        public ReactiveCommand<Unit, Unit> ExitCommand { get; }
    }
}
