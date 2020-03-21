using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Vrlife.Core
{
    [Serializable]
    public class ScreenPlaysPlaceholder : ScriptableObject 
    {
        public ScreenPlay screenPlay;
        public ActorScreenPlayLine[] lines;
    }
}