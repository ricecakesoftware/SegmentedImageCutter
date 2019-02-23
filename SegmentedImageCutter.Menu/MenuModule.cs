using RiceCakeSoftware.SegmentedImageCutter.Menu.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace RiceCakeSoftware.SegmentedImageCutter.Menu
{
    public class MenuModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            containerProvider.Resolve<IRegionManager>().RegisterViewWithRegion("MenuRegion", typeof(MenuUserControl));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
