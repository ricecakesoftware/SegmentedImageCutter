using Prism.Mvvm;

namespace RiceCakeSoftware.SegmentedImageCutter.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "領域分割画像切出";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }
    }
}
