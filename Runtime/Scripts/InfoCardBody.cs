using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Vrlife.Core
{
    public class InfoCardBody : MonoBehaviour
    {
        [SerializeField] private Transform container;
        [SerializeField] public TextMeshProUGUI content;
        [SerializeField] private Image background;

        private List<GameObject> _content;

        private void Awake()
        {
            _content = new List<GameObject>();
        }

        public void AddBody(GameObject gameObject)
        {
            _content.Add(gameObject);
            gameObject.transform.SetParent(container, false);
        }
        
        public void Clear()
        {
            _content.Clear();
            container.ClearChildren();
        }

        public void SetTextColor(Color color)
        {
            content.color = color;
        }

        public void SetBackgroundColor(Color color)
        {
            background.color = color;
        }

        public string GetContent() => content.text;
    }
}