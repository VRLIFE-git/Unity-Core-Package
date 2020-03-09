using Vrlife.Core.Mvc;
using Zenject;

namespace Vrlife.Core
{
    public class ViewProcessorBinder<TView, TController>
        where TController : IController<TView>
    {
        private readonly DiContainer _container;

        public ViewProcessorBinder(DiContainer container)
        {
            _container = container;
        }

        public ViewProcessorBinder<TView, TController> WithViewModelProcessor<TViewModel, TViewProcessor>()
            where TViewProcessor : IViewProcessor<TViewModel, TView, TController>
        {
            _container.Bind<IViewProcessor<TViewModel, TView, TController>>().To<TViewProcessor>().AsSingle();

            return this;
        }
    }
}