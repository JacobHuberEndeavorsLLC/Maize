using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace MaizeUI.ViewModels
{
    public class AppsettingsNoticeWindowViewModel : ViewModelBase
    {
        public string notice;

        public string Notice
        {
            get => notice;
            set => this.RaiseAndSetIfChanged(ref notice, value);
        }
    }
}
