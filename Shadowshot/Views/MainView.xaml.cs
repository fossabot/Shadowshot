using System.Windows.Interop;
using Shadowshot.ViewModels;

namespace Shadowshot.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    partial class MainWindowView
    {
        public MainWindowView()
        {
            InitializeComponent();

            var handle = new WindowInteropHelper(this).EnsureHandle();
            var viewModel = (MainViewModel) DataContext;
            viewModel.RegisterHotkey(handle);
        }
    }
}
