using System;
using System.Reflection;
using Microsoft.Win32;
using Windows.ApplicationModel;
using DesktopBridge;
using static Windows.ApplicationModel.StartupTaskState;

namespace Shadowshot.Services
{
    internal class AutoStartService
    {
        private const string RegistryKeyPath = "Software\\Microsoft\\Windows\\CurrentVersion\\Run";
        private const string RegistryKeyName = "Shadowshot";

        private readonly Helpers _helpers = new Helpers();

        private bool _isEnabled;

        internal AutoStartService()
        {
            if (_helpers.IsRunningAsUwp())
            {
                var startupTask = StartupTask.GetAsync("ShadowshotAutoStart").AsTask().Result;
                _isEnabled = startupTask.State == Enabled;
                IsDisabledByUser = startupTask.State == DisabledByUser;
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
                    var startupTask = StartupTask.GetAsync("ShadowshotAutoStart").AsTask().Result;
                    if (value)
                    {
                        var state = startupTask.RequestEnableAsync().AsTask().Result;
                        _isEnabled = state == Enabled;
                        IsDisabledByUser = state == DisabledByUser;
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
