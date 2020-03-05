using System.Collections.Generic;
using UnityEngine;

namespace Vrlife.Core
{
    public class InfoCardBody : MonoBehaviour
    {
        [SerializeField] private Transform container;

        private List<GameObject> _content;

        private void Awake()
        {
            _content = new List<GameObject>();
        }

        public void AddContent(GameObject go)
        {
            _content.Add(go);
            go.transform.SetParent(container);
        }
        
        public void Clear()
        {
            _content.Clear();
            container.ClearChildren();
        }
    }
}