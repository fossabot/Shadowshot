using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Shadowshot.ViewModels;

namespace Shadowshot.Views
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView
    {
        public SettingsView()
        {
            InitializeComponent();

            var hotkeyTextBoxList = new[]
            {
                EntireScreenToDesktopHotkeyTextBox,
                ActiveWindowToDesktopHotkeyTextBox,
                EntireScreenToClipboardHotkeyTextBox,
                ActiveWindowToClipboardHotkeyTextBox
            };

            foreach (var textBox in hotkeyTextBoxList)
                textBox.PreviewKeyDown += (sender, args) =>
                {
                    args.Handled = true;

                    var modifierKeysConverter = TypeDescriptor.GetConverter(typeof(ModifierKeys));
                    var modifierKeysText = modifierKeysConverter.ConvertToString(Keyboard.Modifiers);

                    var keyConverter = TypeDescriptor.GetConverter(typeof(Key));
                    var key = args.Key == Key.System ? args.SystemKey : args.Key;
                    if (key == Key.LeftCtrl || key == Key.RightCtrl ||
                        key == Key.LeftAlt || key == Key.RightAlt ||
                        key == Key.LeftShift || key == Key.RightShift ||
                        key == Key.LWin || key == Key.RWin)
                        return;
                    var keyText = keyConverter.ConvertToString(key);

                    textBox.Text = $"{modifierKeysText}+{keyText}";
                };
        }

        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var viewModel = (SettingsViewModel) DataContext;
            viewModel.RequestClose += Close;

            Closing += viewModel.OnViewClosing;
        }
    }
}
