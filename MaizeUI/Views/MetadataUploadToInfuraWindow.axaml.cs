using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace MaizeUI.Views
{
    public partial class MetadataUploadToInfuraWindow : Window
    {
        public MetadataUploadToInfuraWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
