using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace MaizeUI.Views
{
    public partial class MetadataRefreshCollectionWindow : Window
    {
        public MetadataRefreshCollectionWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
