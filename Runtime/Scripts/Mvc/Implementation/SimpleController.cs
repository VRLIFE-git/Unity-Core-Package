namespace Vrlife.Core.Mvc.Implementations
{
    public class SimpleController : ISimpleController
    {
        private ISimpleView _view;

        private SimpleViewModel _viewModel;

        private SimpleViewProcessor _processor;

        public SimpleController(SimpleViewProcessor processor)
        {
            _processor = processor;
        }

        public void SetVisible(bool value)
        {
            _viewModel.isVisible = value;
            
            _processor.ProcessModel(_viewModel, this);
        }

        public void Toggle()
        {
            _view.RendererComponent.ToggleVisible();
        }

        public void BindView(ISimpleView view)
        {
            _view = view;
        }

        public void SetViewModel(SimpleViewModel model)
        {
            _viewModel = model;
        }
    }
}