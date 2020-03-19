using System;
using UnityEngine;
using Vrlife.Core.Mvc.Abstractions;

namespace Vrlife.Core.Mvc
{
    public class MonoKinematicAnimatorComponent : AViewComponent, IKinematicAnimatorComponent
    {
        [SerializeField] private Animator animator;
        [SerializeField] private bool drawGizmos;
        
        public static readonly string LookAtName = nameof(lookAtTarget);
        public static readonly string DrawGizmosName = nameof(drawGizmos);
        public static readonly string RightHandTargetName = nameof(rightHandTarget);
        public static readonly string RightFootTargetName = nameof(rightFootTarget);
        public static readonly string LeftHandTargetName = nameof(leftHandTarget);
        public static readonly string LeftFootTargetName = nameof(leftFootTarget);

        [Range(0, 1)] [SerializeField] private float headLookAtWeight;
        [SerializeField] private Transform lookAtTarget;
        [SerializeField] private IkLimb rightHandTarget;
        [SerializeField] private IkLimb leftHandTarget;
        [SerializeField] private IkLimb rightFootTarget;
        [SerializeField] private IkLimb leftFootTarget;

        public IkLimb RightHand => rightHandTarget;
        public IkLimb LeftHand => leftHandTarget;
        public IkLimb RightFoot => rightFootTarget;
        public IkLimb LeftFoot => leftFootTarget;
        
        protected override void OnStarted()
        {
            if (!animator)
                animator = GetComponent<Animator>();
        }

        public Transform LookAtTarget
        {
            get => lookAtTarget;
            set => lookAtTarget = value;
        }

        public float HeadLookAtWeight
        {
            get => headLookAtWeight;
            set => headLookAtWeight = value;
        }


     
        private void OnAnimatorIK(int layerIndex)
        {
            if (animator)
            {
                //if the IK is active, set the position and rotation directly to the goal. 
                if (IsEnabled)
                {
                    // Set the look target position, if one has been assigned
                    if (LookAtTarget != null)
                    {
                        animator.SetLookAtWeight(HeadLookAtWeight);
                        animator.SetLookAtPosition(LookAtTarget.position);
                    }

                    // Set the hands and foot target position and rotation, if one has been assigned
                    LeftHand.Apply(animator);
                    RightHand.Apply(animator);
                    LeftFoot.Apply(animator);
                    RightFoot.Apply(animator);
                }
                //if the IK is not active, set the position and rotation of the hand and head back to the original position
                else
                {
                    animator.SetLookAtWeight(0);
                }
            }
        }

        private void OnDrawGizmos()
        {
            if(!drawGizmos) return;

            DrawHandleGizmo(leftHandTarget.positionTarget, Color.red);
            DrawHandleGizmo(leftFootTarget.positionTarget, Color.red);

            DrawHandleGizmo(rightHandTarget.positionTarget, Color.blue);
            DrawHandleGizmo(rightFootTarget.positionTarget, Color.blue);

            DrawHandleGizmo(lookAtTarget, Color.green);
        }

        private void DrawHandleGizmo(Transform handle, Color color)
        {
            if (!handle) return;

            Gizmos.color = color;

            Gizmos.DrawSphere(handle.position, .02f);

            DrawLine(handle.position - handle.forward / 2, handle.position + handle.forward, Color.blue);
            DrawLine(handle.position - handle.right / 2, handle.position + handle.right, Color.red);
            DrawLine(handle.position - handle.up / 2, handle.position + handle.up, Color.green);
        }

        private static void DrawLine(Vector3 from, Vector3 to, Color color)
        {
            Gizmos.color = color;

            var blueA = from;
            var blueB = to;

            Gizmos.DrawLine(blueA, blueB);
        }
    }
}