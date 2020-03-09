using UnityEngine;
using Vrlife.Core.Mvc.Abstractions;

namespace Vrlife.Core.Mvc.Implementations
{
    [RequireComponent(typeof(Renderer))]
    public class MonoRenderer : AViewComponent, IRendererComponent
    {
        private Renderer _renderer;

        protected override void OnAwoke()
        {
            _renderer = GetComponent<Renderer>();
        }

        public void SetVisible(bool value)
        {
            _renderer.enabled = value;
        }

        public bool IsVisible => _renderer.enabled;


        public bool ToggleVisible()
        {
            SetVisible(!IsVisible);
            
            return IsVisible;
        }
    }    
}
