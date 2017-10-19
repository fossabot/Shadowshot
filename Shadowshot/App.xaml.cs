using Hardcodet.Wpf.TaskbarNotification;
using Splat;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Shadowshot
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Locator.CurrentMutable.RegisterConstant(FindResource("NotifyIcon"), typeof(TaskbarIcon));
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            Locator.CurrentMutable.GetService<TaskbarIcon>().Dispose();
        }
    }
}
