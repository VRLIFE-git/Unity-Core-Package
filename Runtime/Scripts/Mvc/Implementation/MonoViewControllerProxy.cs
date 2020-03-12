using System;
using UnityEngine;
using Zenject;

namespace Vrlife.Core.Mvc.Implementations
{
    public interface IDirtyModel
    {
        bool IsDirty { get; set; }
    }

    public abstract class
        MonoViewControllerProxy<TViewModel, TView, TController> : MonoControllerProxy<TView, TController>
        where TController : class, IController<TView> where TViewModel : class
    {
        private IDirtyModel _dirtyModel;

        [SerializeField] protected ViewModelUpdateStrategy updateStrategy;

        [SerializeField] protected TViewModel viewModel;

        private IViewProcessor<TViewModel, TView, TController> Processor { get; set; }

        [Inject]
        private void Ctor(IViewProcessor<TViewModel, TView, TController> processor)
        {
            Processor = processor;
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

            Processor.ProcessModel(viewModel, Controller);
        }

        protected virtual void OnUpdated()
        {
        }
    }
}