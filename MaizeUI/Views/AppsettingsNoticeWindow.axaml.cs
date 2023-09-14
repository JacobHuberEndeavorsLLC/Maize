using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using MaizeUI.ViewModels;
using System.Threading.Tasks;
using System.Collections.Generic;
using MaizeUI.Helpers;

namespace MaizeUI.Views
{
    public partial class AppsettingsNoticeWindow : Window
    {
        public AppsettingsNoticeWindow()
        {
            InitializeComponent();
        }
        public void OnHelpButtonClicked(object sender, RoutedEventArgs args)
        {
            Website.OpenWebsite("https://maizehelps.art/docs/tutorials/setup-maize");
        }
        public async void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            string filePath = await OpenImageFileDialog();
            if (!string.IsNullOrWhiteSpace(filePath))
            {
                ((AppsettingsNoticeWindowViewModel)DataContext).ImagePath = filePath; // Assuming your ViewModel is set as DataContext
            }
        }

        public async Task<string> OpenImageFileDialog()
        {
            var dialog = new OpenFileDialog
            {
                Title = "Select an image file",
                Filters = new List<FileDialogFilter>
            {
                new FileDialogFilter { Name = "Image Files", Extensions = new List<string> { "png", "jpg", "jpeg", "bmp" } },
            },
            };
            var result = await dialog.ShowAsync(this);

            if (result != null && result.Length > 0)
            {
                return result[0];
            }
            else
            {
                return null;
            }
        }
    }
}
