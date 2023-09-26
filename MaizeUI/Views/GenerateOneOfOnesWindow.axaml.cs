using Avalonia.Controls;
using Avalonia.Interactivity;
using MaizeUI.Helpers;
using MaizeUI.ViewModels;

namespace MaizeUI.Views
{
    public partial class GenerateOneOfOnesWindow : Window
    {
        public GenerateOneOfOnesWindow()
        {
            InitializeComponent();
            DataContextChanged += OnDataContextChanged;
        }
        public void OnHelpButtonClicked(object sender, RoutedEventArgs args)
        {
            Website.OpenWebsite("https://maizehelps.art/docs/tutorials/one-of-one-creation/generate-one-of-one-nfts");
        }
        private void OnDataContextChanged(object sender, EventArgs e)
        {
            var viewModel = DataContext as GenerateOneOfOnesWindowViewModel;
            if (viewModel != null)
            {
                viewModel.RequestOpenFolder += OpenFolderDialog;
            }
        }
        private async void OpenFolderDialog()
        {
            var folderPickerDialog = new OpenFolderDialog { Title = "Select Input Directory" };
            var result = await folderPickerDialog.ShowAsync(this);
            var viewModel = (GenerateOneOfOnesWindowViewModel)this.DataContext;
            if (!string.IsNullOrEmpty(result))
            {
                viewModel.InputDirectory = result;
            }
        }
    }
}
