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

        [SerializeField] private Transform lookAtTarget;
        [SerializeField] private Transform rightHandTarget;
        [SerializeField] private Transform leftHandTarget;
        [SerializeField] private Transform rightFootTarget;
        [SerializeField] private Transform leftFootTarget;

        [Range(0, 1)] [SerializeField] private float rightFootIkWeight;

        [Range(0, 1)] [SerializeField] private float leftFootIkWeight;

        [Range(0, 1)] [SerializeField] private float rightHandIkWeight;

        [Range(0, 1)] [SerializeField] private float leftHandIkWeight;

        [Range(0, 1)] [SerializeField] private float headLookAtWeight;


        protected override void OnStarted()
        {
            if (!animator)
                animator = GetComponent<Animator>();
        }

        public Transform LookAtTarget => lookAtTarget;

        public Transform RightHandTarget => rightHandTarget;

        public Transform LeftHandTarget => leftHandTarget;

        public Transform RightFootTarget => rightFootTarget;

        public Transform LeftFootTarget => leftFootTarget;

        public float RightFootIkWeight => rightFootIkWeight;

        public float LeftFootIkWeight => leftFootIkWeight;

        public float RightHandIkWeight => rightHandIkWeight;

        public float LeftHandIkWeight => leftHandIkWeight;

        public float HeadLookAtWeight => headLookAtWeight;

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
                    if (RightHandTarget != null)
                    {
                        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, RightHandIkWeight);
                        animator.SetIKRotationWeight(AvatarIKGoal.RightHand, RightHandIkWeight);
                        animator.SetIKPosition(AvatarIKGoal.RightHand, RightHandTarget.position);
                        animator.SetIKRotation(AvatarIKGoal.RightHand, RightHandTarget.rotation);
                    }

                    if (LeftHandTarget != null)
                    {
                        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, LeftHandIkWeight);
                        animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, LeftHandIkWeight);
                        animator.SetIKPosition(AvatarIKGoal.LeftHand, LeftHandTarget.position);
                        animator.SetIKRotation(AvatarIKGoal.LeftHand, LeftHandTarget.rotation);
                    }

                    if (RightFootTarget != null)
                    {
                        animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, RightFootIkWeight);
                        animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, RightFootIkWeight);
                        animator.SetIKPosition(AvatarIKGoal.RightFoot, RightFootTarget.position);
                        animator.SetIKRotation(AvatarIKGoal.RightFoot, RightFootTarget.rotation);
                    }

                    if (LeftFootTarget != null)
                    {
                        animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, LeftFootIkWeight);
                        animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, LeftFootIkWeight);
                        animator.SetIKPosition(AvatarIKGoal.LeftFoot, LeftFootTarget.position);
                        animator.SetIKRotation(AvatarIKGoal.LeftFoot, LeftFootTarget.rotation);
                    }
                }
                //if the IK is not active, set the position and rotation of the hand and head back to the original position
                else
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                    animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
                    animator.SetLookAtWeight(0);
                }
            }
        }

        private void OnDrawGizmos()
        {
            if(!drawGizmos) return;

            DrawHandleGizmo(leftHandTarget, Color.red);
            DrawHandleGizmo(leftFootTarget, Color.red);

            DrawHandleGizmo(rightHandTarget, Color.blue);
            DrawHandleGizmo(rightFootTarget, Color.blue);

            DrawHandleGizmo(lookAtTarget, Color.green);
        }

        private void DrawHandleGizmo(Transform handle, Color color)
        {
            if (!handle) return;

            Gizmos.color = color;

            Gizmos.DrawSphere(handle.position, .2f);

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