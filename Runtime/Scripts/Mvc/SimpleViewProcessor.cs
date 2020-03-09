namespace Vrlife.Core.Mvc
{
    public class SimpleViewProcessor : IViewProcessor<SimpleViewModel, ISimpleView, ISimpleController>
    {
        public void ProcessModel(SimpleViewModel model, ISimpleController controller)
        {
            controller.SetVisible(model.isVisible);
        }
    }
}