using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Vrlife.Core
{
    public class InfoCard : MonoBehaviour
    {
        [SerializeField] private InfoCardHeader header;
        [SerializeField] private InfoCardBody body;
        [SerializeField] private InfoCardFooter footer;

        public InfoCardHeader Header => header;

        public InfoCardBody Body => body;

        public InfoCardFooter Footer => footer;

        public UnityEvent onCloseCard;

        private IInfoCardManager _infoCardManager;

        [Inject]
        public void Construct(InfoCardManager.Factory factory)
        {
            _infoCardManager = factory.Create(this);
        }

        private void Start()
        {
            if (onCloseCard == null)
            {
                onCloseCard = new UnityEvent();
            }
        }

        public void CloseCard()
        {
            _infoCardManager.CloseCard();
            InvokeCardClose();
        }


        // Called by buttons
        private void InvokeCardClose()
        {
            onCloseCard.Invoke();
        }
    }
}