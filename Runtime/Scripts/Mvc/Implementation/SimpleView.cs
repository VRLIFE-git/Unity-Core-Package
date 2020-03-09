using System;
using UnityEngine;

namespace Vrlife.Core.Mvc.Implementations
{
    [Serializable]
    public class SimpleView : ISimpleView
    {
        [SerializeField]
        private MonoRenderer renderer;

        public IRendererComponent RendererComponent => renderer;
    }

    public enum ViewModelUpdateStrategy
    {
        OnDemand,
        OnUpdate,
        WhenDirty
    }
}
