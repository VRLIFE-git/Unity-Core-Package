using System;
using UnityEngine;

namespace Vrlife.Core
{
    [Serializable]
    public class PointAtCommand : Command
    {
        public Transform Target { get; set; }

        public PointHandSide HandSide { get; set; }
    }
}