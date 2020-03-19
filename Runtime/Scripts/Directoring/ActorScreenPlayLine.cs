using System;
using UnityEngine;

namespace Vrlife.Core
{
    [Serializable]
    public class ActorScreenPlayLine : ScreenPlayLine
    {
        public DialogLineEventHandler onLineExecute;
        public string text;
        public Transform walkTo;
        public Transform lookAt;
        public string[] watchAnimationExit;
    }
}