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

        public void SetParameter(int id, float value)
        {
            _animator.SetFloat(id, value);
        }
    }
}