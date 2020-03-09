using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Vrlife.Core
{
    public class InfoCardHeader : MonoBehaviour, IInfoCard
    {
        [SerializeField] private TextMeshProUGUI title;
        [SerializeField] private Image background;
        public void SetTitle(string value)
        {
            title.text = value;
        }

        public void SetTextColor(Color color)
        {
            title.color = color;
        }

        public void SetBackgroundColor(Color color)
        {
            background.color = color;
        }

        public string GetTitle() => title.text;
    }
}