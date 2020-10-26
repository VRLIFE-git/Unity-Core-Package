using System.ComponentModel;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace Vrlife.Core
{
    public class InfoCard : MonoBehaviour
    {
        [SerializeField] private InfoCardHeader header;
        [SerializeField] private InfoCardBody body;
        [SerializeField] private InfoCardFooter footer;
        [SerializeField] private GameObject gameObject;

        [Header("Accessor shortcuts")]
        public GameObject spacer;
        public GameObject content;
        public Button videoButton;
        public Button galleryButton;
        public Button textButton;
        public Button modelButton;

        [Header("Content")] 
        [CanBeNull] public GameObject contentText;
        [CanBeNull] public GameObject contentGallery;
        [CanBeNull] public GameObject contentVideo;
        [CanBeNull] public GameObject contentModel;

        public GameObject GameObject => gameObject;
        
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

        private void OnDestroy()
        {
            Destroy(this.contentModel?.gameObject);
        }
        
    }
}