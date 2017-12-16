// Copyright 2017 Kagami Studio
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
using System.Reflection;
using Windows.ApplicationModel;
using DesktopBridge;
using Microsoft.Win32;

namespace Shadowshot.Services
{
    internal class AutoStartService
    {
        private const string RegistryKeyPath = "Software\\Microsoft\\Windows\\CurrentVersion\\Run";
        private const string RegistryKeyName = "Shadowshot";
        private const string StartupTaskId = "ShadowshotStartupTask";

        private readonly Helpers _helpers = new Helpers();

        private bool _isEnabled;

        internal AutoStartService()
        {
            if (_helpers.IsRunningAsUwp())
            {
                var startupTask = StartupTask.GetAsync(StartupTaskId).AsTask().Result;
                _isEnabled = startupTask.State == StartupTaskState.Enabled;
                IsDisabledByUser = startupTask.State == StartupTaskState.DisabledByUser;
            }
            else
            {
                try
                {
                    using (var registryKey = Registry.CurrentUser.OpenSubKey(RegistryKeyPath, true))
                    {
                        if (registryKey == null)
                            throw new NullReferenceException();
                        _isEnabled = registryKey.GetValue(RegistryKeyName) != null;
                    }
                }
                catch (NullReferenceException)
                {
                    _isEnabled = false;
                }
                IsDisabledByUser = false;
            }
        }

        internal bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                if (_helpers.IsRunningAsUwp())
                {
                    var startupTask = StartupTask.GetAsync(StartupTaskId).AsTask().Result;
                    if (value)
                    {
                        var state = startupTask.RequestEnableAsync().AsTask().Result;
                        _isEnabled = state == StartupTaskState.Enabled;
                        IsDisabledByUser = state == StartupTaskState.DisabledByUser;
                    }
                    else
                    {
                        startupTask.Disable();
                        _isEnabled = false;
                    }
                }
                else
                {
                    try
                    {
                        using (var registryKey = Registry.CurrentUser.OpenSubKey(RegistryKeyPath, true))
                        {
                            if (registryKey == null)
                                throw new NullReferenceException();
                            var path = Assembly.GetEntryAssembly().Location;
                            if (value)
                                registryKey.SetValue(RegistryKeyName, path);
                            else if (registryKey.GetValue(RegistryKeyName) != null)
                                registryKey.DeleteValue(RegistryKeyName);
                            _isEnabled = value;
                        }
                    }
                    catch (NullReferenceException)
                    {
                        _isEnabled = false;
                    }
                }
            }
        }

        internal bool IsDisabledByUser { get; set; }
    }
}
