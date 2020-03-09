namespace Vrlife.Core.Mvc
{
    public interface IViewProcessor<in TViewModel, TView, in TController> where TController : IController<TView>
    {
        void ProcessModel(TViewModel model, TController controller);
    }
}