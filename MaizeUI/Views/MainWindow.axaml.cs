using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MaizeUI.ViewModels;

namespace MaizeUI.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}