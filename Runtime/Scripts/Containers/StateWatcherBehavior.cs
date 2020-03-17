using UnityEngine;
using Vrlife.Core.Mvc.Implementations;

namespace Vrlife.Core
{
    public class StateWatcherBehavior : StateMachineBehaviour
    {
        private Animator _animator;
        private MonoAnimator _monoAnimator;
        
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (_animator != animator)
            {
                _animator = animator;
                _monoAnimator = animator.GetComponent<MonoAnimator>();
            }
            
            if (_monoAnimator)
            {
                _monoAnimator.InvokeStateExited(stateInfo, layerIndex);
            }
            
            base.OnStateExit(animator, stateInfo, layerIndex);
        }

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (_animator != animator)
            {
                _animator = animator;
                _monoAnimator = animator.GetComponent<MonoAnimator>();
            }
            
            if (_monoAnimator)
            {
                _monoAnimator.InvokeStateEntered(stateInfo, layerIndex);
            }
            
            base.OnStateEnter(animator, stateInfo, layerIndex);
        }
    }
}