using Avalonia.Controls;
using Avalonia.Interactivity;
using MaizeUI.Helpers;
using MaizeUI.ViewModels;

namespace MaizeUI.Views
{
    public partial class LooperLandsGenerateOneOfOnesWindow : Window
    {
        public LooperLandsGenerateOneOfOnesWindow()
        {
            InitializeComponent();
            DataContextChanged += OnDataContextChanged;
        }
        public void OnHelpButtonClicked(object sender, RoutedEventArgs args)
        {
            Maize.Helpers.Things.OpenUrl("https://maizehelps.art/docs/tutorials/one-of-one-creation/generate-one-of-one-loopers");
        }
        private void OnDataContextChanged(object sender, EventArgs e)
        {
            var viewModel = DataContext as LooperLandsGenerateOneOfOnesWindowViewModel;
            if (viewModel != null)
            {
                viewModel.RequestOpenFolder += OpenFolderDialog;
            }
        }
        private async void OpenFolderDialog()
        {
            var folderPickerDialog = new OpenFolderDialog { Title = "Select Input Directory" };
            var result = await folderPickerDialog.ShowAsync(this);
            var viewModel = (LooperLandsGenerateOneOfOnesWindowViewModel)this.DataContext;
            if (!string.IsNullOrEmpty(result))
            {
                viewModel.InputDirectory = result;
            }
        }
    }
}
