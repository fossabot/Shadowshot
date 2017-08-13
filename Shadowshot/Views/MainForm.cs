using System;
using System.Windows.Forms;
using Shadowshot.Controllers;
using Shadowshot.Properties;
using Shadowshot.Win32;

namespace Shadowshot.Views
{
    public partial class MainForm : Form
    {
        private readonly NotifyIcon _notifyIcon;

        public MainForm()
        {
            InitializeComponent();

            _notifyIcon = new NotifyIcon(components)
            {
                ContextMenu = new ContextMenu(new[]
                {
                    new MenuItem("Settings...", SettingsMenuItem_Click),
                    new MenuItem("-"),
                    new MenuItem("Exit", ExitMenuItem_Click)
                }),
                Icon = Resources.Icon,
                Text = "Shadowshot",
                Visible = true
            };

            HotkeyController.RegisterHotKey(Handle);
            Closed += (sender, args) => HotkeyController.UnregisterHotKey(Handle);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == NativeMethods.WmHotkey)
                HotkeyController.HandleHotkey((ShadowshotController.Operation) m.WParam.ToInt32());

            base.WndProc(ref m);
        }

        private void SettingsMenuItem_Click(object sender, EventArgs e)
        {
            HotkeyController.UnregisterHotKey(Handle);

            var settingsForm = new SettingsForm();
            settingsForm.ShowDialog(this);

            HotkeyController.RegisterHotKey(Handle);
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            _notifyIcon.Visible = false;

            Application.Exit();
        }
    }
}
