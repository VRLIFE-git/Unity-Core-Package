using UnityEngine;

namespace Vrlife.Core.Mvc
{
    public interface IKinematicAnimatorComponent : IViewComponent
    {
        Transform LookAtTarget { get; }

        Transform RightHandTarget { get; }

        Transform LeftHandTarget { get; }

        Transform RightFootTarget { get; }

        Transform LeftFootTarget { get; }

        float RightFootIkWeight { get; }

        float LeftFootIkWeight { get; }
        float RightHandIkWeight { get; }

        float LeftHandIkWeight { get; }

        float HeadLookAtWeight { get; }
    }
}