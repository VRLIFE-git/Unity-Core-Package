using Vrlife.Core.Mvc;
using Zenject;

namespace Vrlife.Core.Vr
{
    public class ViewControllerBinder<TView, TController> where TController : IController<TView>
    {
        private readonly DiContainer _container;

        public ViewControllerBinder(DiContainer container)
        {
            _container = container;
        }


        public ViewProcessorBinder<TView, TController> 
            WithControllerImplementation<TImplementation>()
            where TImplementation : TController
        {
            _container.Bind<TController>().To<TImplementation>().AsTransient();

            return new ViewProcessorBinder<TView, TController>(_container);
        }
        
        
    }
}