using Shadowshot.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shadowshot.Views
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            switch(m.Msg)
            {
                case Services.Win32.NativeMethods.WM_HOTKEY:
                    MainService.Process((MainService.Operation)m.WParam);
                    break;
            }

            base.WndProc(ref m);
        }

        private void entireScreenToDesktopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.Sleep(100);

            MainService.Process(MainService.Operation.EntireScreenToDesktop);
        }

        private void activeWindowToDesktopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.Sleep(100);

            MainService.Process(MainService.Operation.ActiveWindowToDesktop);
        }

        private void entireScreenToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.Sleep(100);

            MainService.Process(MainService.Operation.EntireScreenToClipboard);
        }

        private void activeWindowToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.Sleep(100);

            MainService.Process(MainService.Operation.ActiveWindowToClipboard);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HotkeyService.Unregister(this.Handle);

            var settings = new SettingsForm();
            settings.ShowDialog(this);

            HotkeyService.Register(this.Handle);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var about = new AboutForm();
            about.ShowDialog(this);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
