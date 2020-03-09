using System;
using UnityEngine;
using Vrlife.Core.Mvc.Implementations;

namespace Vrlife.Core.Mvc
{
    [Serializable]
    public class SimpleViewModel : IDirtyModel 
    {
        public bool isVisible;
        public bool IsDirty { get; set; }
    }
}