using Prism.Commands;
using Prism.Mvvm;
using System.Windows;

namespace RiceCakeSoftware.SegmentedImageCutter.Menu.ViewModels
{
    public class MenuUserControlViewModel : BindableBase
    {
        public DelegateCommand EndCommand { get; }

        public MenuUserControlViewModel()
        {
            EndCommand = new DelegateCommand(() => { Application.Current.Shutdown(); });
        }
    }
}
