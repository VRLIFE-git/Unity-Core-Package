namespace Vrlife.Core.Mvc.Implementations
{
    public class SimpleController : ISimpleController
    {
        private ISimpleView _view;

        public void SetVisible(bool value)
        {
           _view.RendererComponent.SetVisible(value);
        }

        public void Toggle()
        {
            _view.RendererComponent.ToggleVisible();
        }

        public void BindView(ISimpleView view)
        {
            _view = view;
        }
    }
}