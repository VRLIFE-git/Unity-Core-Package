using UnityEngine;
using Zenject;

namespace Vrlife.Core
{
    public class InfoCardManager : IInfoCardManager
    {
        private readonly InfoCard _infoCard;

        public InfoCardManager(InfoCard infoCard)
        {
            _infoCard = infoCard;
        }

        public void CloseCard()
        {
            Object.Destroy(_infoCard.gameObject);
        }

        public class Factory : PlaceholderFactory<InfoCard, InfoCardManager>
        {
            public override InfoCardManager Create(InfoCard infoCard)
            {
                return new InfoCardManager(infoCard);
            }
        }
    }
}