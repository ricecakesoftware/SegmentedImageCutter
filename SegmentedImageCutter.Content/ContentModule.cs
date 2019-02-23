using RiceCakeSoftware.SegmentedImageCutter.Content.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace RiceCakeSoftware.SegmentedImageCutter.Content
{
    public class ContentModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            containerProvider.Resolve<IRegionManager>().RegisterViewWithRegion("ContentRegion", typeof(ContentUserControl));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
