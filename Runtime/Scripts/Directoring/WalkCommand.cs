using System;
using UnityEngine;

namespace Vrlife.Core
{
    [Serializable]
    public class WalkCommand : Command
    {
        public Transform Target { get; set; }
    }
}