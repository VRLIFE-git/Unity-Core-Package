using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Vrlife.Core
{
    public class ConfirmDialog : MonoBehaviour, IPopupDialog
    {
        public string message;

        public UnityEvent<ConfirmDialogOption> onClose;
        
        [SerializeField] private TextMeshProUGUI messageLabel;

        public void Dispose()
        {
            gameObject.SetActive(false);
        }

        public void Close(ConfirmDialogOption option)
        {
            onClose?.Invoke(option);
            Dispose();
        }
        
        public void Open()
        {
            gameObject.SetActive(true);
            messageLabel.text = message;
        }
    }
}