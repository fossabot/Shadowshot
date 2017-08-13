using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Shadowshot.Controllers;
using Shadowshot.Win32;

namespace Shadowshot.Views
{
    internal partial class SettingsForm : Form
    {
        private readonly Dictionary<ShadowshotController.Operation, Tuple<uint, Keys>> _hotkeys;
        private readonly Dictionary<TextBox, ShadowshotController.Operation> _hotkeyTextBoxs;
        private readonly KeysConverter _keysConverter;

        internal SettingsForm()
        {
            InitializeComponent();

            _keysConverter = new KeysConverter();
            _hotkeys = HotkeyController.Hotkeys;
            _hotkeyTextBoxs = new Dictionary<TextBox, ShadowshotController.Operation>
            {
                {entireScreenToDesktopTextBox, ShadowshotController.Operation.EntireScreenToDesktop},
                {activeWindowToDesktopTextBox, ShadowshotController.Operation.ActiveWindowToDesktop},
                {entireScreenToClipboardTextBox, ShadowshotController.Operation.EntireScreenToClipboard},
                {activeWindowToClipboardTextBox, ShadowshotController.Operation.ActiveWindowToClipboard}
            };

            autoStartCheckBox.Checked = AutoStartController.IsEnabled;

            foreach (var hotkeyTextBox in _hotkeyTextBoxs)
            {
                if (_hotkeys[hotkeyTextBox.Value] != null)
                {
                    var text = string.Empty;
                    if ((_hotkeys[hotkeyTextBox.Value].Item1 & NativeMethods.ModControl) != 0)
                        text += "Ctrl + ";
                    if ((_hotkeys[hotkeyTextBox.Value].Item1 & NativeMethods.ModAlt) != 0)
                        text += "Alt + ";
                    if ((_hotkeys[hotkeyTextBox.Value].Item1 & NativeMethods.ModShift) != 0)
                        text += "Shift + ";
                    text += _keysConverter.ConvertToString(_hotkeys[hotkeyTextBox.Value].Item2);

                    hotkeyTextBox.Key.Text = text;
                    hotkeyTextBox.Key.SelectionStart = text.Length;
                }
                hotkeyTextBox.Key.KeyDown += HotkeyTextBox_KeyDown;
                hotkeyTextBox.Key.KeyUp += HotkeyTextBox_KeyUp;
                hotkeyTextBox.Key.KeyPress += HotkeyTextBox_KeyPress;
            }
        }

        private void HotkeyTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            uint modifiers = 0;
            var text = string.Empty;

            if (e.Control)
            {
                modifiers |= NativeMethods.ModControl;
                text += "Ctrl + ";
            }
            if (e.Alt)
            {
                modifiers |= NativeMethods.ModAlt;
                text += "Alt + ";
            }
            if (e.Shift)
            {
                modifiers |= NativeMethods.ModShift;
                text += "Shift + ";
            }

            _hotkeys[_hotkeyTextBoxs[(TextBox) sender]] = null;
            if (e.KeyCode != Keys.ControlKey &&
                e.KeyCode != Keys.Menu &&
                e.KeyCode != Keys.ShiftKey)
            {
                _hotkeys[_hotkeyTextBoxs[(TextBox) sender]] = new Tuple<uint, Keys>(modifiers, e.KeyCode);
                text += _keysConverter.ConvertToString(e.KeyCode);
            }

            ((TextBox) sender).Text = text;
            ((TextBox) sender).SelectionStart = text.Length;

            e.Handled = true;
        }

        private void HotkeyTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (_hotkeys[_hotkeyTextBoxs[(TextBox) sender]] == null)
                entireScreenToClipboardTextBox.Text = string.Empty;
            e.Handled = true;
        }

        private static void HotkeyTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            AutoStartController.IsEnabled = autoStartCheckBox.Checked;

            HotkeyController.Hotkeys = _hotkeys;

            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
