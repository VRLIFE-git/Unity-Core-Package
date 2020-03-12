using UnityEngine;
using Vrlife.Core.Mvc.Abstractions;

namespace Vrlife.Core.Mvc.Implementations
{
    [RequireComponent(typeof(Animator))]
    public class MonoAnimator : AViewComponent, IAnimatorComponent
    {
        private Animator _animator;

        protected override void OnAwoke()
        {
            _animator = GetComponent<Animator>();
        }

        public void SetLayerWeight(int layerId, float value)
        {
            _animator.SetLayerWeight(layerId, value);
        }

        public void SetParameter(int id, float value)
        {
            _animator.SetFloat(id, value);
        }

        public void SetParameter(int id, bool value)
        {
            _animator.SetBool(id, value);
        }

        public void SetParameter(int id, int value)
        {
            _animator.SetInteger(id, value);
        }

        public bool GetBoolParameter(int id)
        {
            return _animator.GetBool(id);
        }

        public int GetIntParameter(int id)
        {
            return _animator.GetInteger(id);
        }

        public float GetFloatParameter(int id)
        {
            return _animator.GetFloat(id);
        }
    }
}