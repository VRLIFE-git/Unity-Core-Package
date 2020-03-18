using System;
using UnityEngine;
using Vrlife.Core.Mvc.Abstractions;

namespace Vrlife.Core.Mvc
{
    [RequireComponent(typeof(Animator))]
    public class MonoKinematicAnimatorComponent : AViewComponent, IKinematicAnimatorComponent
    {
        private Animator _animator;

        public static readonly string LookAtName = nameof(lookAtTarget);
        
        [SerializeField] private Transform lookAtTarget;
        [SerializeField] private Transform rightHandTarget;
        [SerializeField] private Transform leftHandTarget;
        [SerializeField] private Transform rightFootTarget;
        [SerializeField] private Transform leftFootTarget;
        
        [Range(0,1)]
        [SerializeField] private float rightFootIkWeight;

        [Range(0,1)]
        [SerializeField] private float leftFootIkWeight;
        
        [Range(0,1)]
        [SerializeField] private float rightHandIkWeight;
        
        [Range(0,1)]
        [SerializeField] private float leftHandIkWeight;
        
        [Range(0,1)]
        [SerializeField] private float headLookAtWeight;


        protected override void OnStarted()
        {
            _animator = GetComponent<Animator>();
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
            if (_animator)
            {
                //if the IK is active, set the position and rotation directly to the goal. 
                if (IsEnabled)
                {
                    // Set the look target position, if one has been assigned
                    if (LookAtTarget != null)
                    {
                        _animator.SetLookAtWeight(HeadLookAtWeight);
                        _animator.SetLookAtPosition(LookAtTarget.position);
                    }

                    // Set the hands and foot target position and rotation, if one has been assigned
                    if (RightHandTarget != null)
                    {
                        _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, RightHandIkWeight);
                        _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, RightHandIkWeight);
                        _animator.SetIKPosition(AvatarIKGoal.RightHand, RightHandTarget.position);
                        _animator.SetIKRotation(AvatarIKGoal.RightHand, RightHandTarget.rotation);
                    }

                    if (LeftHandTarget != null)
                    {
                        _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, LeftHandIkWeight);
                        _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, LeftHandIkWeight);
                        _animator.SetIKPosition(AvatarIKGoal.LeftHand, LeftHandTarget.position);
                        _animator.SetIKRotation(AvatarIKGoal.LeftHand, LeftHandTarget.rotation);
                    }

                    if (RightFootTarget != null)
                    {
                        _animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, RightFootIkWeight);
                        _animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, RightFootIkWeight);
                        _animator.SetIKPosition(AvatarIKGoal.RightFoot, RightFootTarget.position);
                        _animator.SetIKRotation(AvatarIKGoal.RightFoot, RightFootTarget.rotation);
                    }

                    if (LeftFootTarget != null)
                    {
                        _animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, LeftFootIkWeight);
                        _animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, LeftFootIkWeight);
                        _animator.SetIKPosition(AvatarIKGoal.LeftFoot, LeftFootTarget.position);
                        _animator.SetIKRotation(AvatarIKGoal.LeftFoot, LeftFootTarget.rotation);
                    }
                }
                //if the IK is not active, set the position and rotation of the hand and head back to the original position
                else
                {
                    _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                    _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
                    _animator.SetLookAtWeight(0);
                }
            }
        }

        private void OnDrawGizmos()
        {
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

            DrawLine(handle.position - handle.forward/2, handle.position + handle.forward, Color.blue);
            DrawLine(handle.position - handle.right/2, handle.position + handle.right, Color.red);
            DrawLine(handle.position - handle.up/2, handle.position + handle.up, Color.green);
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