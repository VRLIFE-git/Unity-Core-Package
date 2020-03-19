using System;
using UnityEngine;

namespace Vrlife.Core
{
    [Serializable]
    public class LookAtCommand : Command
    {
        public Transform Target { get; set; }
    }
}