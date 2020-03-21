using UnityEngine;

namespace Vrlife.Core.Mvc.Implementations
{
    public abstract class MonoModelViewControllerProxy<TViewModel, TView, TController> : MonoControllerProxy<TView, TController>
        where TController : class, IController<TView, TViewModel> where TViewModel : class
    {
        private IDirtyModel _dirtyModel;

        [SerializeField] protected ViewModelUpdateStrategy updateStrategy;

        [SerializeField] protected TViewModel viewModel;

        public TViewModel ViewModel
        {
            get => viewModel;
            set => viewModel = value;
        }

        protected override void OnStarted()
        {
            ApplyViewModel();
        }

        private void Update()
        {
            if (updateStrategy != ViewModelUpdateStrategy.OnDemand)
            {
                if (updateStrategy == ViewModelUpdateStrategy.OnUpdate ||
                    (_dirtyModel != null && _dirtyModel.IsDirty && updateStrategy == ViewModelUpdateStrategy.WhenDirty))
                {
                    if (updateStrategy == ViewModelUpdateStrategy.WhenDirty && _dirtyModel == null)
                    {
                        Debug.Log("View model doesn't implement interface " + nameof(IDirtyModel));
                    }
                    else
                    {
                        ApplyViewModel();
                    }
                }
            }

            OnUpdated();
        }

        public void ApplyViewModel()
        {
            _dirtyModel = viewModel as IDirtyModel;

            if (_dirtyModel != null)
                _dirtyModel.IsDirty = true;

            Controller.RenderViewModel(viewModel);
        }

        protected virtual void OnUpdated()
        {
        }

        public virtual void RenderViewModel(TViewModel model)
        {
            Controller.RenderViewModel(model);
        }
    }
}