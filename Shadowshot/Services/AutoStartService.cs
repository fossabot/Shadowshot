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
using System.Reflection;
using Windows.ApplicationModel;
using Microsoft.Win32;
using Shadowshot.Services.UWP;

namespace Shadowshot.Services
{
    internal static class AutoStartService
    {
        private const string RegistryKeyPath = "Software\\Microsoft\\Windows\\CurrentVersion\\Run";
        private const string RegistryKeyName = "Shadowshot";
        private const string StartupTaskId = "ShadowshotStartupTask";

        internal static bool IsEnabled
        {
            get
            {
                if (Utils.IsRunningAsUwp())
                {
                    var startupTask = StartupTask.GetAsync(StartupTaskId).AsTask().Result;
                    return startupTask.State == StartupTaskState.Enabled;
                }
                else
                {
                    try
                    {
                        using (var registryKey = Registry.CurrentUser.OpenSubKey(RegistryKeyPath, true))
                        {
                            if (registryKey == null)
                                throw new NullReferenceException();
                            return registryKey.GetValue(RegistryKeyName) != null;
                        }
                    }
                    catch (NullReferenceException)
                    {
                        return false;
                    }
                }
            }
            set
            {
                if (Utils.IsRunningAsUwp())
                {
                    var startupTask = StartupTask.GetAsync(StartupTaskId).AsTask().Result;
                    if (value)
                    {
                        startupTask.RequestEnableAsync().AsTask();
                    }
                    else
                    {
                        startupTask.Disable();
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
                        }
                    }
                    catch (NullReferenceException)
                    {
                    }
                }
            }
        }

        internal static bool IsDisabledByUser
        {
            get
            {
                if (Utils.IsRunningAsUwp())
                {
                    var startupTask = StartupTask.GetAsync(StartupTaskId).AsTask().Result;
                    return startupTask.State == StartupTaskState.DisabledByUser;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
