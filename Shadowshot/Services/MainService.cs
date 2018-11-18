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
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Shadowshot.Services
{
    internal static class MainService
    {
        internal enum Operation
        {
            EntireScreenToDesktop,
            ActiveWindowToDesktop,
            EntireScreenToClipboard,
            ActiveWindowToClipboard
        }

        internal static void Process(Operation operation)
        {
            Bitmap screenshot = null;

            switch (operation)
            {
                case Operation.EntireScreenToDesktop:
                case Operation.EntireScreenToClipboard:
                    screenshot = ScreenshotService.CaptureEntireScreen();
                    break;
                case Operation.ActiveWindowToDesktop:
                case Operation.ActiveWindowToClipboard:
                    screenshot = ScreenshotService.CaptureActiveWindow();
                    break;
            }

            screenshot = EffectService.DropShadow(screenshot);

            switch (operation)
            {
                case Operation.EntireScreenToDesktop:
                case Operation.ActiveWindowToDesktop:
                    var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    var filename = string.Format("Screen Shot {0:yyyy-MM-dd} at {0:h.mm.ss tt}.png", DateTime.Now);
                    screenshot.Save(Path.Combine(desktopPath, filename));
                    break;
                case Operation.EntireScreenToClipboard:
                case Operation.ActiveWindowToClipboard:
                    Clipboard.SetImage(screenshot);
                    break;
            }
        }
    }
}
