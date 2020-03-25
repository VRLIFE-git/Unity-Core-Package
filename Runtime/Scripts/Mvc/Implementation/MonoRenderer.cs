using ICSharpCode.NRefactory.Ast;
using UnityEngine;
using Vrlife.Core.Mvc.Abstractions;
using Zenject;

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

        public void SetMaterial(int index, Material material)
        {
            _renderer.materials[index] = material;
        }

        public Material GetMaterial(int index)
        {
            return _renderer.materials[index];
        }
    }
}