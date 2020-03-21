using Vrlife.Core.Mvc;
using Zenject;

namespace Vrlife.Core.Mvc
{
    public static class ZenjectInstallerHelpers
    {
        public static ViewControllerBinder<TView, TController>
            BindViewController<TView, TController>(this DiContainer container) where TController : IController<TView>
        {
            return new ViewControllerBinder<TView, TController>(container);
        }
        
        public static ViewControllerBinder<TView, TController>
            BindModelViewController<TModel, TView, TController>(this DiContainer container) where TController : IController<TView, TModel>
        {
            return new ViewControllerBinder<TView, TController>(container);
        }
    }
}