using Prism.Ioc;
using Prism.Modularity;
using RiceCakeSoftware.SegmentedImageCutter.Content;
using RiceCakeSoftware.SegmentedImageCutter.Menu;
using RiceCakeSoftware.SegmentedImageCutter.Views;
using System.Windows;

namespace RiceCakeSoftware.SegmentedImageCutter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<MenuModule>();
            moduleCatalog.AddModule<ContentModule>();
        }
    }
}
