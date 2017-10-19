using ReactiveUI;
using System.Reactive;
using System.Windows;

namespace Shadowshot.ViewModels
{
    class NotifyIcon : ReactiveObject
    {
        public NotifyIcon()
        {
            ExitCommand = ReactiveCommand.Create(() => Application.Current.Shutdown());
        }

        public ReactiveCommand<Unit, Unit> ExitCommand { get; }
    }
}
