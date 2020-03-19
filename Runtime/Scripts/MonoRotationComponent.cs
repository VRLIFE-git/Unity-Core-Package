using UnityEngine;
using Vrlife.Core.Mvc.Abstractions;

namespace Vrlife.Core
{
    public class MonoRotationComponent : AViewComponent, IRotationComponent
    {
        [Tooltip("Transform that will be rotated.")] [SerializeField]
        private Transform overrideRootTransform;

        private Transform root;

        [SerializeField] private Vector3 affectedAxis = Vector3.up;


        [SerializeField] private Transform target;

        [Tooltip("Rotation difference deadzone, inclusive")] [SerializeField]
        private float angleDeadZoneDeg = 0.1f;

        [SerializeField] private float _lerpPrecision = 0.1f;

        [SerializeField] private float speed = 1;

        public bool IsCorrectingRotation { get; private set; }

        public float AngleDiff { get; private set; }

        public float AngleDeadZone
        {
            get => angleDeadZoneDeg;
            set => angleDeadZoneDeg = value;
        }

        public float AngleDiffPerc => Mathf.Clamp01(AngleDiff / AngleDeadZone);

        public Transform Target
        {
            get => target;
            set => target = value;
        }

        public float Speed
        {
            get => speed;
            set => speed = value;
        }

        protected override void OnStarted()
        {
            if (overrideRootTransform)
                root = overrideRootTransform;
        }

        private void Update()
        {
            if (!target)
                return;

            var directionToTarget = target.position - root.position;

            var directionNorm = directionToTarget.normalized;

            AngleDiff = Vector3.Angle(root.forward, directionNorm);

            if (!IsCorrectingRotation)
            {
                if (AngleDiff > angleDeadZoneDeg)
                {
                    IsCorrectingRotation = true;
                }
                else
                {
                    return;
                }
            }

            IsCorrectingRotation = _lerpPrecision < AngleDiff;

            var lookAt = Quaternion.LookRotation(directionNorm).eulerAngles;
            lookAt.Scale(affectedAxis);

            root.rotation = Quaternion.Lerp(root.rotation, Quaternion.Euler(lookAt), Time.deltaTime * speed);
        }
    }
}