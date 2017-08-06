using System;
using System.Reflection;
using Microsoft.Win32;

namespace Shadowshot.Controller
{
    internal static class AutoStartController
    {
        private static bool _isEnabled;

        static AutoStartController()
        {
            try
            {
                using (var registryKey =
                    Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    if (registryKey == null)
                        throw new NullReferenceException();
                    _isEnabled = registryKey.GetValue("Shadowshot") != null;
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
                        Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                    {
                        if (registryKey == null)
                            throw new NullReferenceException();
                        var path = Assembly.GetEntryAssembly().Location;
                        if (path == null)
                            throw new NullReferenceException();
                        if (value)
                            registryKey.SetValue("Shadowshot", path);
                        else
                            registryKey.DeleteValue("Shadowshot");
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
