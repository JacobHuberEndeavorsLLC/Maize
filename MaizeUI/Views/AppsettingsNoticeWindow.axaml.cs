using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MaizeUI.ViewModels;

namespace MaizeUI.Views
{
    public partial class AppsettingsNoticeWindow : Window
    {
        public AppsettingsNoticeWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}