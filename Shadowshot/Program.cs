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
using Shadowshot.Services;
using Shadowshot.Services.UWP;
using Shadowshot.Views;
using System;
using System.Windows.Forms;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace Shadowshot
{
    static class Program
    {
        private static MainForm main;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ApplicationExit += Application_ApplicationExit;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            main = new MainForm();

            HotkeyService.Register(main.Handle);

            if (Settings.Default.isFirstTime)
            {
                if (Utils.IsRunningAsUwp())
                {
                    var xml = "<toast>" +
                        "<visual>" +
                        "<binding template='ToastGeneric'>" +
                        "<text>Shadowshot</text>" +
                        "<text>Shadowshot is running in the background.</text>" +
                        "</binding>" +
                        "</visual>" +
                        "</toast>";

                    var content = new XmlDocument();
                    content.LoadXml(xml);
                    var notification = new ToastNotification(content);
                    ToastNotificationManager.CreateToastNotifier().Show(notification);
                }

                Settings.Default.isFirstTime = false;
                Settings.Default.Save();
            }

            Application.Run();
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            HotkeyService.Unregister(main.Handle);
        }
    }
}
