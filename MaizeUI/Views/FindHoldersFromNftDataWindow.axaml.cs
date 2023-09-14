using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MaizeUI.Helpers;

namespace MaizeUI.Views
{
    public partial class FindHoldersFromNftDataWindow : Window
    {
        public FindHoldersFromNftDataWindow()
        {
            InitializeComponent();
        }
        public void OnHelpButtonClicked(object sender, RoutedEventArgs args)
        {
            Website.OpenWebsite("https://maizehelps.art/docs/tutorials/lookups/holders-from-nft-data");
        }
    }
}
