using System;
using UnityEngine;

namespace Vrlife.Core.Mvc
{
    [Serializable]
    public class IkLimb
    {
        public Transform positionTarget;
        public Transform hintTarget;

        public Transform rotationTarget;

        [Range(0,1)]
        public float positionWeight;

        [Range(0,1)]
        public float rotationWeight;

        public AvatarIKGoal ikGoal;
        public AvatarIKHint ikHint;

        public void Apply(Animator animator)
        {
            
            
            if (positionTarget)
            {
                if (hintTarget)
                {
                    animator.SetIKHintPosition(ikHint, hintTarget.position);
                }
                animator.SetIKPosition(ikGoal, positionTarget.position);
                animator.SetIKPositionWeight(ikGoal, positionWeight);
            }
            else
            {
                animator.SetIKPositionWeight(ikGoal, 0);
            }

            if (rotationTarget)
            {
                animator.SetIKRotation(ikGoal, rotationTarget.rotation);
                animator.SetIKRotationWeight(ikGoal, rotationWeight);
            }
            else
            {
                animator.SetIKRotationWeight(ikGoal, 0);
            }
        }
    }
}