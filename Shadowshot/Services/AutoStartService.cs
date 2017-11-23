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
        private const string StartupTaskId = "ShadowshotAutoStart";

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
