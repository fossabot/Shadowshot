using System;
using System.Threading;
using System.Windows.Forms;
using Shadowshot.Controller;
using Shadowshot.Properties;
using Shadowshot.Win32;

namespace Shadowshot
{
    public partial class MainForm : Form
    {
        private MenuItem _autoStartMenuItem;
        private MenuItem _exitMenuItem;
        private NotifyIcon _notifyIcon;
        private MenuItem _seperatorItem;

        public MainForm()
        {
            InitializeComponent();
            InitializeNotifyIcon();
            InitializeHotKey();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == NativeMethods.WmHotkey)
            {
                var screenshotType = (ShadowshotController.Operation) m.WParam.ToInt32();
                var thread = new Thread(() => ShadowshotController.Capture(screenshotType));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }

            base.WndProc(ref m);
        }

        private void InitializeNotifyIcon()
        {
            _seperatorItem = new MenuItem("-");
            _autoStartMenuItem = new MenuItem("Auto Start", AutoStartMenuItem_Click)
            {
                Checked = AutoStartController.IsEnabled
            };
            _exitMenuItem = new MenuItem("Exit", ExitMenuItem_Click);

            _notifyIcon = new NotifyIcon(components)
            {
                ContextMenu = new ContextMenu(new[]
                {
                    _autoStartMenuItem,
                    _seperatorItem,
                    _exitMenuItem
                }),
                Icon = Resources.Icon,
                Text = "Shadowshot",
                Visible = true
            };
        }

        private void InitializeHotKey()
        {
            NativeMethods.RegisterHotKey(Handle, (int) ShadowshotController.Operation.EntireScreenToFile,
                NativeMethods.ModControl | NativeMethods.ModShift, Keys.PrintScreen);
            NativeMethods.RegisterHotKey(Handle, (int) ShadowshotController.Operation.ForegroundWindowToFile,
                NativeMethods.ModAlt | NativeMethods.ModControl | NativeMethods.ModShift, Keys.PrintScreen);
            NativeMethods.RegisterHotKey(Handle, (int) ShadowshotController.Operation.EntireScreenToClipboard,
                NativeMethods.ModControl, Keys.PrintScreen);
            NativeMethods.RegisterHotKey(Handle, (int) ShadowshotController.Operation.ForegroundWindowToClipboard,
                NativeMethods.ModAlt | NativeMethods.ModControl, Keys.PrintScreen);

            Closed += (sender, args) =>
            {
                foreach (var operation in Enum.GetValues(typeof(ShadowshotController.Operation)))
                    NativeMethods.UnregisterHotKey(Handle, (int) operation);
            };
        }

        private void AutoStartMenuItem_Click(object sender, EventArgs eventArgs)
        {
            AutoStartController.IsEnabled = !AutoStartController.IsEnabled;
            _autoStartMenuItem.Checked = AutoStartController.IsEnabled;
        }

        private void ExitMenuItem_Click(object sender, EventArgs eventArgs)
        {
            _notifyIcon.Visible = false;
            Application.Exit();
        }
    }
}
