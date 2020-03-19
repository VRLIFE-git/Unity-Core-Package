using System;
using UnityEngine;

namespace Vrlife.Core
{
    public class CommandCompletionTrigger : MonoBehaviour
    {
        public ActorManager actorManager;

        public string type;

        private Type _type;

        private void Start()
        {
            _type = Type.GetType(type);
        }

        public void TriggerComplete()
        {
            actorManager.ForceCommandComplete(_type);
        }
    }
}