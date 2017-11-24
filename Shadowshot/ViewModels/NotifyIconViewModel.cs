﻿// Copyright 2017 Victorique Ko
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
using Shadowshot.Views;

namespace Shadowshot.ViewModels
{
    internal class NotifyIconViewModel : ReactiveObject
    {
        internal NotifyIconViewModel()
        {
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

        public ReactiveCommand<Unit, Unit> SettingsCommand { get; }

        public ReactiveCommand<Unit, Unit> AboutCommand { get; }

        public ReactiveCommand<Unit, Unit> ExitCommand { get; }
    }
}
