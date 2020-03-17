using System;
using UnityEngine.Events;

namespace Vrlife.Core
{
    [Serializable]
    public class ActorManagerEventsHandler : UnityEvent<Command[]>
    {
    
    }
}