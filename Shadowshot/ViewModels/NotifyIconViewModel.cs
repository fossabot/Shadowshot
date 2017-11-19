using ReactiveUI;
using Shadowshot.Views;
using System.Reactive;
using System.Windows;

namespace Shadowshot.ViewModels
{
    internal class NotifyIconViewModel : ReactiveObject
    {
        internal NotifyIconViewModel()
        {
            SettingsCommand = ReactiveCommand.Create(() =>
            {
                var view = new SettingsView();
                view.ShowDialog();
            });

            ExitCommand = ReactiveCommand.Create(() => Application.Current.Shutdown());
        }

        public ReactiveCommand<Unit, Unit> SettingsCommand { get; }

        public ReactiveCommand<Unit, Unit> ExitCommand { get; }
    }
}
