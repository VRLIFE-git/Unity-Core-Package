using System;
using UnityEngine;

namespace Vrlife.Core.Mvc.Abstractions
{
    public abstract class AViewComponent : MonoBehaviour, IViewComponent
    {
        private void Awake()
        {
            OnAwoke();
        }

        protected virtual void OnAwoke()
        {
            
        }

        private void Start()
        {
            OnStarted();
        }

        protected virtual void OnStarted()
        {
        }


        public void SetEnabled(bool value)
        {
            enabled = value;
        }

        public bool IsEnabled => enabled;

        private void OnDestroy()
        {
            OnDestroyed();
        }

        public virtual void OnDestroyed()
        {
            
        }
    }
}