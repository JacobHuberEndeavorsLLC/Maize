using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaizeUI.Helpers
{
    public interface IDialogService
    {
        Task ShowDialogAsync<TDialog, TViewModel>(TViewModel viewModel, Window ownerWindow = null)
            where TDialog : Window, new()
            where TViewModel : class;
    }

    public class DialogService : IDialogService
    {
        public async Task ShowDialogAsync<TDialog, TViewModel>(TViewModel viewModel, Window ownerWindow = null)
            where TDialog : Window, new()
            where TViewModel : class
        {
            var dialog = new TDialog
            {
                DataContext = viewModel,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            if (ownerWindow != null && ownerWindow.IsVisible)
            {
                await dialog.ShowDialog(ownerWindow);
            }
            else
            {
                dialog.Show();
            }
        }
    }

}
