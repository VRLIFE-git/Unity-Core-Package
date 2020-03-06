using UnityEngine;
using UnityEngine.UI;

namespace Vrlife.Core
{
    public class InfoCardFooter : MonoBehaviour
    {
        [SerializeField] private Image background;
        
        public void SetBackgroundColor(Color color)
        {
            background.color = color;
        }
    }
    
}

