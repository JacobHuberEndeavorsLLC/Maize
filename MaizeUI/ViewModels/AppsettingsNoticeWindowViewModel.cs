using ReactiveUI;

namespace MaizeUI.ViewModels
{
    public class AppsettingsNoticeWindowViewModel : ViewModelBase
    {
        public string notice;
        public string location;

        public string Notice
        {
            get => notice;
            set => this.RaiseAndSetIfChanged(ref notice, value);
        }
        public string Location
        {
            get => location;
            set => this.RaiseAndSetIfChanged(ref location, value);
        }
    }
}
