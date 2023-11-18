using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MaizeUI.Helpers;

namespace MaizeUI.Views
{
    public partial class FindNftDataFromAWalletWindow : Window
    {
        public FindNftDataFromAWalletWindow()
        {
            InitializeComponent();
        }
        public void OnHelpButtonClicked(object sender, RoutedEventArgs args)
        {
            Maize.Helpers.Things.OpenUrl("https://maizehelps.art/docs/tutorials/lookups/nft-info-from-a-wallet");
        }
    }
}
