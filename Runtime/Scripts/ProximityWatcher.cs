using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vrlife.Core.Mvc.Abstractions;

namespace Vrlife.Core
{
    [Serializable]
    public class ProximityTriggerEventHandler : UnityEvent<ProximityWatcher, Collider>
    {
    }

    [Serializable]
    public class ProximityCollisionEventHandler : UnityEvent<ProximityWatcher, Collision>
    {
    }

    public class ProximityWatcher : AViewComponent, IDisposable
    {
        [Tooltip("If delegated object resides somewhere else in hierarchy.")]

        [SerializeField] private string[] watchedTags;

        private List<GameObject> _collidingObjects;


        public IReadOnlyList<GameObject> ProximityObjects => _collidingObjects;

        public bool watchCollision;

        public bool watchTrigger;

        public ProximityTriggerEventHandler onProximityTriggerEnter;
        public ProximityTriggerEventHandler onProximityTriggerExit;

        public ProximityCollisionEventHandler onProximityCollisionEnter;
        public ProximityCollisionEventHandler onProximityCollisionExit;

        protected override void OnStarted()
        {
            _collidingObjects = new List<GameObject>();
        }

        private void OnCollisionEnter(Collision other)
        {
            var collidingGo = GetObject(other.collider);
         
            if(!collidingGo) return;

            _collidingObjects.Add(collidingGo);

            onProximityCollisionEnter?.Invoke(this, other);
        }

        private void OnCollisionExit(Collision other)
        {
            var collidingGo = GetObject(other.collider);
            if(!collidingGo) return;
            _collidingObjects.Remove(collidingGo);

            onProximityCollisionExit?.Invoke(this, other);
        }

        private GameObject GetObject(Component other)
        {
            if (!watchedTags.Contains(other.gameObject.tag)) return null;
            if (!watchCollision)  return null;
            
            var collidingGo = other.gameObject;

            var delegatedCollider = collidingGo.GetComponent<DelegatedCollider>();
            if (delegatedCollider)
            {
                collidingGo = delegatedCollider.Parent;
            }

            return collidingGo;
        }

        private void OnTriggerEnter(Collider other)
        {
            var collidingGo = GetObject(other);
         
            if(!collidingGo) return;

            _collidingObjects.Add(collidingGo);
            
            onProximityTriggerEnter?.Invoke(this, other);
        }

        private void OnTriggerExit(Collider other)
        {
            var collidingGo = GetObject(other);
         
            if(!collidingGo) return;

            _collidingObjects.Remove(collidingGo);
            
            onProximityTriggerExit?.Invoke(this, other);
        }

        public override void OnDestroyed()
        {
            Dispose();
        }

        public void Dispose()
        {
            _collidingObjects.Clear();
        }
    }
}