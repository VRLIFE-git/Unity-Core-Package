using UnityEngine;

namespace Vrlife.Core.Mvc
{
    [RequireComponent(typeof(Animator))]
    public class MonoKinematicAnimatorComponent : MonoBehaviour, IKinematicAnimatorComponent
    {
        private Animator _animator;
        
        private void Start()
        {
            _animator = GetComponent<Animator>();
        }
        public Transform LookAtTarget { get; set; }
        public Transform RightHandTarget { get; set; }
        public Transform LeftHandTarget { get; set; }
        public Transform RightFootTarget { get; set; }
        public Transform LeftFootTarget { get; set; }
        public float RightFootIkWeight { get; set; }
        public float LeftFootIkWeight { get; set; }
        public float RightHandIkWeight { get; set; }
        public float LeftHandIkWeight { get; set; }
        public float HeadLookAtWeight { get; set; }
        
        public void SetEnabled(bool value)
        {
            IsEnabled = value;
        }

        public bool IsEnabled { get; private set; }

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

    }
}