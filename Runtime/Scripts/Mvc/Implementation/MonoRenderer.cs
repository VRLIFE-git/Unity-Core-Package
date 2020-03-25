using ICSharpCode.NRefactory.Ast;
using UnityEngine;
using Vrlife.Core.Mvc.Abstractions;
using Zenject;

namespace Vrlife.Core.Mvc.Implementations
{
    
    [RequireComponent(typeof(MeshRenderer))]
    public class MonoRenderer : AViewComponent, IRendererComponent
    {
        private Renderer _renderer;
        private MeshFilter _filter;
        protected override void OnAwoke()
        {
            _filter = GetComponent<MeshFilter>();
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

        public void SetMesh(Mesh mesh)
        {
            _filter.mesh = mesh;
        }

        public Mesh GetMesh()
        {
            return _filter.mesh;
        }

        public void SetSharedMesh(Mesh mesh)
        {
            _filter.sharedMesh = mesh;
        }

        public Mesh GetSharedMesh()
        {
            return _filter.sharedMesh;
        }
    }
}