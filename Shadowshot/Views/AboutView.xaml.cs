using System.Windows;
using Shadowshot.ViewModels;

namespace Shadowshot.Views
{
    /// <summary>
    /// Interaction logic for AboutView.xaml
    /// </summary>
    public partial class AboutView
    {
        public AboutView()
        {
            InitializeComponent();
        }

        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var viewModel = (AboutViewModel)DataContext;
            viewModel.RequestClose += Close;
        }
    }
}
