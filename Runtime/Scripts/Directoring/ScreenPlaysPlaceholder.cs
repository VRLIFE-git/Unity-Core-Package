using System;
using UnityEngine;

namespace Vrlife.Core
{
    [Serializable]
    public class ScreenPlaysPlaceholder : ScriptableObject
    {
        public ScreenPlay screenPlay;
        public ActorScreenPlayLine[] lines;
    }
}