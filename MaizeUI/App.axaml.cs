using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using MaizeUI.ViewModels;
using MaizeUI.Views;
using MaizeUI.Helpers;

namespace MaizeUI
{
    public class App : Application
    {
        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var dialogService = new DialogService();
                var accountService = new AccountService();

                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel(accountService, dialogService),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
