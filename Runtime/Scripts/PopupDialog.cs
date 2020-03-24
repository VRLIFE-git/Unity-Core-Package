using System;
using UnityEngine;
using UnityEngine.Events;

namespace Vrlife.Core
{
    public class PopupDialog : MonoBehaviour, IPopupDialog
    {
        public UnityEvent onOpening;
        public UnityEvent onClosing;

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        public virtual void Dispose()
        {
            gameObject.SetActive(false);
        }

        public void Close()
        {
            Dispose();
            onClosing?.Invoke();
            OnClosed();
        }

        protected virtual void OnClosed()
        {
            
        }

        protected virtual void OnOpened()
        {
            
        }

        public void Open()
        {
            OnOpened();
            gameObject.SetActive(true);
            onOpening?.Invoke();
        }
    }
}