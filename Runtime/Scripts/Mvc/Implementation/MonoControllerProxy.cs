using System;
using UnityEngine;
using Zenject;

namespace Vrlife.Core.Mvc.Implementations
{
    public abstract class MonoControllerProxy<TView, TController> : MonoBehaviour
        where TController : class, IController<TView>
    {
        protected abstract TView View { get; }

        protected TController Controller;

        private void Start()
        {
            OnStarted();
        }


        protected virtual void OnStarted()
        {
            
        }

        [Inject]
        private void Ctor(TController controller)
        {
            if (controller == this as TController)
            {
                throw new StackOverflowException("Don't bind '" + nameof(TController) +" to self! Implement IController<"+nameof(TView) + "> and bind it instead.");
            }
            
            Controller = controller;

            BindView(View);
        }
        
        public void  BindView(TView model)
        {
            Controller.BindView(View);
        }
    }
}