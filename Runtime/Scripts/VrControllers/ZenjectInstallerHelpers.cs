using Vrlife.Core.Mvc;
using Zenject;

namespace Vrlife.Core.Vr
{
    public static class ZenjectInstallerHelpers
    {
        public static ViewControllerBinder<TView, TController>
            BindViewController<TView, TController>(this DiContainer container) where TController : IController<TView>
        {
            return new ViewControllerBinder<TView, TController>(container);
        }
    }
}