using Shadowshot.Properties;
using Shadowshot.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shadowshot.Views
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();

            isAutoStartCheckBox.Enabled = !AutoStartService.IsDisabledByUser;
            isAutoStartCheckBox.Checked = AutoStartService.IsEnabled;
            
            this.entireScreenToDesktopTextBox.Text = keysConverter.ConvertToInvariantString(Settings.Default.entireScreenToDesktopKeyData);
            this.activeWindowToDesktopTextBox.Text = keysConverter.ConvertToInvariantString(Settings.Default.activeWindowToDesktopKeyData);
            this.entireScreenToClipboardTextBox.Text = keysConverter.ConvertToInvariantString(Settings.Default.entireScreenToClipboardKeyData);
            this.activeWindowToClipboardTextBox.Text = keysConverter.ConvertToInvariantString(Settings.Default.activeWindowToClipboardKeyData);
        }

        private readonly TypeConverter keysConverter = TypeDescriptor.GetConverter(typeof(Keys));

        private void entireScreenToDesktopTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.ShiftKey && e.KeyCode != Keys.ControlKey && e.KeyCode != Keys.Menu)
            {
                entireScreenToDesktopTextBox.Text = keysConverter.ConvertToInvariantString(e.KeyData);
            }

            e.SuppressKeyPress = true;
        }
        
        private void activeWindowToDesktopTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.ShiftKey && e.KeyCode != Keys.ControlKey && e.KeyCode != Keys.Menu)
            {
                var keyConverter = TypeDescriptor.GetConverter(typeof(Keys));
                var keyText = keyConverter.ConvertToString(e.KeyData);

                this.activeWindowToDesktopTextBox.Text = keyText;
            }

            e.SuppressKeyPress = true;
        }

        private void entireScreenToClipboardTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.ShiftKey && e.KeyCode != Keys.ControlKey && e.KeyCode != Keys.Menu)
            {
                var keyConverter = TypeDescriptor.GetConverter(typeof(Keys));
                var keyText = keyConverter.ConvertToString(e.KeyData);

                this.entireScreenToClipboardTextBox.Text = keyText;
            }

            e.SuppressKeyPress = true;
        }

        private void activeWindowToClipboardTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.ShiftKey && e.KeyCode != Keys.ControlKey && e.KeyCode != Keys.Menu)
            {
                var keyConverter = TypeDescriptor.GetConverter(typeof(Keys));
                var keyText = keyConverter.ConvertToString(e.KeyData);

                this.activeWindowToClipboardTextBox.Text = keyText;
            }

            e.SuppressKeyPress = true;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (!AutoStartService.IsDisabledByUser)
            {
                AutoStartService.IsEnabled = isAutoStartCheckBox.Checked;
            }

            Settings.Default.entireScreenToDesktopKeyData = (Keys)keysConverter.ConvertFromInvariantString(entireScreenToDesktopTextBox.Text);
            Settings.Default.activeWindowToDesktopKeyData = (Keys)keysConverter.ConvertFromInvariantString(activeWindowToDesktopTextBox.Text);
            Settings.Default.entireScreenToClipboardKeyData = (Keys)keysConverter.ConvertFromInvariantString(entireScreenToClipboardTextBox.Text);
            Settings.Default.activeWindowToClipboardKeyData = (Keys)keysConverter.ConvertFromInvariantString(activeWindowToClipboardTextBox.Text);

            Settings.Default.Save();

            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
