using TMPro;
using UnityEngine;


namespace Vrlife.Core
{
    public class SimpleListItem : MonoBehaviour
    {

        [SerializeField]
        private TextMeshProUGUI label;
        
        public void SetText(string text)
        {
            label.text = text;
        }
    }
}