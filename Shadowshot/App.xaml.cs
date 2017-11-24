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

using System.Globalization;
using Hardcodet.Wpf.TaskbarNotification;
using Shadowshot.Services;
using Shadowshot.Views;
using Splat;
using System.Windows;
using WPFLocalizeExtension.Engine;

namespace Shadowshot
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            LocalizeDictionary.Instance.Culture = CultureInfo.CurrentUICulture;

            Locator.CurrentMutable.RegisterConstant(new AutoStartService(), typeof(AutoStartService));
            Locator.CurrentMutable.RegisterConstant(new HotkeyService(), typeof(HotkeyService));
            Locator.CurrentMutable.RegisterConstant(new ScreenshotService(), typeof(ScreenshotService));
            Locator.CurrentMutable.RegisterConstant(new EffectService(), typeof(EffectService));

            Locator.CurrentMutable.RegisterConstant(new MainWindowView(), typeof(MainWindowView));
            Locator.CurrentMutable.RegisterConstant(FindResource("NotifyIcon"), typeof(TaskbarIcon));
        }
        
        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            Locator.CurrentMutable.GetService<TaskbarIcon>().Dispose();
        }
    }
}
