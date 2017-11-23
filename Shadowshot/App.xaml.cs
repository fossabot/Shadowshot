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
