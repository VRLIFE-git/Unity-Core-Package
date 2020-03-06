using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Vrlife.Core
{
    public class InfoCardBody : MonoBehaviour
    {
        [SerializeField] private Transform container;
        [SerializeField] private TextMeshProUGUI content;
        [SerializeField] private Image background;

        private List<GameObject> _content;

        private void Awake()
        {
            _content = new List<GameObject>();
        }

        public void AddBody(GameObject go)
        {
            _content.Add(go);
            go.transform.SetParent(container);
        }
        
        public void Clear()
        {
            _content.Clear();
            container.ClearChildren();
        }
        
        public void SetContent(string value)
        {
            content.text = value;
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