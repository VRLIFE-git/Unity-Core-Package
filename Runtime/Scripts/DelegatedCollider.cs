using UnityEngine;
using Vrlife.Core.Mvc.Abstractions;

namespace Vrlife.Core
{
    public class DelegatedCollider : AViewComponent
    {
        [SerializeField]
        private GameObject parent;

        public GameObject Parent => parent;

        public TComponent GetParent<TComponent>() where TComponent : Component
        {
            return parent.GetComponent<TComponent>();
        }
    }
}