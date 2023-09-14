using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MaizeUI.Helpers;

namespace MaizeUI.Views
{
    public partial class FindNftDataFromACollectionWindow : Window
    {
        public FindNftDataFromACollectionWindow()
        {
            InitializeComponent();
        }
        public void OnHelpButtonClicked(object sender, RoutedEventArgs args)
        {
            Website.OpenWebsite("https://maizehelps.art/docs/tutorials/lookups/nft-info-from-collection");
        }
    }
}
