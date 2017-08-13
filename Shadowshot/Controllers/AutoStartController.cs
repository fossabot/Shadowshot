using System;
using System.Reflection;
using Microsoft.Win32;

namespace Shadowshot.Controllers
{
    internal static class AutoStartController
    {
        private const string RegistryKeyPath = "Software\\Microsoft\\Windows\\CurrentVersion\\Run";
        private const string RegistryKeyName = "Shadowshot";
        private static bool _isEnabled;

        static AutoStartController()
        {
            try
            {
                using (var registryKey =
                    Registry.CurrentUser.OpenSubKey(RegistryKeyPath, true))
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
        }

        internal static bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                try
                {
                    using (var registryKey =
                        Registry.CurrentUser.OpenSubKey(RegistryKeyPath, true))
                    {
                        if (registryKey == null)
                            throw new NullReferenceException();
                        var path = Assembly.GetEntryAssembly().Location ?? string.Empty;
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
}
