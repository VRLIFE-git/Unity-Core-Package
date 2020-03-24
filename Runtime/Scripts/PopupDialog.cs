using UnityEngine;
using UnityEngine.Events;

namespace Vrlife.Core
{
    public class PopupDialog : MonoBehaviour, IPopupDialog
    {
        public UnityEvent onOpening;
        public UnityEvent onClosing;


        public virtual void Dispose()
        {
            gameObject.SetActive(false);
        }

        public void Close()
        {
            Dispose();
            onClosing?.Invoke();
        }

        public void Open()
        {
            gameObject.SetActive(true);
            onOpening?.Invoke();
        }
    }
}