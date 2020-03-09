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
        where TController : IController<TView> where TViewModel : class
    {
        [SerializeField] protected ViewModelUpdateStrategy updateStrategy;
        
        [SerializeField] protected TViewModel initialModel;

        private IDirtyModel _dirtyModel;

        protected IViewProcessor<TViewModel, TView, TController> Processor { get; private set; }

        [Inject]
        private void Ctor(IViewProcessor<TViewModel, TView, TController> processor)
        {
            Processor = processor;
        }

        public void ProcessModel(TViewModel viewModel)
        {
            if (initialModel != viewModel)
            {
                initialModel = viewModel;

                _dirtyModel = initialModel as IDirtyModel;

                if (_dirtyModel != null)
                    _dirtyModel.IsDirty = true;

            }
            Processor.ProcessModel(initialModel, Controller);
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
                    ApplyViewModel();
                }
            }

            OnUpdated();
        }

        public void ApplyViewModel()
        {
            ProcessModel(initialModel);
        }

        protected virtual void OnUpdated()
        {
        }
    }
}