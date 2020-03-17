using System;
using UnityEngine;
using Vrlife.Core.Mvc.Implementations;

namespace Vrlife.Core
{
    [Serializable]
    public class WalkCommand : Command
    {
        public Transform Target { get; set; }
    }

    public class StateWatcherBehavior : StateMachineBehaviour
    {
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            var monoanimator = animator.GetComponent<MonoAnimator>();
            if (monoanimator)
            {
                monoanimator.InvokeStateChanged(stateInfo, layerIndex);
            }
            base.OnStateExit(animator, stateInfo, layerIndex);
        }
    }
}