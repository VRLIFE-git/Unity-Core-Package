using TMPro;
using UnityEngine;

namespace Vrlife.Core
{
    public class InfoCardHeader : MonoBehaviour, IInfoCard
    {
        [SerializeField]
        private TextMeshProUGUI title;

        public void SetTitle(string value)
        {
            title.text = value;
        }

        public string GetTitle() => title.text;
    }
}